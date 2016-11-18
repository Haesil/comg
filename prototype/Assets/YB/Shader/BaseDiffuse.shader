Shader "Custom/BaseDiffuse" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_HeightMap("Height Map", 2D) = "black" {}
		_HeightMultiplier ("Height Multiplier", Float) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Cull Back
			CGPROGRAM
		#pragma surface surf BlinnPhong vertex:vert
		struct appdata {
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
			float3 normal : NORMAL;
		};
		struct Input {
			float dummy;
		};

		fixed4 _Color;
		sampler2D _HeightMap;
		float4 _HeightMap_ST;
		float _HeightMultiplier;

		void vert(inout appdata v) {
			v.vertex.xyz += v.normal * tex2Dlod(_HeightMap, float4(v.uv.xy * _HeightMap_ST.xy + _HeightMap_ST.zw * 0.01, 0, 0)).r * _HeightMultiplier;
		}
		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
