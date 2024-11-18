using Unity.Burst;
using Unity.Entities;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderFirst = true)]
public partial struct CyclicMovementSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<TigerRotation>();
    }
    
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        CyclicMovementJob movementJob = new CyclicMovementJob()
        {
            DeltaTime = SystemAPI.Time.DeltaTime
        };
        movementJob.ScheduleParallel();
    }
}