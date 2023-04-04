Shader "Custom/ChromaticAbberation"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Distortion("Distortion", Range(-1, 1)) = 0.1
        _Scale("Sccale", Range(0, 10)) = 1
        Center("Center", Vector) = (0.5, 0.5, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass {
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #include "UnityCG.cginc"

        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };
        
        struct v2f
        {
            float2 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
        };

        float _Distortion;
        float _Scale;
        float4 _Center;
        sampler2D _MainTex;

        v2f vert(appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = v.uv;

            return o;
        }

        fixed4 frag(v2f i) : SV_Target
        {
            float2 center = _Center.xy;
            float2 p = i.uv - center;
            float r2 = dot(p,p);
            float2 distortion = p * (_Distortion * r2 + 1);
            float2 uv = center + distortion * _Scale;

            return tex2D(_MainTex, uv);
        }
        
        
        
        ENDCG
            
        }
    }
    FallBack "Diffuse"
}
