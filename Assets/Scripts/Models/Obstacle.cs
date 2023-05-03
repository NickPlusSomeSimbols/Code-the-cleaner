using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Obstacle
{
    public Vector2Int Position;
    public Rotation Rotation;
    public ObstacleController Prefab;
}
