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

    public GameObject prefab_c; //Plato con cebolla solo
    public GameObject prefab_pep; // Plato con pepinillo solo
    public GameObject prefab_c_pep; //Plato con cebolla y pepinillo
    
    public GameObject prefab_l_c; //Plato con lechuga y cebolla
    public GameObject prefab_t_c; //Plato con tomate y cebolla 
    public GameObject prefab_l_t_c; //Plato con tomate, cebolla y lechuga

    public GameObject prefab_ham_pep; //Plato con hambur y pepinillo
    public GameObject prefab_ham_c; //Plato con hambur y cebolla
    public GameObject prefab_ham_pep_c; //Plato con hambur, pepinillo y cebolla

    public GameObject prefab_p_c; //Plato de pan con cebolla 
    public GameObject prefab_p_pep; //Plato de pan con pepinillo 
    public GameObject prefab_p_c_pep;  //Plato de pan con cebolla, pepinill

    public GameObject prefab_p_ham_c; //Plato pan, hamburgesa y cebolla
    public GameObject prefab_p_ham_pep; //Plato pan, hamburgesa y pepinillo
    public GameObject prefab_p_ham_c_pep; //Plato pan, hamburgesa, pepinillo y cebolla



    public bool tieneAlimento;
     

    // Start is called before the first frame update
    void Start()
    {
        /*prefab_c = (GameObject)Resources.Load("Assets/Prefabs/plato_cebolla.prefab", typeof(GameObject)); 
        prefab_pep = (GameObject)Resources.Load("Prefabs/plato_pepinillos", typeof(GameObject));
        prefab_c_pep = (GameObject)Resources.Load("Prefabs/plato_cebolla_pepinillos", typeof(GameObject));
        prefab_l_c = (GameObject)Resources.Load("Prefabs/plato_lechuga_cebolla", typeof(GameObject));
        prefab_t_c = (GameObject)Resources.Load("Prefabs/plato_tomate_cebolla", typeof(GameObject));
        prefab_l_t_c = (GameObject)Resources.Load("Prefabs/plato_lechuga_tomate_cebolla", typeof(GameObject));
        prefab_ham_pep = (GameObject)Resources.Load("Prefabs/plato_ham_pepinillo", typeof(GameObject));
        prefab_ham_c = (GameObject)Resources.Load("Prefabs/plato_ham_cebolla", typeof(GameObject));
        prefab_ham_pep_c = (GameObject)Resources.Load("Prefabs/plato_ham_pepinillo_cebolla", typeof(GameObject));
        prefab_p_ham_c =  (GameObject)Resources.Load("Prefabs/plato_pan_ham_cebolla", typeof(GameObject));
        prefab_p_ham_pep = (GameObject)Resources.Load("Prefabs/plato_pan_ham_pepinillo", typeof(GameObject));
        prefab_p_ham_c_pep = (GameObject)Resources.Load("Prefabs/plato_pan_ham_cebolla_pepinillo", typeof(GameObject));
        //variableForPrefab = Resources.Load("prefabs/prefab1", GameObject) as GameObject;*/
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
            newObj = (GameObject)Instantiate(prefabSopaTomate, transform.position, Quaternion.Euler(prefabSopaChampiñon.GetComponent<Objeto>().algo));
        }
        else if (tipoPlato == "sopa_cebolla")
        {
            newObj = (GameObject)Instantiate(prefabSopaCebolla, transform.position, Quaternion.Euler(prefabSopaChampiñon.GetComponent<Objeto>().algo));
        }
        else //tipoPlato == "sopa_champiñon"
        {
            newObj = (GameObject)Instantiate(prefabSopaChampiñon, transform.position, Quaternion.Euler(prefabSopaChampiñon.GetComponent<Objeto>().algo));
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
        else if (tipoAlimento == "pepinillo")
        {
            return PlatosPepinillo(); 
        }
        else if (tipoAlimento == "cebolla")
        {
            return PlatosCebolla(); 
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
            else if (gameObject.name.Contains("cebolla"))
            {
                return (GameObject)Instantiate(prefab_l_t_c, transform.position, prefab_p_t_l.transform.rotation);
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
            else if (gameObject.name.Contains("cebolla"))
            {
                return (GameObject)Instantiate(prefab_l_c, transform.position, prefab_p_t_l.transform.rotation);
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
            else if (gameObject.name.Contains("cebolla"))
            {
                return (GameObject)Instantiate(prefab_l_t_c, transform.position, prefab_p_t_l.transform.rotation);
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
            else if (gameObject.name.Contains("cebolla"))
            {
                return (GameObject)Instantiate(prefab_t_c, transform.position, prefab_p_t_l.transform.rotation);
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
                if (gameObject.name.Contains("cebolla"))
                {
                    if (gameObject.name.Contains("pepinillo"))
                    {
                        if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_c_pep, transform.position, prefab_p_ham_c_pep.transform.rotation);
                        else return (GameObject)Instantiate(prefab_p_c_pep, transform.position, prefab_p.transform.rotation);
                    }
                    else
                    {
                        if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_c, transform.position, prefab_p_ham_c.transform.rotation);
                        else return (GameObject)Instantiate(prefab_p_c, transform.position, prefab_p_c.transform.rotation);
                    }
                }
                else if (gameObject.name.Contains("pepinillo"))
                {
                    if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_pep, transform.position, prefab_p_ham_pep.transform.rotation);
                    else return (GameObject)Instantiate(prefab_p_pep, transform.position, prefab_p_pep.transform.rotation);
                }
                else
                {
                    if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham, transform.position, prefab_p_ham.transform.rotation);
                    else return (GameObject)Instantiate(prefab_p, transform.position, prefab_p.transform.rotation);
                }
                
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
                if (gameObject.name.Contains("cebolla"))
                {
                    if (gameObject.name.Contains("pepinillo"))
                    {
                        if (gameObject.name.Contains("pan")) return (GameObject)Instantiate(prefab_p_ham_c_pep, transform.position, prefab_p_ham_c_pep.transform.rotation);
                        else return (GameObject)Instantiate(prefab_ham_pep_c, transform.position, prefab_p.transform.rotation);
                    }
                    else
                    {
                        if (gameObject.name.Contains("pan")) return (GameObject)Instantiate(prefab_p_ham_c, transform.position, prefab_p_ham_c.transform.rotation);
                        else return (GameObject)Instantiate(prefab_ham_c, transform.position, prefab_ham_c.transform.rotation);
                    }
                }
                else if (gameObject.name.Contains("pepinillo"))
                {
                    if (gameObject.name.Contains("pan")) return (GameObject)Instantiate(prefab_p_ham_pep, transform.position, prefab_p_ham_pep.transform.rotation);
                    else return (GameObject)Instantiate(prefab_ham_pep, transform.position, prefab_ham_pep.transform.rotation);
                }
                else
                {
                    if (gameObject.name.Contains("pan")) return (GameObject)Instantiate(prefab_p_ham, transform.position, prefab_p_ham.transform.rotation);
                    else return (GameObject)Instantiate(prefab_ham, transform.position, prefab_ham.transform.rotation);
                }
                
            }
        }
    }

    GameObject PlatosPepinillo()
    {
        if (gameObject.name.Contains("cebolla"))
        {
            if (gameObject.name.Contains("pan"))
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_c_pep, transform.position, prefab_p_ham_c_pep.transform.rotation);
                else return (GameObject)Instantiate(prefab_p_c_pep, transform.position, prefab_p_c_pep.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_ham_pep_c, transform.position, prefab_ham_pep_c.transform.rotation);
                else return (GameObject)Instantiate(prefab_c_pep, transform.position, prefab_c_pep.transform.rotation);
            }
        }
        else
        {
            if (gameObject.name.Contains("pan"))
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_pep, transform.position, prefab_p_ham_pep.transform.rotation);
                else return (GameObject)Instantiate(prefab_p_pep, transform.position, prefab_p_pep.transform.rotation);
            }
            else
            {
                if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_ham_pep, transform.position, prefab_ham_pep.transform.rotation);
                else return (GameObject)Instantiate(prefab_pep, transform.position, prefab_pep.transform.rotation);
            }
        }
    }

    GameObject PlatosCebolla()
    {
        if (gameObject.name.Contains("tomate"))
        {
            if (gameObject.name.Contains("lechuga")) return (GameObject)Instantiate(prefab_l_t_c, transform.position, prefab_l_t_c.transform.rotation);
            else return (GameObject)Instantiate(prefab_t_c, transform.position, prefab_l_t_c.transform.rotation);

        }
        else if (gameObject.name.Contains("lechuga"))
        {
            return (GameObject)Instantiate(prefab_l_c, transform.position, prefab_l_c.transform.rotation);
        }
        else
        {
            if (gameObject.name.Contains("pepinillo"))
            {
                if (gameObject.name.Contains("pan"))
                {
                    if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_c_pep, transform.position, prefab_p_ham_c_pep.transform.rotation);
                    else return (GameObject)Instantiate(prefab_p_c_pep, transform.position, prefab_p_c_pep.transform.rotation);
                }
                else
                {
                    if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_ham_pep_c, transform.position, prefab_ham_pep_c.transform.rotation);
                    else return (GameObject)Instantiate(prefab_c_pep, transform.position, prefab_c_pep.transform.rotation);
                }
            }
            else
            {
                if (gameObject.name.Contains("pan"))
                {
                    if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_p_ham_c, transform.position, prefab_p_ham_c.transform.rotation);
                    else return (GameObject)Instantiate(prefab_p_c, transform.position, prefab_p_c.transform.rotation);
                }
                else
                {
                    if (gameObject.name.Contains("ham")) return (GameObject)Instantiate(prefab_ham_c, transform.position, prefab_ham_c.transform.rotation);
                    else return (GameObject)Instantiate(prefab_c, transform.position, prefab_c.transform.rotation);
                }
            }
        }
    }

    public GameObject PlatosGodMode(int id)
    {
        if( id == 1)
        {
            return (GameObject)Instantiate(prefab_l, transform.position, prefab_l.transform.rotation);
        }
        else if (id == 2)
        {
            return (GameObject)Instantiate(prefab_t_l, transform.position, prefab_t_l.transform.rotation);
        }
        else if (id == 3)
        {
            return (GameObject)Instantiate(prefab_l_c, transform.position, prefab_l_c.transform.rotation);
        }
        else if (id == 4)
        {
            return (GameObject)Instantiate(prefabSopaTomate, transform.position, prefabSopaTomate.transform.rotation);
        }
        else if (id == 5)
        {
            return (GameObject)Instantiate(prefabSopaCebolla, transform.position, prefabSopaCebolla.transform.rotation);
        }
        else if(id == 6)
        {
            return (GameObject)Instantiate(prefabSopaChampiñon, transform.position, prefabSopaChampiñon.transform.rotation);
        }
        else if (id == 7)
        {
            return (GameObject)Instantiate(prefab_p_ham_t_l, transform.position, prefab_p_ham_t_l.transform.rotation);
        }
        else
        {
            return (GameObject)Instantiate(prefab_p_ham_c_pep, transform.position, prefab_p_ham_c_pep.transform.rotation);
        }
    }

}
