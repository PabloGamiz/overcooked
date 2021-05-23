using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plato : MonoBehaviour
{
    public GameObject prefabSopaTomate;
    public GameObject prefabSopaChampiñon;
    public GameObject prefabSopaCebolla;


    public GameObject prefab_t; //Plato Tomate solo
    public GameObject prefab_l; //Plato Lechuga solo
    public GameObject prefab_ham; //Plato Hamb solo
    public GameObject prefab_p; //Plato con Pan solo
    public GameObject prefab_ham_t; //Plato con Ham y Tomate
    public GameObject prefab_ham_l; //Plato con Ham, Lechuga
    public GameObject prefab_ham_t_l; //Plato con Ham, Tomate y Lechuga
    public GameObject prefab_t_l; //Plato Lechuga y Tomate => Ensalada
    public GameObject prefab_p_t; //Pato con Tomate y pan 
    public GameObject prefab_p_l; //Plato con Lechuga y Pan
    public GameObject prefab_p_ham; //Plato con Pan y Ham
    public GameObject prefab_p_ham_t; //Plato con Pan, Ham y Tomate
    public GameObject prefab_p_ham_l; //Plato con Pan, Ham y Lechuga
    public GameObject prefab_p_t_l; //Plato con Tomate, Lechuga y Pan
    public GameObject prefab_p_ham_t_l; //Plato con Pan, Ham ,Tomate y Lechuga



    public bool tieneAlimento;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject EmplatarPlatoSopa(string tipoPlato)
    {
        GameObject newObj; 

        if (tipoPlato == "sopa_tomate")
        {
            newObj = (GameObject)Instantiate(prefabSopaTomate, transform.position, prefabSopaTomate.transform.rotation);
        }
        else if (tipoPlato == "sopa_cebolla")
        {
            newObj = (GameObject)Instantiate(prefabSopaCebolla, transform.position, prefabSopaCebolla.transform.rotation);
        }
        else //tipoPlato == "sopa_champiñon"
        {
            newObj = (GameObject)Instantiate(prefabSopaChampiñon, transform.position, prefabSopaChampiñon.transform.rotation);
        }

        return newObj; 
    }

    public GameObject EmplatarPlatoNormal(string tipoAlimento)
    {
        if (tipoAlimento == "lechuga")
        {
            return PlatosLechuga();
        }
        else if (tipoAlimento == "tomate")
        {
            return PlatosTomate();
        }
        else if (tipoAlimento == "pan")
        {
            return PlatosPan();
        }
        else if (tipoAlimento == "carne")
        {
            return PlatosCarne();
        }
        else return null; 
    }
    
    GameObject PlatosLechuga()
    {
        if (gameObject.name.Contains("tomate"))
        {
            if (gameObject.name.Contains("pan"))
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_t_l, transform.position, prefab_p_ham_t_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_p_t_l, transform.position, prefab_p_t_l.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_ham_t_l, transform.position, prefab_ham_t_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_t_l, transform.position, prefab_t_l.transform.rotation); // ensalada
            }
        }
        else
        {
            if (gameObject.name.Contains("pan"))
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_l, transform.position, prefab_p_ham_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_p_l, transform.position, prefab_p_l.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_ham_l, transform.position, prefab_ham_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_l, transform.position, prefab_l.transform.rotation);
            }
        }
    }
    
    GameObject PlatosTomate()
    {
        if (gameObject.name.Contains("lechuga"))
        {
            if (gameObject.name.Contains("pan"))
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_t_l, transform.position, prefab_p_ham_t_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_p_t_l, transform.position, prefab_p_t_l.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_ham_t_l, transform.position, prefab_ham_t_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_t_l, transform.position, prefab_t_l.transform.rotation);
            }
        }
        else
        {
            if (gameObject.name.Contains("pan"))
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_t, transform.position, prefab_p_ham_t.transform.rotation);
                else return (GameObject)Instantiate(prefab_p_t, transform.position, prefab_p_t.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_ham_t, transform.position, prefab_ham_t.transform.rotation);
                else return (GameObject)Instantiate(prefab_t, transform.position, prefab_t.transform.rotation);
            }
        }
    }

    GameObject PlatosPan()
    {
        if (gameObject.name.Contains("lechuga"))
        {
            if (gameObject.name.Contains("tomate"))
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_t_l, transform.position, prefab_p_ham_t_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_p_t_l, transform.position, prefab_p_t_l.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_l, transform.position, prefab_p_ham_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_p_l, transform.position, prefab_p_l.transform.rotation);
            }
        }
        else
        {
            if (gameObject.name.Contains("tomate"))
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_t, transform.position, prefab_p_ham_t.transform.rotation);
                else return (GameObject)Instantiate(prefab_p_t, transform.position, prefab_p_t.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham, transform.position, prefab_p_ham.transform.rotation);
                else return (GameObject)Instantiate(prefab_p, transform.position, prefab_p.transform.rotation);
            }
        }
    }

    GameObject PlatosCarne()
    {
        if (gameObject.name.Contains("lechuga"))
        {
            if (gameObject.name.Contains("tomate"))
            {
                if (gameObject.name.Contains("pan")) return (GameObject)Instantiate(prefab_p_ham_t_l, transform.position, prefab_p_ham_t_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_ham_t_l, transform.position, prefab_ham_t_l.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("pan")) return (GameObject)Instantiate(prefab_p_ham_l, transform.position, prefab_p_ham_l.transform.rotation);
                else return (GameObject)Instantiate(prefab_ham_l, transform.position, prefab_ham_l.transform.rotation);
            }
        }
        else
        {
            if (gameObject.name.Contains("tomate"))
            {
                if (gameObject.name.Contains("pan")) return (GameObject)Instantiate(prefab_p_ham_t, transform.position, prefab_p_ham_t.transform.rotation);
                else return (GameObject)Instantiate(prefab_ham_t, transform.position, prefab_ham_t.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("pan")) return (GameObject)Instantiate(prefab_p_ham, transform.position, prefab_p_ham.transform.rotation);
                else return (GameObject)Instantiate(prefab_ham, transform.position, prefab_ham.transform.rotation);
            }
        }
    }
}
