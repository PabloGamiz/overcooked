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

    public AudioSource coger;
    public AudioSource dejar;
    
    //public GameObject tomato;
    //GameObject ObjectToPickUp;

    public bool holdingObject;
    bool cortando; 
    bool can;
    bool canGrabFood;
    bool canGrabPlate;
    bool canPickUpFood; 
    bool mesaCortar;
    bool puedeEntregar; 
    bool fogon;
    bool objExtintor; 
    public GameObject table;
    GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("dentro de start");
        holdingObject = false; 
        canGrabPlate = false;
        fogon = false;
        can = false;
        cortando = false; 

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("dentro de update");
        Debug.Log("dentro de update");
        if (GetComponent<MoveChef>().can_move)
        {
            Debug.Log("dentro de poder moverse");
            Debug.Log("valor de can: " + can);
            if (can)
            {
                Debug.Log("dentro de can");

                if (holdingObject)
                {
                    ColocarObjeto();
                    MoveChef1 mc = player.GetComponent<MoveChef1>();
                    mc.update_anim("Holding", false);
                }
                else
                {
                    CogerObjetoDeLaMesa();
                    MoveChef1 mc = player.GetComponent<MoveChef1>();
                    mc.update_anim("Holding", true);
                }

            }
            else if (canGrabFood)
            {
                if (!holdingObject)
                {
                    Debug.Log("Coje comida");
                    GrabFood();
                    MoveChef1 mc = player.GetComponent<MoveChef1>();
                    mc.update_anim("Holding", true);
                }
            }
            else if (canGrabPlate)
            {
                if (!holdingObject)
                {
                    GrabPlate();
                    MoveChef1 mc = player.GetComponent<MoveChef1>();
                    mc.update_anim("Holding", true);
                }
            }
            else if (fogon)
            {
                if (holdingObject)
                {
                    AccionesFogon();
                    MoveChef1 mc = player.GetComponent<MoveChef1>();
                    mc.update_anim("Holding", false);
                }
                else
                {
                    CogerUtensilioCocina();
                    MoveChef1 mc = player.GetComponent<MoveChef1>();
                    mc.update_anim("Holding", true);
                }
            }
            else if (((!holdingObject && canPickUpFood) || (!can && !canGrabFood && !canGrabPlate)))
            {
                PickUpThings();
                MoveChef1 mc = player.GetComponent<MoveChef1>();
                mc.update_anim("Holding", true);
            }


                if (objExtintor)
            {
                AccionesExtintor();
            }
        }



    }

    void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.name.Contains("olla") || collision.gameObject.name.Contains("sarten") || collision.gameObject.name.Contains("objAlimento") || collision.gameObject.name.Contains("extintor") || (collision.gameObject.name.Contains("plato") && !collision.gameObject.name.Contains("mesa")))
        {
            food = collision.gameObject;
            canPickUpFood = true;
            //puedeEntregar = false;
        }
        else if (collision.gameObject.name.Contains("mesa") && !collision.gameObject.name.Contains("platos"))
        {
            Debug.Log("dentro de colision con mesa");
            can = true;
            table = collision.gameObject;
            
            puedeEntregar = false;
            if (collision.gameObject.name.Contains("mesa cortar")) mesaCortar = true;

        }
        else if (collision.gameObject.name.Contains("entregar"))
        {
            
            can = true;
            puedeEntregar = true; 
            table = collision.gameObject;
        }
        else if (collision.gameObject.name.Contains("alimentos"))
        {
            can = false; 
            canGrabFood = true;
            table = collision.gameObject;
            //puedeEntregar = false;
        }
        else if (collision.gameObject.name.Contains("fogon"))
        {
            can = false; 
            fogon = true;
            table = collision.gameObject;
            //puedeEntregar = false;
        }
        else if (collision.gameObject.name.Contains("platos"))
        {
            canGrabPlate = true;
            can = false; 
            table = collision.gameObject;
            //puedeEntregar = false;
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
        mesaCortar = false; 
        canGrabFood = false;
        canGrabPlate = false;
        puedeEntregar = false;
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
                    if (food.name.Contains("extintor"))
                    {
                        objExtintor = true; 
                    }
                    GameObject obj = food; 
                    CogerObjeto(obj);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    dejar.Play(); 
                    holdingObject = false;
                    objExtintor = false;
                    objectHolded.transform.parent = null;
                    objectHolded.GetComponent<Rigidbody>().useGravity = true;
                    objectHolded.GetComponent<Rigidbody>().isKinematic = false;
                    objectHolded.GetComponent<Collider>().enabled = true;
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
        Debug.Log(obj.GetComponent<Objeto>().algo);
        obj.transform.rotation = Quaternion.Euler(obj.GetComponent<Objeto>().algo);
        Debug.Log(obj.transform.rotation);
        obj.transform.localRotation = Quaternion.Euler(obj.GetComponent<Objeto>().algo); 
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Rigidbody>().useGravity = false;

        coger.Play(); 
        objectHolded = obj;
        Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), obj.GetComponent<Collider>(), true);
        /*capCol.height = 1.59f;
        capCol.center = new Vector3(-0.016f, 0.546f, 0.2f);*/
    }


    void ColocarObjeto()
    {
        /* Colocar objecto en la mesa */
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(puedeEntregar);
            if (!puedeEntregar)
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
            else if (puedeEntregar && objectHolded.name.Contains("plato"))
            {
                if (!table.GetComponent<MesaEntrega>().tieneObjeto)
                {
                    holdingObject = false;
                    Physics.IgnoreCollision(player.gameObject.GetComponent<Collider>(), objectHolded.GetComponent<Collider>(), false);
                    ResetCapsuleCollider();
                    table.GetComponent<MesaEntrega>().EntregarPlato(objectHolded);
                }

            }

        }
    }

    void CogerObjetoDeLaMesa()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!puedeEntregar)
            {
                if (table.GetComponent<InfoTable>().hasObject)
                {
                    if (table.name.Contains("cortar"))
                    {  //Recoge alimento de la tabla y si esta cortado desactiva la imagen
                        table.GetComponent<CuttingTable>().img.enabled = false;
                    }

                    table.GetComponent<InfoTable>().hasObject = false;
                    CogerObjeto(table.GetComponent<InfoTable>().obj);
                }
            }



        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (mesaCortar)
            {
                if (table.GetComponent<InfoTable>().hasObject && !table.GetComponent<InfoTable>().obj.name.Contains("cortado"))
                {
                    cortando = true; 
                    table.GetComponent<CuttingTable>().obj = table.GetComponent<InfoTable>().obj;
                    table.GetComponent<CuttingTable>().Cut(); 
                } 
            }
        }
    }


    void ResetCapsuleCollider()
    {
        /*capCol.height = 1.1f;
        capCol.center = new Vector3(-0.016f, 0.546f, 0.005f);*/
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
        o.GetComponent<Rigidbody>().isKinematic = true;
        o.GetComponent<Collider>().enabled = false; 
        holdingObject = false;
        o.transform.parent = t;
        o.transform.position = t.position;
        //o.transform.eulerAngles = t.GetChild(0).eulerAngles;

        o.GetComponent<Rigidbody>().useGravity = true;
        dejar.Play(); 
        
        Physics.IgnoreCollision(player.gameObject.GetComponent<Collider>(), o.GetComponent<Collider>(), false);
        ResetCapsuleCollider();
    }


    void PrepararPlato()
    {
        if (objectHolded.name.Contains("olla") && !objectHolded.name.Contains("objAlimento")  && objectHolded.GetComponent<Olla>().alimentoTerminado) // Preparar plato tipo sopa
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

        //Escogemos que tipo de alimento estamos poniendo en el plato
        if (name.Contains("tomate")) tipoAlimento = "tomate";
        else if (name.Contains("lechuga")) tipoAlimento = "lechuga";
        else if (name.Contains("pan")) tipoAlimento = "pan";
        else if (name.Contains("pepinillo")) tipoAlimento = "pepinillo";
        else if (name.Contains("cebolla")) tipoAlimento = "cebolla";
        else tipoAlimento = "carne"; 

        if (!plato.name.Contains(tipoAlimento) && !plato.name.Contains("sopa") && PuedeColocarAlimento(tipoAlimento,plato.name))
        {

            newPlato = plato.GetComponent<Plato>().EmplatarPlatoNormal(tipoAlimento);
            Destroy(plato);
            Colocar(newPlato);
            MoveChef1 mc = player.GetComponent<MoveChef1>();
            mc.update_anim("Holding", false);
            holdingObject = false;
            Destroy(objectHolded);
            if (name.Contains("sarten"))
            {
                GameObject newSarten = objectHolded.GetComponent<Sarten>().VaciarSarten(boxHolder);
                CogerObjeto(newSarten);
                mc.update_anim("Holding", true);
            }
            
        }
        
    }

    bool PuedeColocarAlimento(string tipoAlimento, string plato)
    {
        return  (tipoAlimento == "pepinillo" && !plato.Contains("lechuga") && !plato.Contains("tomate")) ||

                ((tipoAlimento == "lechuga" || tipoAlimento == "tomate") && !plato.Contains("pepinillo") &&
                ((plato.Contains("cebolla") && !plato.Contains("pan") && !plato.Contains("ham")) ||
                ((!plato.Contains("cebolla") && (plato.Contains("pan") || plato.Contains("ham")))) ||
                (plato.Contains("tomate") || plato.Contains("lechuga")))) ||

                (tipoAlimento == "cebolla" &&
                (((plato.Contains("lechuga") || plato.Contains("tomate")) && !plato.Contains("pan") && !plato.Contains("ham")) || (!plato.Contains("lechuga") && !plato.Contains("tomate")))) ||

                ((tipoAlimento == "pan" || tipoAlimento == "carne") &&
                (((plato.Contains("lechuga") || plato.Contains("tomate")) && !plato.Contains("cebolla")) || (!plato.Contains("lechuga") && !plato.Contains("tomate") && plato.Contains("cebolla")) || plato.Contains("pepinillo") || plato.Contains("ham") || plato.Contains("pan"))) ||

                (!plato.Contains("tomate") && !plato.Contains("lechuga") && !plato.Contains("cebolla") && !plato.Contains("pepinillo") && !plato.Contains("ham") && !plato.Contains("pan")); 
    }


    void AccionesExtintor()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            objectHolded.GetComponent<Extintor>().EncenderApagarExtintor(); 
        }
    }
}
