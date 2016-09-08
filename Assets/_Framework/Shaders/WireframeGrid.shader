// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/WireframeGrid" {
	Properties {
		_GridColor ("Grid Color", Color) = (1, 1, 1, 1)
		_BaseColor ("Base Color", Color) = (0, 0, 0, 0)
		_Thickness ("Thickness", Float) = 0.01
		_Spacing ("Spacing", Float) = 1.0
	}
	SubShader {
		Tags { "Queue" = "Transparent" }
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			uniform float4 _GridColor;
			uniform float4 _BaseColor;
			uniform float _Thickness;
			uniform float _Spacing;

			struct vertexInput {
				float4 vertex : POSITION;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
				float4 worldPos : TEXCOORD0;
			};

			vertexOutput vert(vertexInput input) {
				vertexOutput output;

				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
				output.worldPos = mul(unity_ObjectToWorld, input.vertex);

				return output;
			}

			float4 frag(vertexOutput input) : COLOR {
				float4 color;
				if(frac(input.worldPos.x / _Spacing) < _Thickness 
				|| frac(input.worldPos.z / _Spacing) < _Thickness) {
					color = _GridColor;
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
