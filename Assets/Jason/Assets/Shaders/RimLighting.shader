Shader "Custom/RimLighting"{
    Properties {
		RimColour("Rim Colour", Color) = (0,0.5,0.5,0.0)
		RimPower("Rim Power", Range(0.5,8.0)) = 3.0
	}

	SubShader {
		CGPROGRAM
		#pragma surface surf Lambert
		struct Input {
			float3 viewDir;
		};
		
		float4 RimColour;
		float RimPower;
		void surf(Input IN, inout SurfaceOutput o){
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = RimColour.rgb * pow(rim, RimPower);
		}
		ENDCG
	}
	Fallback "Diffuse"
}
