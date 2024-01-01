using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class CharacterDeath : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        StartCoroutine(LoadLevel(2));
    }
    
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Death");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
    
}
