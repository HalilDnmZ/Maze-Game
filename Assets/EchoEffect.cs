using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EchoEffect : MonoBehaviour
{

    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    private CharacterMovement player;  
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isDashing == true)
        {
            if(timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 10f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
