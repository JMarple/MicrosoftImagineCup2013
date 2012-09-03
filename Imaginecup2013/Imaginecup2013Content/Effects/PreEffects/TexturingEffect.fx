#include "EffectVar.fxh"
#include "DepthEffect.fxh"

/** Vertex Shader **/
VertexShaderOutput SimpleVertex( float4 inPos : POSITION0, float3 inNormal: NORMAL0, float2 inTexCoords : TEXCOORD0)
{
    VertexShaderOutput output;

    float4 worldPosition = mul(inPos, World);
    float4 viewPosition = mul(worldPosition, View);
	float4x4 preWorldViewProjection = mul(World, View);

    output.Position = mul(viewPosition, Projection);
	output.TexCoords = inTexCoords;
	output.Normal = normalize(mul(inNormal, (float3x3)World));  
	output.Position3D = mul(inPos, World);
    return output;
}

/** Pixel Shader **/
float4 SimplePixel(VertexShaderOutput input) : COLOR0
{    
	//Get Texture
	float4 texColor = tex2D(textureSampler, input.TexCoords);	
	
	//Get Diffuse Lighting
	float diffuseLightingFactor = DotProduct(lightPosition, input.Position3D, input.Normal);
   
	return texColor*(diffuseLightingFactor+Ambient);
}

/** Technique Simple **/
technique Main
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 SimpleVertex();
        PixelShader = compile ps_2_0 SimplePixel();
    }
}
