using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftWall;

    [SerializeField]
    private GameObject _rightWall;

    [SerializeField]
    private GameObject _upperWall;

    [SerializeField]
    private GameObject _lowerWall;

    [SerializeField]
    private GameObject _unvisitedWall;

    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
        _unvisitedWall.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightWall.SetActive(false);
    }

    public void ClearUpperWall()
    {
        _upperWall.SetActive(false);
    }

    public void ClearLowerWall()
    {
        _lowerWall.SetActive(false);
    }
}
