using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct TeleportJob : IJobEntity
{
    private readonly float _teleportHeight;
    private readonly float3 _upperDimensionCenter;
    private readonly float3 _lowerDimensionCenter;

    public TeleportJob(float teleportHeight, float3 lowerDimensionCenter, float3 upperDimensionCenter)
    {
        _teleportHeight = teleportHeight;
        _lowerDimensionCenter = lowerDimensionCenter;
        _upperDimensionCenter = upperDimensionCenter;
        __TypeHandle = default;
    }

    private void Execute(ref LocalTransform transform, ref TigerTeleportation tigerTeleportation)
    {
        
        if (transform.Position.y > _teleportHeight && tigerTeleportation.DimensionID == 1)
        {
            transform.Position += _upperDimensionCenter;
            
            tigerTeleportation.DimensionID = 0;
        }
        else if (transform.Position.y < _teleportHeight && tigerTeleportation.DimensionID == 0)
        {
            transform.Position += _lowerDimensionCenter;
            
            tigerTeleportation.DimensionID = 1;
        }
    }
}