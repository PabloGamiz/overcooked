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
    public CapsuleCollider capCol; 

    //public GameObject tomato;
    //GameObject ObjectToPickUp;

    public bool holdingObject;
    bool can;
    bool canGrabFood; 
    bool table_cut; 
    public GameObject table; 
    
    // Start is called before the first frame update
    void Start()
    {
        holdingObject = false; 
    }

    // Update is called once per frame
    void Update()
    {

        if (can)
        {

            if (holdingObject)
            {
                PlaceIt();
            }
            else
            {
                PickUpFromTable(); 
            }
            
        }
        else if (canGrabFood)
        {
            if (!holdingObject)
            {
                GrabFood(); 
            }
        }

        if (!holdingObject || !can) PickUpThings();


    }

    void OnCollisionEnter(Collision collision)
    {

        //GameObject objeto1 = GameObject.Find("Player");
        if (collision.gameObject.name.Contains( "mesa") )
        {
            can = true;
            table = collision.gameObject;
            if (collision.gameObject.name.Contains("mesa cortar")) table_cut = true; 

        }
        else if (collision.gameObject.name.Contains("alimentos"))
        {
            canGrabFood = true;
            table = collision.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (can || canGrabFood)
        {
            table = null; 
        }
        can = false;
        canGrabFood = false;

    }


    void PickUpThings()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.Scale(Vector3.forward, transform.localScale));
        RaycastHit hit;
        

        if (Physics.Raycast(grabDetect.position, fwd, out hit, rayDist) || holdingObject)
        {

            if (!holdingObject)
            {
                if (hit.collider.gameObject.name == "tomato")
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        PickUp(hit.collider.gameObject); 
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    
                    holdingObject = false;
                    objectHolded.transform.parent = null;
                    objectHolded.GetComponent<Rigidbody>().useGravity = true;
                    objectHolded.GetComponent<Rigidbody>().isKinematic = false;
                    Physics.IgnoreCollision(player.gameObject.GetComponent<Collider>(), objectHolded.GetComponent<Collider>(), false);
                    ResetCapsuleCollider(); 
                }

            }
        }
    }

    void PickUp(GameObject obj)
    {
        holdingObject = true;
        obj.transform.parent = boxHolder;
        obj.transform.position = boxHolder.position;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        objectHolded = obj;
        Physics.IgnoreCollision(player.gameObject.GetComponent<Collider>(), obj.GetComponent<Collider>(), true);
        capCol.height = 1.59f;
        capCol.center = new Vector3(-0.016f, 0.546f, 0.2f);
    }


    void PlaceIt()

    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Transform t = table.GetComponent<InfoTable>().point;
            table.GetComponent<InfoTable>().obj = objectHolded;
            table.GetComponent<InfoTable>().hasObject = true;

            holdingObject = false;
            objectHolded.transform.parent = t;
            objectHolded.transform.position = t.position;
            objectHolded.GetComponent<Rigidbody>().useGravity = true;
            objectHolded.GetComponent<Rigidbody>().isKinematic = false;
            Physics.IgnoreCollision(player.gameObject.GetComponent<Collider>(), objectHolded.GetComponent<Collider>(), false);
            ResetCapsuleCollider(); 
        }
    }

    void PickUpFromTable()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (table.GetComponent<InfoTable>().hasObject)
            {
                table.GetComponent<InfoTable>().hasObject = false; 
                PickUp(table.GetComponent<InfoTable>().obj); 
            }
           
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (table_cut)
            {
                table.GetComponent<CuttingTable>().CutObject();
            }
        }
    }


    void ResetCapsuleCollider()
    {
        capCol.height = 1.1f;
        capCol.center = new Vector3(-0.016f, 0.546f, 0.005f);
    }


    void GrabFood()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            table.GetComponent<GrabFood>().GrabFoodFromBox();
            PickUp(table.GetComponent<GrabFood>().food); 
        }
    }
}
