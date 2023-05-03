using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    public Vector2Int Size;
    public Vector2Int StartPosition;
    public List<Obstacle> Obstacles;
}
