Shader "Hidden/PSXDither"
{
    //Dean's shitty psx shader
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _dPower("Dither Power", float) = 32
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            //dither table from PlayStation emulators
            static const float4x4 dither_table = float4x4
                (
                    -4.0, 0.0, -3.0, 1.0,
                    2.0, -2.0, 3.0, -1.0,
                    -3.0, 1.0, -4.0, 0.0,
                    3.0, -1.0, 2.0, -2.0
                    );
            sampler2D _MainTex;
            uniform float dPower;

            fixed4 frag(v2f i) : SV_TARGET
            {

            fixed4 col = tex2D(_MainTex,i.uv);
            int2 pp = i.uv * _ScreenParams.xy; //pixel position lookup integer
            col += dither_table[pp.y % 4][pp.x % 4] * (1 / dPower);
            return col;
            }
            ENDCG
        }
    }
}
