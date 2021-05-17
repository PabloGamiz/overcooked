using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChef : MonoBehaviour
{

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
        rb = GetComponent<Rigidbody>();
        can_move = true; 
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        inputVector = new Vector3(horizontalInput * speed, rb.velocity.y, verticalInput * speed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (can_move) MovementChef(); 
        rb.velocity = inputVector;

    }

    private void MovementChef()
    {

        /*Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        gameObject.transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }*/
      
    }

    void OnCollisionEnter(Collision collision)
    {

        GameObject objeto1 = GameObject.Find("Player");
        if (collision.gameObject.name != "Ground" && !collision.gameObject.name.Contains("tomato") )
        {
           

           // speed = 1;
        }
    }

    void OnCollisionExit(Collision collision)
    {

        GameObject objeto1 = GameObject.Find("Player");
        if (collision.gameObject.name != "Ground" && !collision.gameObject.name.Contains("tomato"))
        {
           
            //speed = 7; 
        }
    }

}
