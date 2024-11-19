using Leopotam.EcsLite;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace CountingSystem
{
    public class ECSStarter : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        
        private void Start() 
        {
            _world = new EcsWorld();    
            _systems = new EcsSystems(_world);
            _systems.ConvertScene()
                .Add(new CounterSystem())
                .Init(); 
        }

        private void Update()
        {
            _systems?.Run();
        }
        
        private void OnDestroy () 
        {
            _systems?.Destroy();
            _world?.Destroy();
            _systems = null;
            _world = null;
        }
    }
}