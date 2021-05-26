Shader "CustomShaders/MeNewShader"
{
	Properties
	{
		_MainTexture("Texture", 2D) = "white"{}
		_Color("Color", Color) = (1,1,1,1)
		_WaveSpeed("Wave Speed", Float) = 5.0
		_WaveOffsetSize("Wave Size", Float) = 5.0
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM

			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction

			#include "UnityCG.cginc"

			struct MeshData
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			fixed4 _Color;
			sampler2D _MainTexture;
			float _WaveSpeed;
			float _WaveOffsetSize;

			v2f vertexFunction(MeshData IN)
			{
				v2f OUT;
				
				IN.vertex.x += sin(_Time.y * _WaveSpeed + IN.vertex.y * _WaveOffsetSize);

				OUT.position = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			fixed4 fragmentFunction(v2f IN) : SV_Target
			{
				fixed4 pixelColor = tex2D(_MainTexture, IN.uv);

				pixelColor *= _Color;

				return pixelColor;
			}

			ENDCG
		}
	}
}