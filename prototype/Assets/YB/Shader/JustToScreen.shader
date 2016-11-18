Shader "Custom/JustToScreen" 
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white"
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			struct v2f {
				float2 uv : TEXCOORD0;
			};
			v2f vert(float4 vertex : POSITION, float2 uv : TEXCOORD0, out float4 outpos : SV_POSITION) {
				v2f o;
				outpos = mul(UNITY_MATRIX_MVP, vertex);
				o.uv = uv;
				return o;
			}
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Tiling;
			fixed4 frag(v2f i, UNITY_VPOS_TYPE screenpos : VPOS) : SV_TARGET {
				fixed4 o = tex2D(_MainTex, screenpos.xy * _MainTex_ST.xy * 0.001f + _MainTex_ST.zw);
				return o;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
