using Leopotam.EcsLite;
using MovementSystem;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace CountingSystem
{
    public class ECSStarter : MonoBehaviour
    {
        private EcsWorld _defaultWorld;
        private EcsSystems _systems;
        
        private void Start() 
        {
            _defaultWorld = new EcsWorld();    
            _systems = new EcsSystems(_defaultWorld);
            _systems.ConvertScene();
            _systems.Add(new CounterSystem());
            _systems.Add(new SwingMovementSystem());
            _systems.Init(); 
        }

        private void Update()
        {
            _systems?.Run();
        }
        
        private void OnDestroy () 
        {
            _systems?.Destroy();
            _defaultWorld?.Destroy();
            _systems = null;
            _defaultWorld = null;
        }
    }
}