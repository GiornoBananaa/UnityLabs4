using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnConfigAuthoring : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _center;
    [SerializeField] private float _radius;
    [SerializeField] private int _spawnCount;

    private class Baker : Baker<SpawnConfigAuthoring>
    {
        public override void Bake(SpawnConfigAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new SpawnConfig
            {
                Prefab = GetEntity(authoring._prefab,TransformUsageFlags.Dynamic),
                Center = authoring._center,
                Radius = authoring._radius,
                SpawnCount = authoring._spawnCount,
            });
        }
    }
}