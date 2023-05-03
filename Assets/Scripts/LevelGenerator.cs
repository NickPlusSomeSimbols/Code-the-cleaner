
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;

    [SerializeField] private Grid _grid;
    [SerializeField] private GameObject _tile;
    [SerializeField] private GameObject _wall;

    private void Awake() => Instance = this;

    public void Generate(Level level)
    {
        GenerateTilesAndWalls(level.Size);
        GenerateObstacles(level.Obstacles);
    }

    private void GenerateTilesAndWalls(Vector2Int size)
    {
        for (int y = 0; y < size.y; ++y)
        {
            for (int x = 0; x < size.x; ++x)
            {
                if (x == 0)
                {
                    SpawnObject(_wall, new Vector2Int(x, y), Quaternion.Euler(-90, 0, 180));
                }
                else if (x == size.x - 1)
                {
                    SpawnObject(_wall, new Vector2Int(x + 1, y + 1), Quaternion.Euler(-90, 0, 0));
                }

                if (y == 0)
                {
                    SpawnObject(_wall, new Vector2Int(x + 1, y), Quaternion.Euler(-90, 0, 90));
                }
                else if (y == size.y - 1)
                {
                    SpawnObject(_wall, new Vector2Int(x, y + 1), Quaternion.Euler(-90, 0, -90));
                }

                SpawnObject(_tile, new Vector2Int(x, y), _tile.transform.localRotation);
            }
        }
    }

    private void GenerateObstacles(List<Obstacle> obstacles)
    {
        foreach (var obstacle in obstacles)
        {
            var c = SpawnObject(obstacle.Prefab.gameObject, obstacle.Position, Quaternion.identity, obstacle.Prefab.Position.y).GetComponent<ObstacleController>();
            c.Initialize(obstacle.Position, obstacle.Rotation);
            var spaceOccupied = c.SpaceOccupied();

            for (int i = spaceOccupied.Item1.y; i < spaceOccupied.Item2.y; i += (int) Mathf.Sign(spaceOccupied.Item2.y - spaceOccupied.Item1.y))
            {
                for (int j = spaceOccupied.Item1.x; j < spaceOccupied.Item2.x; j += (int) Mathf.Sign(spaceOccupied.Item2.x - spaceOccupied.Item1.x))
                {
                    GameManager.Instance.WriteMap(i, j, GameManager.GridContents.Obstacle);
                }
            }
        }
    }

    private GameObject SpawnObject(GameObject obj, Vector2Int pos, Quaternion rot, float yOffset = 0)
    {
        var position = _grid.CellToWorld(new Vector3Int(pos.x, pos.y, 0));
        position.y += yOffset;
        return Instantiate(obj, position, rot, _grid.transform);
    }
}