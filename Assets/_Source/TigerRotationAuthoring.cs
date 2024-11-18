using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TigerRotationAuthoring : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotationAxis;

    private class Baker : Baker<TigerRotationAuthoring>
    {
        public override void Bake(TigerRotationAuthoring rotationAuthoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new TigerRotation
            {
                Speed = rotationAuthoring._speed, 
                RotationAxis = rotationAuthoring._rotationAxis
            });
        }
    }
}

public struct TigerRotation : IComponentData
{
    public float Speed;
    public float3 RotationAxis;
}