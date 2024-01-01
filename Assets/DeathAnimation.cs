using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAnimation : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
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
        yield return new WaitForSeconds(1);
        anim.Play("Character_Death");
        SceneManager.LoadScene(2);
    }
}
