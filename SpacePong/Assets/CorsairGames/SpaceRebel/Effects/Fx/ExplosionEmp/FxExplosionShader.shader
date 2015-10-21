Shader "Effects/EmpExplosion" {
    Properties {
        _MainTex ("Base texture", 2D) = "white" { }
        _MaskTex ("Fade mask", 2D) = "white" { }
        _TimeSlider ("Time slider (0-1)", Range (0, 1)) = 1
    }
    SubShader {
        Tags
        {
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
            "IgnoreProjector" = "True"
        }
        
        LOD 100
        
        Blend SrcAlpha OneMinusSrcAlpha 
        ZWrite Off
        
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            sampler2D _MainTex;
            sampler2D _MaskTex;
            sampler2D _IntensityMaskTex;
            
            float4 _MainTex_ST;
            float4 _MaskTex_ST;
            float4 _IntensityMaskTex_ST;
            
            float _TimeSlider;
            
            struct v2f {
                float4 pos : SV_POSITION;
                float2  uv : TEXCOORD0;
                float2  uv1 : TEXCOORD1;
            };

            v2f vert (appdata_base v) {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.uv1 = TRANSFORM_TEX(v.texcoord, _MaskTex);
                return o;
            }

            half4 frag (v2f i) : COLOR {
                half4 albedo = tex2D (_MainTex, i.uv);
                half mask = tex2D (_MaskTex, i.uv1).r;
                half fadeMask = tex2D (_MaskTex, float2(0, _TimeSlider)).g;
                albedo.a *= mask * fadeMask;
                return albedo;
            }
            ENDCG

        }
    }
    Fallback "VertexLit"
}
