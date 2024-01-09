using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastPortal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision2)
    {
        if (collision2.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
