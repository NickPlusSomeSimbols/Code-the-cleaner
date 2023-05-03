using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Vector2Int Size => _size;
    public Vector2Int Position { get; private set; }
    public Rotation Rotation { get; private set; }

    [SerializeField] private Vector2Int _size;

    public void Initialize(Vector2Int position, Rotation rotation)
    {
        Position = position;
        Rotation = rotation;
        
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, 90 * ((int)Rotation + 1), transform.localRotation.z);
    }

    public (Vector2Int, Vector2Int) SpaceOccupied()
    {
        int horizontalSign, verticalSign;
        
        switch (Rotation)
        {
            case Rotation.Right:
                horizontalSign = 1;
                verticalSign = 1;
                break;
            case Rotation.Down:
                horizontalSign = 1;
                verticalSign = -1;
                break;
            case Rotation.Left:
                horizontalSign = -1;
                verticalSign = -1;
                break;
            case Rotation.Up:
                horizontalSign = -1;
                verticalSign = 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (Rotation is Rotation.Left or Rotation.Right)
            return (Position, Position + new Vector2Int(verticalSign * Size.y, horizontalSign * Size.x));
        
        return (Position, Position + new Vector2Int(horizontalSign * Size.x, verticalSign * Size.y));
    }
}

public enum Rotation
{
    Right,
    Down,
    Left,
    Up
}