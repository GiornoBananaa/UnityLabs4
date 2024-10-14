using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Jobs;

public struct CyclicMovementJob : IJobParallelForTransform
{
    public float _speed;
    public float _deltaTime;
    public Vector3 _axis;

    public CyclicMovementJob(float speed, float deltaTime, Vector3 axis)
    {
        _speed = speed;
        _deltaTime = deltaTime;
        _axis = axis;
    }

    public void Execute(int index, TransformAccess transform)
    {
        transform.position = Quaternion.AngleAxis(_deltaTime * _speed, _axis) * transform.position;
    }
}
