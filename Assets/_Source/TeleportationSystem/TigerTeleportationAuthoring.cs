using Unity.Entities;
using UnityEngine;


public class TigerTeleportationAuthoring : MonoBehaviour
{
    private class Baker : Baker<TigerTeleportationAuthoring>
    {
        public override void Bake(TigerTeleportationAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity, new TigerTeleportation());
        }
    }
}