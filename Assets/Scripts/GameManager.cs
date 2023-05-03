using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int CurrentLevel;

    [SerializeField] private Levels _levels;
    
    private List<List<GridContents>> _map;

    private void Awake()
    {
        Instance = this;
        Initialize();
    }
    
    private void Initialize()
    {
        _map = new List<List<GridContents>>();
        var level = _levels.LevelList[CurrentLevel];

        for (int i = 0; i < level.Size.y; ++i)
        {
            _map.Add(new List<GridContents>());
            
            for (int j = 0; j < level.Size.x; ++j)
            {
                _map[i].Add(GridContents.Empty);
            }
        }
    }

    private void Start()
    {
        LevelGenerator.Instance.Generate(_levels.LevelList[0]);
    }

    public GridContents ReadMap(int y, int x) => _map[y][x];
    
    public void WriteMap(int y, int x, GridContents val) => _map[y][x] = val;

    public enum GridContents
    {
        Empty,
        Trash,
        Obstacle
    }
}
