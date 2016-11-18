Shader "Custom/BaseDiffuseOutline" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_HeightMap("Height Map", 2D) = "black" {}
		_HeightMultiplier("Height Multiplier", Float) = 1
		_Outline("Outline Width", Float) = 0.01
		_OutlineColor("Outline Color", Color) = (0,0,0,0)
	}
	SubShader {
		Tags{ "RenderType" = "Opaque" }

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

		float4 _Color;
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

		Cull Front
		CGPROGRAM
		#pragma surface surf NoLighting vertex:vert noforwardadd
		struct appdata {
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
			float3 normal : NORMAL;
		};
		struct Input {
			float2 screenPos;
		};

		sampler2D _HeightMap;
		float4 _HeightMap_ST;
		float _HeightMultiplier;
		float _Outline;
		fixed4 _OutlineColor;

		void vert(inout appdata v) {
			v.vertex.xyz += v.normal * tex2Dlod(_HeightMap, float4(v.uv.xy / _HeightMap_ST.xy + _HeightMap_ST.zw * 0.01, 0, 0)).r * _HeightMultiplier;
			v.vertex.xyz += v.normal * _Outline * 0.001;
		}
		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = _OutlineColor.rgb;
			o.Alpha = _OutlineColor.a;
		}
		fixed4 LightingNoLighting(SurfaceOutput o, fixed3 lightDir, fixed atten) {
			return (o.Albedo, o.Alpha);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
