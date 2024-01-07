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
        SceneManager.LoadSceneAsync(objectName + 2);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
