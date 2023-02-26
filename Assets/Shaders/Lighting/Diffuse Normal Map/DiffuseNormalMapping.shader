  Shader "Lighting/DiffuseNormalMap" 
{
    Properties 
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BumpMap ("Bumpmap", 2D) = "bump" {}
        _NormalIntensity("Normal Intensity", Range(0, 2)) = 1.0
    }
    SubShader 
    {
      Tags { "RenderType" = "Opaque" }
        
        
      CGPROGRAM
      #pragma surface surf Lambert
      
      struct Input {
          float2 uv_MainTex;

          //add in uv's for our BumpMap texture in Properties
          float2 uv_BumpMap;
      };
      
      sampler2D _MainTex;
      sampler2D _BumpMap;
      float _NormalIntensity;
      
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap) * _NormalIntensity);
      }
      ENDCG
    }
    Fallback "Diffuse"
  }