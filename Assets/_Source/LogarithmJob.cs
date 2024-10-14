using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public struct LogarithmJob : IJobParallelForTransform
{
    public float _value;

    public LogarithmJob(float value)
    {
        _value = value;
    }

    public void Execute(int index, TransformAccess transform)
    {
        Debug.Log(Mathf.Log(_value));
    }
}