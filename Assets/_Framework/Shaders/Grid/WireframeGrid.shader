// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/WireframeGrid" {
	Properties {
		_GridColor ("Grid Color", Color) = (1, 1, 1, 1)
		_BaseColor ("Base Color", Color) = (0, 0, 0, 0)
		_Thickness ("Thickness", Float) = 0.01
		_Spacing ("Spacing", Float) = 1.0
		_Fading ("Fading", 2D) = "white" {}
	}
	SubShader {
		Tags { "Queue" = "Transparent" }
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform float4 _GridColor;
			uniform float4 _BaseColor;
			uniform float _Thickness;
			uniform float _Spacing;
			uniform sampler2D _Fading;

			struct vertexInput {
				float4 vertex : POSITION;
				float2 uv_Fading : TEXCOORD0;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
				float2 fadingUV : TEXCOORD0;
				float4 worldPos : TEXCOORD1;
			};

			vertexOutput vert(vertexInput input) {
				vertexOutput output;

				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
				output.fadingUV = input.uv_Fading;//= TRANSFORM_TEX(input.uvFading, _Fading);
				output.worldPos = mul(unity_ObjectToWorld, input.vertex);

				return output;
			}

			float4 frag(vertexOutput input) : COLOR {
				float4 color;

				float fade = tex2D(_Fading, input.fadingUV).r;
				float xfrac = frac(input.worldPos.x / _Spacing);
				float zfrac = frac(input.worldPos.z / _Spacing);

				if(xfrac < _Thickness
				|| zfrac < _Thickness) {
					color = float4(_GridColor.r, _GridColor.b, _GridColor.a, fade.r);
				}
				else {
					color = _BaseColor;
				}

				return color;
			}

			ENDCG
		}
	}
}
