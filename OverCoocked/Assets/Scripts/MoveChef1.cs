using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChef : MonoBehaviour
{
    private Animator anim; 

    public float speed = 7.0f;
    public float rotationSpeed= 1100.0f;
    public bool can_move;

    public float horizontalInput;
    public float verticalInput; 

    private Rigidbody rb;
    private Vector3 inputVector; 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
            transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
            anim.SetBool("Walking", true);
        }
        else anim.SetBool("Walking", false);
    }

    void FixedUpdate()
    {
        rb.velocity = inputVector;
    }

}
