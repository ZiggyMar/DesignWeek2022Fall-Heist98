﻿Shader "Hidden/CustomColorDepth"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        //_AdvancedModeOn("Advanced Mode On", float) = 0
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

            uniform int cDepth;
            sampler2D _MainTex;

            uniform float _AdvancedModeOn;
            uniform int advR;
            uniform int advG;
            uniform int advB;

            fixed4 frag(v2f i) : SV_Target
            {
            fixed4 col = tex2D(_MainTex, i.uv);

            if (_AdvancedModeOn == 1) {
                col.r = round(col.r * advR) / advR;
                col.g = round(col.g * advG) / advG;
                col.b = round(col.b * advB) / advB;
            }
            else {
                col = round(col * cDepth) / cDepth;
            }

            
            return col;
            }
            ENDCG
        }
    }
}
