Shader "Unlit/PostProcessing"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Rows("Number of Rows", int) = 128
        _Columns("Number of Columns", int) = 128
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Rows;
            float _Columns;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;
                /// Map [0...1] to [0..._Columns]
                uv.x *= _Columns;
                uv.y *= _Rows;

                /// Round to the whole number. This will squash the pixels; eliminate the details
                uv = round(uv);

                /// Map [0..._Columns] back to [0...1]
                uv.x /= _Columns;
                uv.y /= _Rows;

                fixed4 color = tex2D(_MainTex, uv);
                return color;
            }
            ENDCG
        }
    }
}
