using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class TigerSpawnSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<SpawnConfig>();
    }

    protected override void OnUpdate()
    {
        this.Enabled = false;

        SpawnConfig spawnConfig = SystemAPI.GetSingleton<SpawnConfig>();
        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(WorldUpdateAllocator);
        NativeArray<Entity> spawnedEntities = new NativeArray<Entity>(spawnConfig.SpawnCount, Allocator.Temp);
        entityCommandBuffer.Instantiate(spawnConfig.Prefab, spawnedEntities);
        
        foreach (var entity in spawnedEntities)
        {
            entityCommandBuffer.SetComponent(entity, new LocalTransform{
                Position = (Random.insideUnitSphere * spawnConfig.Radius) + (Vector3)spawnConfig.Center,
                Rotation =  Quaternion.identity,
                Scale = 1f
            });
        }
        entityCommandBuffer.Playback(EntityManager);
    }
}

