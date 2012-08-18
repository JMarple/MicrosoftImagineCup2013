/** Global Variables **/
float4x4 World;
float4x4 View;
float4x4 Projection;
float Ambient = 0.2;

Texture tex;
sampler textureSampler = sampler_state{ texture = <tex> ; magfilter = LINEAR; minfilter = LINEAR; mipfilter=LINEAR; AddressU = mirror; AddressV = mirror;};

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
