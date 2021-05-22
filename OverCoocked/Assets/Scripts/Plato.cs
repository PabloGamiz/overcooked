using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plato : MonoBehaviour
{
    public GameObject prefabSopaTomate;
    public GameObject prefabSopaChampiñon;
    public GameObject prefabSopaCebolla;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject EmplatarPlato(string tipoPlato)
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
}
