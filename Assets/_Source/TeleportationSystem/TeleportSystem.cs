using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public partial struct TeleportSystem : ISystem
{
    private const float _teleportHeight = 0f;
    private Vector3 _upperDimensionCenter;
    private float3 _lowerDimensionCenter;

    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<TigerTeleportation>();
        _upperDimensionCenter = new Vector3(5f, 0f, 0f);
        _lowerDimensionCenter = new Vector3(-5f, 0f, 0f);
    }
    
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        TeleportJob movementJob = new TeleportJob(_teleportHeight, _lowerDimensionCenter, _upperDimensionCenter);
        movementJob.ScheduleParallel();
    }
}