using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AiFollow : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameObject.Find("Character").transform;
    }

    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;


        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Character")
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
}
