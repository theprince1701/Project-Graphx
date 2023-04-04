Shader "Custom/DepthOfField"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _DofTex("DofTex", 2D) = "white" {}
    }
   CGINCLUDE
   #include "UnityCG.cginc"

    sampler2D _MainTex, _CameraDepthTexture, _CocTexture, _DofTex;
    float4 _MainTex_TexelSize;

    float _FocusDistance, _FocusRange, _BokehRadius;

    struct VertexData
    {
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
    };

    struct Interpolators
    {
        float4 pos : SV_POSITION;
        float2 uv : TEXCOORD0;
    };

    Interpolators VertexProgram(VertexData v)
    {
        Interpolators i;
        i.pos = UnityObjectToClipPos(v.vertex);
        i.uv = v.uv;
        return i;
    }
   ENDCG
    SubShader
    {
        Cull Off
        ZTest Always
        ZWrite Off
        
        Pass //0 
        {
            CGPROGRAM
            #pragma vertex VertexProgram
            #pragma fragment FragmentProgram

            half4 FragmentProgram(Interpolators i) : SV_Target
            {
              //  return tex2D(_MainTex, i.uv);

                half depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv);
                depth = LinearEyeDepth(depth);

                float coc = (depth - _FocusDistance) / _FocusRange;
                coc = clamp(coc, -1, 1) * _BokehRadius;

                if(coc < 0)
                {
                    return coc * -half4(1,0,0,1);
                }
                
                return coc;
            }
            ENDCG
        }
        
        Pass // 1
        {
            CGPROGRAM
            #pragma vertex VertexProgram
            #pragma fragment FragmentProgram

            half4 FragmentProgram(Interpolators i) : SV_Target
            {
                float4 o = _MainTex_TexelSize.xyxy * float2(-0.5, 0.5).xxyy;

                half coc0 = tex2D(_CocTexture, i.uv + o.xy).r;
                half coc1 = tex2D(_CocTexture, i.uv + o.zy).r;
                half coc2 = tex2D(_CocTexture, i.uv + o.xw).r;
                half coc3 = tex2D(_CocTexture, i.uv + o.zw).r;

                half coc = (coc0 + coc1 + coc2 + coc3) * 0.25f;

                return half4(tex2D(_MainTex, i.uv).rgb, coc);
            }
            
            ENDCG
        }
        
        Pass //2
        {
            CGPROGRAM
            #pragma vertex VertexProgram
            #pragma fragment FragmentProgram

            static const int kernelSampleCount = 16;
            static const float2 kernel[kernelSampleCount] = {
                    float2(0, 0),
                    float2(0.54545456, 0),
                    float2(0.16855472, 0.5187581),
                    float2(-0.44128203, 0.3206101),
                    float2(-0.44128197, -0.3206102),
                    float2(0.1685548, -0.5187581),
                    float2(1, 0),
                    float2(0.809017, 0.58778524),
                    float2(0.30901697, 0.95105654),
                    float2(-0.30901703, 0.9510565),
                    float2(-0.80901706, 0.5877852),
                    float2(-1, 0),
                    float2(-0.80901694, -0.58778536),
                    float2(-0.30901664, -0.9510566),
                    float2(0.30901712, -0.9510565),
                    float2(0.80901694, -0.5877853),
          };
            
            half4 FragmentProgram(Interpolators i) : SV_Target
            {
                half3 color = 0;
                half weight = 0;
                
                for(int k = 0; k < kernelSampleCount; k++)
                {
                    float2 o = kernel[k] * _BokehRadius;
                    half radius = length(o);
                    o *= _MainTex_TexelSize.xy;
                  //  color += tex2D(_MainTex, i.uv + o).rgb;

                    half4 s = tex2D(_MainTex, i.uv + o);

                    if(abs(s.a) >= radius)
                    {
                        color += s.rgb;
                        weight += 1;
                    }
                }

                color *= 1.0 / weight;
                return half4(color, 1);
            }
            
            ENDCG
        }
        
        Pass //3
        {
            CGPROGRAM
            #pragma vertex VertexProgram
            #pragma fragment FragmentProgram

            half4 FragmentProgram(Interpolators i) : SV_Target
            {
                float4 o = _MainTex_TexelSize.xyxy * float2(-0.5f, 0.5f).xxyy;

                half4 s = tex2D(_MainTex, i.uv + o.xy) + tex2D(_MainTex, i.uv + o.zy) + tex2D(_MainTex, i.uv + o.xw) + tex2D(_MainTex, i.uv + o.zw);

                return s * 0.25f;
            }
            
            ENDCG
        }
        
        Pass 
        {
        
            CGPROGRAM
            #pragma vertex VertexProgram
            #pragma fragment FragmentProgram

            half4 FragmentProgram(Interpolators i) : SV_Target
            {
                half4 source = tex2D(_MainTex, i.uv).r;
                half4 coc = tex2D(_CocTexture, i.uv).r;
                half4 dof = tex2D(_DofTex, i.uv);

                half dofStrength = smoothstep(0.1, 1, abs(coc));

                half3 color = lerp(source.rgb, dof.rgb, dofStrength + dof.a - dofStrength * dof.a);

                return half4(color,source.a);
            }

            
            ENDCG
            }
    }
    FallBack "Diffuse"
}
