Shader "HOG/FxEnergyShield" {
    Properties {
		_MainTex ("Main Tex", 2D) = "white" {}
        _RimColor ("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower01 ("Rim Power01", Range (0, 1)) = 0.0
		_RimWidth ("Rim Width", Range (0.1, 1)) = 0.7
		_HitPoint ("Hit", Vector) = (0, 0, 0, 0)
		_Magnitude ("Magnitude", Float) = 1500
    }
    
    SubShader {
		Tags { "Queue" = "Transparent" }
		ZWrite Off
		//Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
        
		Pass {
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

				uniform sampler2D _MainTex;
                uniform float4 _MainTex_ST;
                uniform half4 _RimColor;
				uniform fixed _RimPower01;
				uniform half _RimWidth;
				uniform float4 _HitPoint;
				uniform float _Magnitude;
                
                struct v2f {
                    float4 pos : SV_POSITION;
                    half4 color : COLOR;
					fixed2 texcoord : TEXCOORD0;
					float2 worldPos : TEXCOORD1;
                };
                
                v2f vert (appdata_base v) {
                    v2f o;
					o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
					o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex) + fixed2(_Time.y*0.25f, 0);
					o.color = _RimColor * smoothstep(1.0 - _RimWidth, 1.0, 1.1 - dot(v.normal, normalize(ObjSpaceViewDir(v.vertex))));
					//o.color = _RimColor;
					if (_RimPower01 > 0) {
						o.worldPos = mul(_Object2World, v.vertex).xy;
					} else {// zeroing
						o.worldPos = float2(0, 0);
					}
                    return o;
                }
                
                float4 frag(v2f i) : COLOR {
					float4 texcol = tex2D(_MainTex, i.texcoord);
					texcol *= i.color;
					if (_RimPower01 > 0) {
						float2 v = i.worldPos.xy - _HitPoint.xy;
						float magnitude = dot(v, v);
						if (magnitude <= _Magnitude) {
							fixed d = (1.0 - magnitude / _Magnitude);
							half h= lerp(1.0, 40.0, d * _RimPower01);
							//fixed4 cc = lerp(texcol, _RimColor,(d)*_RimPower01);
							//texcol =texcol+ cc*h;
							texcol *= h;
						}
					}
					return texcol;
				}
            ENDCG
		}
	}
}