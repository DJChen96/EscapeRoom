// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DoubleFace"
{
    Properties 
    {        
        _FrontTex ("Front (RGB)", 2D) = "white" { }                            
        _BackTex ("Back (RGB)", 2D) = "white" { }
    }
    SubShader 
    { 
        Lighting Off                                                                 
        Blend SrcAlpha OneMinusSrcAlpha           
        Pass 
        { 
                Cull Back  
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                  
                #include "UnityCG.cginc"
                sampler2D _FrontTex;
                struct v2f 
                {
                    float4  pos : SV_POSITION;
                    float2  uv : TEXCOORD0;
                };
                  
                float4 _FrontTex_ST;
                  
                v2f vert (appdata_base v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos (v.vertex);
                    o.uv = TRANSFORM_TEX (v.texcoord, _FrontTex);
                    return o;
                }
                  
                half4 frag (v2f i) : COLOR
                { 
                      return tex2D (_FrontTex, i.uv);
                }
                  
                ENDCG
        }
        Pass 
        { 
            Cull Front
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
              
            #include "UnityCG.cginc"
            sampler2D _BackTex;
            struct v2f
            {
                float4  pos : SV_POSITION;
                float2  uv : TEXCOORD0;
            };
              
            float4 _BackTex_ST;
              
            v2f vert (appdata_base v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos (v.vertex);
                o.uv = TRANSFORM_TEX (v.texcoord, _BackTex);
                return o;
            }
              
            half4 frag (v2f i) : COLOR
            {  
                return tex2D (_BackTex, float2(1-i.uv.x,i.uv.y));
            }
            ENDCG
            }
        }
}