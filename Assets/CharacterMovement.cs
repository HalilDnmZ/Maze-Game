using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float m_speed = 10f;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 m_input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        rb.MovePosition(transform.position + m_input * Time.deltaTime * m_speed * 50000);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
