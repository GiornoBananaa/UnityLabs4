using Unity.Entities;
using Unity.Mathematics;

public struct TigerRotation : IComponentData
{
    public float Speed;
    public float3 RotationAxis;
}