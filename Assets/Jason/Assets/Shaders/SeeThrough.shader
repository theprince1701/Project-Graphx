Shader "Custom/SeeThrough"{
    Properties {
		Colour("Colour", Color) = (1,1,1,1)
	}
	SubShader {
		Tags{"Queue" = "Transparent"}
		
		CGPROGRAM
		#pragma surface surf Lambert alpha:fade
		struct Input {
			float3 viewDir;
		};

		float4 Colour;

		void surf(Input IN, inout SurfaceOutput o){
			o.Albedo = Colour.rgb;
			o.Alpha = 0.8;
		}
		ENDCG
	}
	Fallback "Diffuse"
}