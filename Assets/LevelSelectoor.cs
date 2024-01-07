using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectoor : MonoBehaviour
{
    // Start is called before the first frame update

    public void levelLoad()
    {
        SceneManager.LoadSceneAsync(3);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
