Shader "Custom/Glow" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_GlowColor("Glow Color", Color) = (1,1,1,1)
		_GlowMultiplier ("Glow Multiplier", Range(0,1)) = 0.5
	}
	SubShader {
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		
		CGPROGRAM
		#pragma surface surf BlinnPhong alpha

		sampler2D _MainTex;

		struct Input {
			float3 viewDir;
		};

		float4 _Color;
		float4 _GlowColor;
		float _GlowMultiplier;

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color;
			half3 rim = 1.0 - dot(o.Normal, IN.viewDir);
			o.Emission = rim * _GlowMultiplier * _GlowColor;
			o.Alpha = rim;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
