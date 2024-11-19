using System;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct TeleportConfig : IBufferElementData
{
    public float3 TeleportPosition;
    public float MinHeightForTeleport;
    public float MaxHeightForTeleport;
}