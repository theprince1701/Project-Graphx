Shader "Custom/SpecularShader"{
    Properties{
		MainTex("Texture", 2D) = "white" {}
		Colour("Colour", Color) = (1,1,1,1)
	}
	SubShader{
		Tags { "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf SimpleSpecular

		half4 LightingSimpleSpecular(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
			half3 h = normalize(lightDir + viewDir);
	
			half diff = max(0, dot(s.Normal, lightDir));
	
			float nh = max(0, dot(s.Normal, h));
			float spec = pow(nh, 48.0);
	
			half4 c;
			c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * spec) * atten;
			c.a = s.Alpha;
			return c;
		}
	
		struct Input {
			float2 uv_MainTex;
		};
	
		sampler2D MainTex;
		fixed4 Colour;
	
		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = (tex2D(MainTex, IN.uv_MainTex) * Colour).rgb;
		}
		ENDCG
	}
	Fallback "Diffuse"
}
