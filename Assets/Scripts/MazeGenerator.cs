using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell _mazeCellPrefab;

    [SerializeField]
    private int _mazeWidth;

    [SerializeField]
    private int _mazeHeight;

    [SerializeField]
    private int _seed;

    [SerializeField]
    private bool _useSeed;

    private MazeCell[,] _mazeGrid;

    private Camera mainCamera;

    void Start()
    {
        if(_useSeed)
        { 
            Random.InitState(_seed);
        }
        else
        {
            int randomSeed = Random.Range(1, 1000000);
            Random.InitState(randomSeed);

            Debug.Log(randomSeed);
        }

        _mazeGrid = new MazeCell[_mazeWidth, _mazeHeight];

        for (int x = 0; x < _mazeWidth; x++)
        {
            for (int y = 0; y < _mazeHeight; y++)
            {
                _mazeGrid[x, y] = Instantiate(_mazeCellPrefab, new Vector3(x, y, 0), Quaternion.identity );
            }
        }

        GenerateMaze(null, _mazeGrid[0, 0]);

        mainCamera = Camera.main;

        mainCamera.orthographicSize = _mazeHeight / 2f;

        mainCamera.aspect = (float)_mazeWidth / _mazeHeight;


        Vector3 mazeGeneratorPosition = transform.position;
        Vector3 cameraPosition = new Vector3(mazeGeneratorPosition.x + _mazeWidth / 2f, mazeGeneratorPosition.y + _mazeHeight / 2f, -10f);

        mainCamera.transform.position = cameraPosition;
    }
    public Bounds CalculateMazeBounds()
    {
        float minX = float.MaxValue;
        float minY = float.MaxValue;
        float maxX = float.MinValue;
        float maxY = float.MinValue;

        foreach (MazeCell cell in _mazeGrid)
        {
            Vector3 cellPosition = cell.transform.position;

            minX = Mathf.Min(minX, cellPosition.x);
            minY = Mathf.Min(minY, cellPosition.y);
            maxX = Mathf.Max(maxX, cellPosition.x);
            maxY = Mathf.Max(maxY, cellPosition.y);
        }

        return new Bounds(new Vector3((minX + maxX) / 2f, (minY + maxY) / 2f, 0f), new Vector3(maxX - minX, maxY - minY, 0f));
    }


    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        clearWalls(previousCell, currentCell);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }
    
    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedWalls(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedWalls(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int y = (int)currentCell.transform.position.y;

        if (x + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 1, y];

            if(cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if(x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, y];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }        
        }

        if (y + 1 < _mazeHeight)
        {
            var cellToUp = _mazeGrid[x, y + 1];
            
            if (cellToUp.IsVisited == false) 
            { yield return cellToUp; }
        }

        if (y - 1 >= 0)
        {
            var cellToLow = _mazeGrid[x, y-1];

            if (cellToLow.IsVisited == false)
            { 
                yield return cellToLow; 
            }
        }
    }

    private void clearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if(previousCell == null)
        {
            return; 
        }
        if (previousCell.transform.position.x < currentCell.transform.position.x) 
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }
        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }
        if (previousCell.transform.position.y < currentCell.transform.position.y)
        {
            previousCell.ClearUpperWall();
            currentCell.ClearLowerWall();
            return;
        } 
        if (previousCell.transform.position.y > currentCell.transform.position.y)
        {
            previousCell.ClearLowerWall();
            currentCell.ClearUpperWall();
            return;
        }

    }
    void Update()
    {
        
    }
}
