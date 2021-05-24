using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Animator anim;
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
    bool canGrabPlate;
    bool canPickUpFood; 
    bool mesaCortar;
    bool fogon; 
    public GameObject table;
    GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        holdingObject = false; 
        canGrabPlate = false;
        fogon = false;
        can = false; 

    }

    // Update is called once per frame
    void Update()
    {

        if (can)
        {

            if (holdingObject)
            {
                ColocarObjeto();
                anim.SetBool("Holding", false);
            }
            else
            {
                CogerObjetoDeLaMesa();
                anim.SetBool("Holding", true);

            }

        }
        else if (canGrabFood)
        {
            if (!holdingObject)
            {
                GrabFood();
                anim.SetBool("Holding", true);
            }
        }
        else if (canGrabPlate)
        {
            if (!holdingObject)
            {
                GrabPlate();
                anim.SetBool("Holding", true);
            }
            else if (fogon)
            {
                if (holdingObject)
                {
                    AccionesFogon();
                    anim.SetBool("Holding", false);
                }
                else
                {
                    CogerUtensilioCocina();
                    anim.SetBool("Holding", true);
                }
            }
            else if (((!holdingObject && canPickUpFood) || (!can && !canGrabFood && !canGrabPlate)))
            {
                PickUpThings();
                anim.SetBool("Holding", true);
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Contains("olla") || collision.gameObject.name.Contains("sarten") || collision.gameObject.name.Contains("objAlimento") || (collision.gameObject.name.Contains("plato") && !collision.gameObject.name.Contains("mesa")))
        {
            food = collision.gameObject; 
            canPickUpFood = true; 
        }
        else if (collision.gameObject.name.Contains("mesa") && !collision.gameObject.name.Contains("platos"))
        {
            can = true;
            table = collision.gameObject;
            if (collision.gameObject.name.Contains("mesa cortar")) mesaCortar = true;

        }
        else if (collision.gameObject.name.Contains("alimentos"))
        {
            canGrabFood = true;
            table = collision.gameObject;
        }
        else if (collision.gameObject.name.Contains("fogon"))
        {
            fogon = true;
            table = collision.gameObject;
        }
        else if (collision.gameObject.name.Contains("platos"))
        {
            canGrabPlate = true;
            table = collision.gameObject;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        canPickUpFood = false;
        if (can || canGrabFood)
        {
            table = null;
        }
        can = false;
        canGrabFood = false;
        canGrabPlate = false;
        fogon = false;
    }

    void PickUpThings()
    {
        if (canPickUpFood || holdingObject)
        {

            if (!holdingObject)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    GameObject obj = food; 
                    CogerObjeto(obj);
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

    void CogerObjeto(GameObject obj)
    {

        /* Función para coger objectos para player
         * La posicion del objecto cogido = boxHolder
        */
        
        holdingObject = true;

        obj.transform.parent = boxHolder;
        obj.transform.localPosition = Vector3.zero;
        //obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Rigidbody>().useGravity = false;
 
        objectHolded = obj;
        Physics.IgnoreCollision(player.gameObject.GetComponent<Collider>(), obj.GetComponent<Collider>(), true);
        capCol.height = 1.59f;
        capCol.center = new Vector3(-0.016f, 0.546f, 0.2f);
    }


    void ColocarObjeto()
    {
        /* Colocar objecto en la mesa */
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!table.GetComponent<InfoTable>().hasObject)
            {
                Colocar(objectHolded); 
            }
            else if (table.GetComponent<InfoTable>().obj.name.Contains("plato"))
            {
                
                PrepararPlato(); 
            }
        }
    }

    void CogerObjetoDeLaMesa()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (table.GetComponent<InfoTable>().hasObject)
            {
                if (table.name.Contains("cortar")) {  //Recoge alimento de la tabla y si esta cortado desactiva la imagen
                    table.GetComponent<CuttingTable>().img.enabled=false; 
                }

                table.GetComponent<InfoTable>().hasObject = false; 
                CogerObjeto(table.GetComponent<InfoTable>().obj); 
            }
           
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (mesaCortar)
            {
                if (table.GetComponent<InfoTable>().hasObject)
                {
                    table.GetComponent<CuttingTable>().obj = table.GetComponent<InfoTable>().obj;
                    table.GetComponent<CuttingTable>().Cut(); 
                } 
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
        if (Input.GetKeyDown(KeyCode.Q) && !table.GetComponent<GrabFood>().hasFood)
        {
            table.GetComponent<GrabFood>().GrabFoodFromBox();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && table.GetComponent<GrabFood>().hasFood)
        {
            CogerObjeto(table.GetComponent<GrabFood>().food); 
            table.GetComponent<GrabFood>().hasFood = false; 
        }
    }

    void GrabPlate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject plato = table.GetComponent<FactoriaPlatos>().CogerPlato(boxHolder.transform);
            CogerObjeto(plato);
        }

    }

    void AccionesFogon()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(!table.GetComponent<Fogon>().tieneObjecto && (objectHolded.name.Contains("olla") || objectHolded.name.Contains("sarten")))
            {

                table.GetComponent<Fogon>().ColocarUtensilioCocina(objectHolded);
                holdingObject = false;
                ResetCapsuleCollider();
            }
            else if (objectHolded.name.Contains("objAlimento") && table.GetComponent<Fogon>().AddFood(objectHolded))
            {
                holdingObject = false;
                ResetCapsuleCollider();
            }
            else if (objectHolded.name.Contains("plato"))
            {
                //Debug.Log("Estoy aqui");
                if (table.GetComponent<Fogon>().cocinado) // Coge el plato ya esta listo
                {
                    string tipoPlato = table.GetComponent<Fogon>().AñadirComidaPlato();
                    GameObject platoComida;

                    if (table.GetComponent<Fogon>().tipoOlla) platoComida = objectHolded.GetComponent<Plato>().EmplatarPlatoSopa(tipoPlato);
                    else platoComida = objectHolded.GetComponent<Plato>().EmplatarPlatoNormal(tipoPlato);
                    
                    Destroy(objectHolded);
                    CogerObjeto(platoComida); 
                }
            }
        }
    }

    void CogerUtensilioCocina()
    {
        if (Input.GetKeyDown(KeyCode.Q) && table.GetComponent<Fogon>().tieneObjecto)
        {
            CogerObjeto(table.GetComponent<Fogon>().CogerUtensilioCocina());
        }
    }

    void Colocar(GameObject o)
    {
        canPickUpFood = false;
        Transform t = table.GetComponent<InfoTable>().point;
        table.GetComponent<InfoTable>().obj = o;
        table.GetComponent<InfoTable>().hasObject = true;

        holdingObject = false;
        o.transform.parent = t;
        o.transform.position = t.position;

        o.GetComponent<Rigidbody>().useGravity = true;
        o.GetComponent<Rigidbody>().isKinematic = false;
        Physics.IgnoreCollision(player.gameObject.GetComponent<Collider>(), o.GetComponent<Collider>(), false);
        ResetCapsuleCollider();
    }


    void PrepararPlato()
    {
        if (objectHolded.name.Contains("olla") && objectHolded.GetComponent<Olla>().alimentoTerminado) // Preparar plato tipo sopa
        {
            //Instanciar plato de sopa que hay en la mesa
            PrepararSopa(); 

            //Cambiamos la olla llena por una vacia
            GameObject newOlla = objectHolded.GetComponent<Olla>().VaciarOlla(boxHolder);
            Destroy(objectHolded);
            CogerObjeto(newOlla);
        }
        else if ((objectHolded.name.Contains("sarten") && objectHolded.GetComponent<Sarten>().alimentoTerminado) || (objectHolded.name.Contains("objAlimento") && objectHolded.name.Contains("cortado") && !objectHolded.name.Contains("champiñon")))
        {
            Debug.Log("Quiero estar aqui"); 
            PrepararPlatoNormal(); 
        }

    }

    void PrepararSopa()
    {
        GameObject plato = table.GetComponent<InfoTable>().obj;
        GameObject newPlato;
        string alimento = objectHolded.GetComponent<Olla>().tipoAlimento;
        string tipoPlato;
        if (alimento == "tomate") tipoPlato = "sopa_tomate";
        else if (alimento == "cebolla") tipoPlato = "sopa_cebolla";
        else tipoPlato = "sopa_champiñon";
        newPlato = plato.GetComponent<Plato>().EmplatarPlatoSopa(tipoPlato);
        Destroy(plato);
        Colocar(newPlato);
    }

    void PrepararPlatoNormal()
    {
        GameObject plato = table.GetComponent<InfoTable>().obj;
        GameObject newPlato;
        string name = objectHolded.name;
        string tipoAlimento;
        if (name.Contains("tomate")) tipoAlimento = "tomate";
        else if (name.Contains("lechuga")) tipoAlimento = "lechuga";
        else if (name.Contains("pan")) tipoAlimento = "pan";
        else tipoAlimento = "carne"; 

        if (!plato.name.Contains(tipoAlimento)){

            newPlato = plato.GetComponent<Plato>().EmplatarPlatoNormal(tipoAlimento);
            Destroy(plato);
            Colocar(newPlato);
            holdingObject = false;
            Destroy(objectHolded);
            if (name.Contains("sarten"))
            {
                GameObject newSarten = objectHolded.GetComponent<Sarten>().VaciarSarten(boxHolder);
                CogerObjeto(newSarten);
            }
            
        }
        
    }
}
