Shader "Custom/Shadows"
{
    Properties
    {
      _MainTex ("Texture", 2D) = "white" {}
      _ShadowColor("Shadow Color", COLOR) =  (0,0,0,0)
    }
    SubShader
    {
        Pass 
        {
            Tags { "LightMode" = "ForwardBase" }
            
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"
            #include "AutoLight.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 diff : COLOR0;
                float4 vertex : SV_POSITION;
                SHADOW_COORDS(1)
            };

            sampler2D _MainTex;
            float4 _ShadowColor;
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;

                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                
                half d = dot(worldNormal, _WorldSpaceLightPos0.xyz);
                half nl = max(0, d);
                o.diff = nl * _LightColor0;

           //     TRANSFER_SHADOW(o);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                fixed4 shadow = SHADOW_ATTENUATION(i);
                col.rgb *= i.diff * shadow;
                return col;
            }
            ENDCG
        }
        
        Pass
        {
            Tags { "LightMode" = "ShadowCaster" }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma  multi_compile_shadowcaster

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                V2F_SHADOW_CASTER;
            };

            v2f vert(appdata v)
            {
                v2f o;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(i);
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
