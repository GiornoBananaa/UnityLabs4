using Unity.Entities;
using Unity.Mathematics;

public struct SpawnConfig : IComponentData
{
    public Entity Prefab;
    public float3 Center;
    public float Radius;
    public int SpawnCount;
}