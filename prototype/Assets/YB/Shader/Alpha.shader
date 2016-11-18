Shader "Custom/Alpha" {
	Properties{
		[NoScaleOffset]_AlphaTex("Alpha Texture", 2D) = "white" {}
		_TilingX("Texture Tiling X", Float) = 1.0
		_TilingY("Texture Tiling Y", Float) = 1.0
		_OpaqueColor("Opaque Color", Color) = (1,1,1,1)
		_TransparentColor("Transparent Color", Color) = (1,1,1,1)
		_AlphaThreshold("Alpha Threshold", Range(0, 1)) = 0.8
		_Transparency("Transparency", Range(0, 1)) = 0.5
	}
		SubShader{
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }

		CGPROGRAM
		#pragma surface surf BlinnPhong alpha

		sampler2D _MainTex;

		struct Input {
			float2 uv_AlphaTex;
		};

		sampler2D _AlphaTex;
		float _TilingX, _TilingY;
		float4 _OpaqueColor;
		float4 _TransparentColor;
		float _AlphaThreshold;
		float _Transparency;

		void surf(Input IN, inout SurfaceOutput o) {
			half a = tex2D(_AlphaTex, float2(IN.uv_AlphaTex.x * _TilingX, IN.uv_AlphaTex.y * _TilingY) );
			if (a > _AlphaThreshold) {
				o.Albedo = _OpaqueColor;
				o.Emission = a * 0.5;
				o.Alpha = a;
			}
			else {
				o.Albedo = _TransparentColor;
				o.Alpha = 1.0 - _Transparency;
				o.Specular = 1.0;
			}
		}
		ENDCG
		}
		FallBack "Diffuse"
}
