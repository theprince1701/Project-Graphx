Shader "Custom/Diffuse+Decal"{
    Properties{
		MainTex("Texture", 2D) = "white" {}
		DecalTex("Decal", 2D) = "white" {}
		[Toggle] ShowDecal("Show Decal?", Float) = 0
	}
	SubShader{
		Tags { "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf WrapLambert

		half4 LightingWrapLambert(SurfaceOutput s, half3 lightDir, half atten) {
			half NdotL = dot(s.Normal, lightDir);
			half diff = NdotL * 0.5 + 0.5;
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten);
			c.a = s.Alpha;
			return c;
		}

		struct Input {
			float2 uv_MainTex;
		};

		sampler2D MainTex;
		sampler2D DecalTex;
		float ShowDecal;

		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 base = tex2D(MainTex, IN.uv_MainTex);
			fixed4 decal = tex2D(DecalTex, IN.uv_MainTex);

			o.Albedo = base.rgb + decal.rgb * ShowDecal;
		}
		ENDCG
	}
	Fallback "Diffuse"
}