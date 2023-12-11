using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float m_speed = 5f;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        
        //Vector3 m_input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //rb.MovePosition(transform.position + m_input * Time.deltaTime * m_speed );
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveRight());
        }
    }
    IEnumerator MoveRight()
    {
        while (true)
        {
            transform.position += Vector3.right * m_speed * Time.deltaTime;
            yield return null;

            //if (Physics.Raycast(transform.position, Vector3.right, 0.5f))
            //{
            //    isMoving = false;
            //    break;
            //}
        }
    }
    void OnTriggerEnter2D(Collider2D otheer)
    {
        Debug.Log("Collide Happened");
        //if (collision.collider.CompareTag("Graphics"))
        //{
        //isMoving = false;

        //}
    }


}
