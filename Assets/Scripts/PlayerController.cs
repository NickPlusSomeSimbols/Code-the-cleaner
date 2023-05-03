using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public Vector2Int Coordinates { get; private set; }

    public event Action OnCommandCompleted;

    [SerializeField] private Transform _cleaner;
    [SerializeField] private Grid _grid;
    [SerializeField] private float _commandTime;

    private void Awake()
    {
        Instance = this;
    }

    public void MoveForward()
    {
        //TODO: for some reason transform.forward is not working
        //var forward = new Vector3Int(Mathf.RoundToInt(_cleaner.forward.x), Mathf.RoundToInt(_cleaner.forward.y), Mathf.RoundToInt(_cleaner.forward.z));
        
        var forward = GetForwardVector();
        transform.DOMove(transform.position + _grid.CellToWorld(forward), _commandTime).OnComplete(() => OnCommandCompleted?.Invoke());
    }

    public void RotateRight() => _cleaner.DOLocalRotate(new Vector3(-90, _cleaner.localRotation.eulerAngles.y + 90, 0), _commandTime).OnComplete(() => OnCommandCompleted?.Invoke());

    public void RotateLeft() => _cleaner.DOLocalRotate(new Vector3(-90, 0, _cleaner.localRotation.eulerAngles.z - 90), _commandTime).OnComplete(() => OnCommandCompleted?.Invoke());

    private Vector3Int GetForwardVector()
    {
        if(Math.Abs(_cleaner.localRotation.eulerAngles.y - 90) % 360 < 1)
            return Vector3Int.left;
        if(Math.Abs(_cleaner.localRotation.eulerAngles.y - 180) % 360 < 1)
            return Vector3Int.up;
        if(Math.Abs(_cleaner.localRotation.eulerAngles.y - 270) % 360 < 1)
            return Vector3Int.right;
        
        return Vector3Int.down;
    }
}