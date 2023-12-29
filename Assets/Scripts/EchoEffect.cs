using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EchoEffect : MonoBehaviour
{

    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject Echo1;
    private CharacterMovement player;  
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(player.canDash == false)
        {
            if(timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(Echo1, transform.position, Quaternion.identity);
                Destroy(instance, 5f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns = timeBtwSpawns - (Time.deltaTime * 5);
            }
        }
    }
}
