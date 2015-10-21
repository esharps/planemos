Shader "Effects/Forcefield" {
	Properties {
		_FieldColor ("Field Color", Color) = (1.0, 1.0, 1.0, 1.0)

		_Sampler_A ("Sampler_A" ,2D) = "" {}
		_Sampler_B ("Sampler_B" ,2D) = "" {}

		_Pos_a ("Position", Vector) = (0.0, 0.0, 0.0, 0.0)		

		_MaskPower ("Mask Power", Range(0.01, 50.0)) = 1.0

		_Offset("Mesh offset", Range(0, 0.4)) = 0.02
	}
	Category {

		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		Cull Off Lighting Off
		Blend SrcAlpha One

		SubShader {	
			Pass {

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest

				#pragma target 3.0

				#include "UnityCG.cginc"				

				float4 _FieldColor;

				sampler2D _Sampler_A;
				sampler2D _Sampler_B;

				float4 _Sampler_A_ST;
				float4 _Sampler_B_ST;

				fixed4 _Pos_a;			

				float _MaskPower;
				float _Offset;

				struct a2v {					
					float4 vertex : POSITION;					
					float4 texcoord : TEXCOORD0;
					float4 normal : NORMAL;
				};

				struct v2f {
					float4 vertex : SV_POSITION;					
					float2 uv : TEXCOORD0;
					float4 vPos : TEXCOORD1;
				};

				 float2 uvPanner(float2 uv, float x, float y)
				{
					float t = _Time.x * 20.0;
					return float2(uv.x + x * t, uv.y + y * t);
				}
				
				inline float4 brightness(float4 v, float b)
				{
					return v + b;
				}

				inline float4 contrast(float4 v, float c)
				{
					return  c * (v - 0.5 ) + 0.5;
				}

				/// VERTEX

				v2f vert (a2v v)
				{
					v2f o;

					v.vertex.xyz += v.normal * _Offset;

					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vPos = v.vertex;

					o.uv = TRANSFORM_TEX ( v.texcoord, _Sampler_A );

					return o;
				}

				/// FRAGMENT

				fixed4 frag (v2f i) : COLOR
				{
					float uvTime = _Time * 10.0;

					float2 locUV1 = float2(i.uv.x - uvTime * 0.1, i.uv.y - uvTime * 0.25);
					float2 locUV2 = float2(i.uv.x + uvTime * 0.25, i.uv.y - uvTime * 0.1);
					
					float locTex1 = saturate(tex2D(_Sampler_A, locUV1).g * 1.5);
					float locTex2 = saturate(tex2D(_Sampler_A, locUV2).g * 2.0);
					float locTex3 = tex2D(_Sampler_A, i.uv).a; 

					float locCombine = saturate(contrast(brightness((locTex1 + locTex2).xxxx, 0.25), 2)) * locTex3;

					float locTex4 = tex2D(_Sampler_A, i.uv).b;

					locCombine = clamp(locCombine + locTex4, 0.0, 1.0);	

					float2 locUV3 = float2(i.uv.x, i.uv.y - uvTime * 0.25);

					float3 locTex5 = tex2D(_Sampler_B, locUV3) ;

					float3 locCombine2 = saturate((locTex5 * 2 - 1 + 0.03)) * locCombine;

					fixed4 field = float4(locCombine2.rg , 0,  1) * 0.5;

					float locTex6 = tex2D(_Sampler_A, uvPanner(i.uv, 0.03, -0.12).xy + field.xy);

					float locTex7 = tex2D(_Sampler_A, uvPanner(i.uv, -0.03, -0.185).xy + field.xy);

					float dist_a = distance(_Pos_a.xyz, i.vPos.xyz);				

					fixed4 mask_a = saturate(lerp(fixed4(1.0, 1.0 ,1.0, 1.0), fixed4(0.0, 0.0 ,0.0, 1.0), dist_a * _Pos_a.w ) * _Pos_a.w);			

					fixed4 subMask_a = saturate(lerp(fixed4(0.0, 0.0 ,0.0, 1.0), fixed4(0.5, 0.5 ,0.5, 1.0), _Pos_a.w * 0.5)) ;				

					fixed4 a = saturate(pow((subMask_a + mask_a) * 2 * mask_a , 3) + (subMask_a + mask_a) * 0.3);	

					fixed4 ff = pow(locTex2 * locTex1 * 2, _MaskPower) * (locTex6.xxxx + locTex7.xxxx);
					
					return clamp(_FieldColor *  (ff + locTex7 + locTex6) * a * 3, 0, 50);				
				}

				ENDCG 
			}

		}
	} 
	
}
