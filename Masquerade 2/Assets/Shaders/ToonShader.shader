Shader "MyShaders/ToonShader"
/*https:// roystan.net / articles / toon-shader . html*/
{
	Properties
	{
		_MainTex("Texture", 2D) = "grey" {}
		[HDR]
		_AmbientColor("Ambient Color", Color) = (0.4,0.4,0.4,1)
		_SpecularColor("Specular Color", Color) = (0.9,0.9,0.9,1)
		_Glossiness("Glossiness", Float) = 32
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimAmount("Rim Amount", Range(0, 1)) = 0.716
		
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{

			Tags
			{
				"LightMode" = "ForwardBase"
				"PassFlags" = "OnlyDirectional"
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
		// make fog work
		#pragma multi_compile_fog


		#include "UnityCG.cginc"
		#include "Lighting.cginc"

		struct appdata
		{
			
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
			float3 normal : NORMAL;
			
		};

		struct v2f
		{
			
			float2 uv : TEXCOORD0;
			UNITY_FOG_COORDS(1)
			float4 vertex : SV_POSITION;
			float3 worldNormal : NORMAL;
			float3 viewDir : TEXCOORD1;
		};

		sampler2D _MainTex;
		float4 _MainTex_ST;
		float _Glossiness;
		float4 _SpecularColor;
		float4 _RimColor;
		float _RimAmount;

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv = TRANSFORM_TEX(v.uv, _MainTex);
			UNITY_TRANSFER_FOG(o,o.vertex);
			o.worldNormal = UnityObjectToWorldNormal(v.normal);
			o.viewDir = WorldSpaceViewDir(v.vertex);
			return o;
		}

		float4 _AmbientColor;
		fixed4 frag(v2f i) : SV_Target
		{

			float3 normal = normalize(i.worldNormal);
			float NdotL = dot(_WorldSpaceLightPos0, normal);
			float lightIntensity = smoothstep(0, 0.01, NdotL);
			float4 light = lightIntensity * _LightColor0;

			float3 viewDir = normalize(i.viewDir);

			float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
			float NdotH = dot(normal, halfVector);

			float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);

			float4 rimDot = 1 - dot(viewDir, normal);
			float rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimDot);
			float4 rim = rimIntensity * _RimColor;

			// sample the texture
			fixed4 col = tex2D(_MainTex, i.uv);
			// apply fog
			UNITY_APPLY_FOG(i.fogCoord, col);
			float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
			float4 specular = specularIntensitySmooth * _SpecularColor;

			return col * (_AmbientColor + light + specular + rim);
		}
		ENDCG
	}
	}
}