using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float spawnDelay;

    public bool canSpawn = true;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (canSpawn && col.gameObject.name == "Character")
        {
            Debug.Log("enter");
            StartCoroutine(SpawnWithDelay());
        }
    }

    private IEnumerator SpawnWithDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        canSpawn = true;
    }
}
