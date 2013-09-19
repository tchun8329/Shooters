float4x4 World;
float4x4 View;
float4x4 Projection;
float3 CameraPosition;
texture CubeMap;
float4 ClipPlane;
bool ClipPlaneEnabled = false;

samplerCUBE CubeMapSampler = sampler_state {
	texture = <CubeMap>;
	minfilter = anisotropic;
	magfilter = anisotropic;
};
struct VertexShaderInput
{
	float4 Position : POSITION0;
};
struct VertexShaderOutput
{
	float4 Position : POSITION0;
	float3 WorldPosition : TEXCOORD0;
};
VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
	VertexShaderOutput output;
	float4 worldPosition = mul(input.Position, World);
	output.WorldPosition = worldPosition;
	output.Position = mul(worldPosition, mul(View, Projection));
	return output;
}
float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	if (ClipPlaneEnabled)
		clip(dot(float4(input.WorldPosition, 1), ClipPlane));
	float3 viewDirection = normalize(input.WorldPosition -
		CameraPosition);
	return texCUBE(CubeMapSampler, viewDirection);
}
technique Technique1
{
	pass Pass1
	{
		// We're drawing the inside of a model
		CullMode = None;  
        // We don't want it to obscure objects with a Z < 1
        ZWriteEnable = false; 
		VertexShader = compile vs_2_0 VertexShaderFunction();
		PixelShader = compile ps_2_0 PixelShaderFunction();
	}
}
