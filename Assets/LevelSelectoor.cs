using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectoor : MonoBehaviour
{
    // Start is called before the first frame update

    public void levelLoad()
    {
        string objectName = gameObject.name;
        int objectName2 = int.Parse(objectName);
        SceneManager.LoadSceneAsync(objectName2 + 2);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
