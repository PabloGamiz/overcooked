using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChef : MonoBehaviour
{

    public float speed ;
    public float rotationSpeed= 1100.0f;
    public bool can_move;

    public float horizontalInput;
    public float verticalInput; 

    private Rigidbody rb;
    private Vector3 inputVector; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        can_move = true; 
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (can_move)
        {
            inputVector = new Vector3(horizontalInput * speed, rb.velocity.y, verticalInput * speed);
            transform.LookAt(transform.position + new Vector3(inputVector.z, 0, -inputVector.x));
        }
    }

    void FixedUpdate()
    {
        rb.velocity = inputVector;
    }

}
