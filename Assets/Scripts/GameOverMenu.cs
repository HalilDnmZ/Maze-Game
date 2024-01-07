using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public DeathAnimation death;

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void ReplayLevel()
    {
        int lastValue = PlayerPrefs.GetInt("lastValue");
        SceneManager.LoadSceneAsync(lastValue);
    }
    public void QuitGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
