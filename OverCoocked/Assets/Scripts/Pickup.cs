using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public GameObject player;
    public GameObject objectHolded;
    public float rayDist; 

    //public GameObject tomato;
    //GameObject ObjectToPickUp;

    bool holdingObject;
    bool can; 
    
    // Start is called before the first frame update
    void Start()
    {
        holdingObject = false; 
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 fwd = transform.TransformDirection(Vector3.Scale(Vector3.forward,transform.localScale));
        RaycastHit hit;

        if (Physics.Raycast(grabDetect.position,fwd, out hit, rayDist) || holdingObject)
        {

            if (!holdingObject)
            {
                if (hit.collider.gameObject.name == "tomato" )
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {

                        holdingObject = true;
                        hit.collider.gameObject.transform.parent = boxHolder;
                        hit.collider.gameObject.transform.position = boxHolder.position;
                        hit.collider.gameObject.transform.localPosition = Vector3.zero;
                        hit.collider.gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        objectHolded = hit.collider.gameObject;
                        Physics.IgnoreCollision(player.gameObject.GetComponent<Collider>(), hit.collider.gameObject.GetComponent<Collider>(), true);
                    }
                }
            } else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Debug.Log("COLLISION");
                    holdingObject = false;
                    objectHolded.transform.parent = null;
                    objectHolded.GetComponent<Rigidbody>().useGravity = true;
                    objectHolded.GetComponent<Rigidbody>().isKinematic = false;
                    Physics.IgnoreCollision(player.gameObject.GetComponent<Collider>(), objectHolded.GetComponent<Collider>(), false);
                }
                
            }
            
            

        } 
        
    }

    void OnCollisionEnter(Collision collision)
    {

        //GameObject objeto1 = GameObject.Find("Player");
        if (collision.gameObject.name == "tomato")
        {
            //Debug.Log("COLLISION");
            can = true;
            
        }
    }

    void OnCollisionExit(Collision collision)
    {

        //GameObject objeto1 = GameObject.Find("Player");
        if (collision.gameObject.name == "tomato")
        {
            Debug.Log("COLLISION EXIT");
            //can = false; 
        }
    }


}
