using System.Threading.Tasks;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class CyclicJobProcessor : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    [SerializeField] private float _logarithmCooldown;
    [SerializeField] private float _minLogValue;
    [SerializeField] private float _maxLogValue;
    [SerializeField] private Vector3 _axis;
    [SerializeField] private int _spawnCount;

    private Transform[] _transforms;
    private TransformAccessArray _transformAccessArray;

    private NativeArray<int> _numberForLogs;

    private void Start()
    {
        _transforms = new Transform[_spawnCount];
        for (int i = 0; i < _spawnCount; i++)
        {
            Transform instanceTransform = Instantiate(_prefab, Random.insideUnitSphere * _radius, Quaternion.identity).transform;
            _transforms[i] = instanceTransform;
        }

        _transformAccessArray = new TransformAccessArray(_transforms);
        _numberForLogs = new NativeArray<int>(_spawnCount, Allocator.Persistent);

        LogarithmLoop();
    }

    private void Update()
    {
        HandleMovementJob();
    }

    private async Task LogarithmLoop()
    {
        while (true)
        {
            HandleLogarithmJob();
            await Task.Delay((int)(_logarithmCooldown * 1000));
        }
    }

    private void HandleLogarithmJob()
    {
        LogarithmJob logJob = new LogarithmJob(Random.Range(_minLogValue, _maxLogValue));
        JobHandle jobHandle = logJob.Schedule(_transformAccessArray);
    }

    private void HandleMovementJob()
    {
        CyclicMovementJob movementJob = new CyclicMovementJob(_speed, Time.deltaTime, _axis);
        JobHandle jobHandle = movementJob.Schedule(_transformAccessArray);
    }


    private void OnDestroy()
    {
        _transformAccessArray.Dispose();
        _numberForLogs.Dispose();
    }
}