using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [SerializeField] private int depth;
    [SerializeField] private Tile tilePrefab;
    private Dictionary<Vector2, Tile> tileArray;

    private void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        tileArray = new Dictionary<Vector2, Tile>();
        int height = 2 * depth - 1;
        int[] widths = new int[height];
        double[] startX = new double[height];

        for (int i = 0; i < depth; i++)
        {
            widths[i] = depth + i;
            startX[i] = 0 - 0.5 * i;
        }
        for(int j = 0; j < depth-1; j++)
        {
            widths[depth + j] = 2 * depth - j-2;
            startX[depth + j] = startX[depth + j - 1] + 0.5;
        }

        Debug.Log(printArray(startX));

        for (int i = 0; i < height; i++)
        {
            for(int j = 0; j < widths[i]; j++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3((float)startX[i] + j, -(float)Math.Sqrt(3) * i/2), Quaternion.identity);
                spawnedTile.name = $"Tile {i} {j}";
                spawnedTile.Init(0);
                tileArray.Add(new Vector2(i, j), spawnedTile);
            }
        }
        GameManager.Instance.ChangeState(GameState.SpawnUnits);
    }

    string printArray(double[] arr)
    {
        string res = "";
        foreach (var item in arr)
        {
            res = res + item.ToString();
        }
        return res;
    }

    public Tile getTile(Vector2 vec)
    {
        if(tileArray.TryGetValue(vec, out var tile))
        {
            return tile;
        }
        return null;
    }
}
