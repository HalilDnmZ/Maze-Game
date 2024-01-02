using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAnimation : MonoBehaviour
{
    public string tagToDestroy = "Enemy";
    private Animator anim;
    public Animator anim1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(son());

        }
    }
    IEnumerator son()
    {
        anim.Play("Character_Death");
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tagToDestroy);
        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }
        yield return new WaitForSeconds(0);
        anim1.Play("Crossfade_End");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(2);
    }
}
