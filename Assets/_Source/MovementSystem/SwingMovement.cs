using System;
using UnityEngine;

namespace MovementSystem
{
    [Serializable]
    public struct SwingMovement
    {
        public float MoveSpeed;
        public float SwingAmplitude;
        public Vector3 Direction;
    }
}