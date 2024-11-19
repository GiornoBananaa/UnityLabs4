using Leopotam.EcsLite;
using UnityEngine;

namespace CountingSystem
{
    public class CounterSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsPool<UpdateCounterComponent> _counters;
        
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<UpdateCounterComponent>().End();
            _counters = world.GetPool<UpdateCounterComponent>();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref UpdateCounterComponent counter = ref _counters.Get(entity);
                counter.Count++;
            }
        }
    }
}