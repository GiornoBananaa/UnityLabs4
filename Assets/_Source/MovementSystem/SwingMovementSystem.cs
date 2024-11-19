using Leopotam.EcsLite;
using UnityEngine;

namespace MovementSystem
{
    public class SwingMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsPool<SwingMovement> _movements;
        private EcsPool<TransformComponent> _transformComponents;
        
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<SwingMovement>().Inc<TransformComponent>().End();
            _movements = world.GetPool<SwingMovement>();
            _transformComponents = world.GetPool<TransformComponent>();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref SwingMovement movement = ref _movements.Get(entity);
                ref TransformComponent transformComponent = ref _transformComponents.Get(entity);
                transformComponent.Transform.position += movement.Direction * (movement.MoveSpeed * Time.deltaTime);
                if(transformComponent.Transform.position.x > movement.SwingAmplitude && movement.Direction.x > 0 
                   || transformComponent.Transform.position.x < -movement.SwingAmplitude && movement.Direction.x < 0)
                    movement.Direction = new Vector3(movement.Direction.x * -1, movement.Direction.y, movement.Direction.z);
            }
        }
    }
}