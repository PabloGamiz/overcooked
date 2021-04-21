using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChef : MonoBehaviour
{

    public float speed = 7.0f;
    public float rotationSpeed= 1100.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        MovementChef(); 
 
    }

    private void MovementChef()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        gameObject.transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
      
    }

    void OnCollisionEnter(Collision collision)
    {

        GameObject objeto1 = GameObject.Find("Player");
        if (collision.gameObject.name != "Ground" && collision.gameObject.name != "tomato")
        {
            //Debug.Log("objeto1 COLISIONADO con objeto2");

            speed = 0;
        }
    }

    void OnCollisionExit(Collision collision)
    {

        GameObject objeto1 = GameObject.Find("Player");
        if (collision.gameObject.name != "Ground" && collision.gameObject.name != "tomato")
        {
            //Debug.Log("objeto1 EXIT con objeto2");

            speed = 7; 
        }
    }

}
