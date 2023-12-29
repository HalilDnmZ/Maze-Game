using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 5 / 2f;

        mainCamera.aspect = (float)5 / 3;


        Vector3 mazeGeneratorPosition = transform.position;
        Vector3 cameraPosition = new Vector3(mazeGeneratorPosition.x + 5 / 2f, mazeGeneratorPosition.y + 3 / 2f, -10f);

        mainCamera.transform.position = cameraPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
