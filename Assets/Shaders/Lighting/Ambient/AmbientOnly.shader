Shader "Custom/AmbientOnly"
{
    Properties
    {
       _Color("Color", Color) = (1.0,1.0,1.0)
    }
        SubShader
    {
            Tags {"LightMode" = "ForwardBase"}
            Pass
        {

        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        // user defined variables
        uniform float4 _Color;
    // unity defined variables
    uniform float4 _LightColor0;
    // base input structs
    struct vertexInput
    {
        float4 vertex: POSITION;
    };
    struct vertexOutput
    {
        float4 pos: SV_POSITION;
        float4 col: COLOR;
    };
    // vertex functions
    vertexOutput vert(vertexInput v)
    {
        vertexOutput o;
        float3 lightFinal = UNITY_LIGHTMODEL_AMBIENT.xyz;
        o.col = float4(lightFinal, 1.0);
        o.pos = UnityObjectToClipPos(v.vertex);
        return o;
    }
    // fragment function
    float4 frag(vertexOutput i) : COLOR
    {
        return i.col;
    }
    ENDCG
}

    }
        FallBack "Diffuse"
}
