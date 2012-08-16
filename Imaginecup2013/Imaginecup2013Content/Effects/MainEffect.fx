/** Global Variables **/
float4x4 World;
float4x4 View;
float4x4 Projection;
float Ambient = 0.2;

/** Functions **/
float DotProduct(float3 lightPos, float3 pos3D, float3 normal)
{
    float3 lightDir = normalize(pos3D - lightPos);
    return dot(-lightDir, normal);
}

/** Input/Ouput Structures **/
struct VertexShaderInput
{
    float4 Position : POSITION0;	
};

struct VertexShaderOutput
{
    float4 Position : POSITION0;
	float2 TexCoords : TEXCOORD0;
	float3 Normal : TEXCOORD1;
	float3 Position3D : TEXCOORD2;
};

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
	//Light Position in the world
    float3 LightPosition = float3(0, 30, 0);

	//Set color of specific pixel (too be changed to a texture)
	float4 baseColor = float4(0.5, 0.5, 0.5, 1);
	
	//Get Diffuse Lighting
	float diffuseLightingFactor = DotProduct(LightPosition, input.Position3D, input.Normal);
   
	return baseColor*(diffuseLightingFactor+Ambient);
}

/** Technique Simple **/
technique Simple
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 SimpleVertex();
        PixelShader = compile ps_2_0 SimplePixel();
    }
}
