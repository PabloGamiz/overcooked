using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveChef1 : MonoBehaviour
{
    public Animator anim; 

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
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        can_move = true; 
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (GetComponent<MoveChef>().can_move)
        {
            inputVector = new Vector3(horizontalInput * speed, rb.velocity.y, verticalInput * speed);
            transform.LookAt(transform.position + new Vector3(inputVector.z, 0, -inputVector.x));

            if (horizontalInput == 0 && verticalInput == 0)
                anim.SetBool("Walking", false);
            else anim.SetBool("Walking", true);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = inputVector;
    }

    public void update_anim (string s, bool b)
    {
        anim.SetBool(s, b);
    }
}
