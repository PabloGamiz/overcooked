using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olla : MonoBehaviour
{

    public int maxFood;
    public string tipoAlimento;
    public bool tieneAlimento;
    public bool alimentoTerminado; 
    public int numAlim;

    //Olla Vacia
    public GameObject ollaVacia_prefab;

    //Tomate
    public GameObject ollaTomate1_prefab;
    public GameObject ollaTomate2_prefab;
    public GameObject ollaTomate3_prefab;

    //Cebolla
    public GameObject ollaCebolla1_prefab;
    public GameObject ollaCebolla2_prefab;
    public GameObject ollaCebolla3_prefab;

    //Champiñon
    public GameObject ollaChamp1_prefab;
    public GameObject ollaChamp2_prefab;
    public GameObject ollaChamp3_prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject AñadirAlimentoOlla(GameObject alim, Transform posiconObj)
    {
        if (numAlim==0)
        {
            if (alim.name.Contains("tomate"))
            {
                tipoAlimento = "tomate";
            }
            else if (alim.name.Contains("cebolla"))
            {
                tipoAlimento = "cebolla"; 
            }
            else tipoAlimento = "champiñon"; 
        }

        
        GameObject newObj = AñadirAlimento(alim, posiconObj);
        return newObj; 
    }

    public GameObject AñadirAlimento(GameObject alim, Transform punto)
    {
        GameObject newObj;  
        if (tipoAlimento == "tomate" )
        {
            if (numAlim== 0)
            {
                newObj = (GameObject)Instantiate(ollaTomate1_prefab, punto.position, punto.rotation);
            } 
            else if (numAlim ==1) 
            {
                newObj = (GameObject)Instantiate(ollaTomate2_prefab, punto.position, punto.rotation);
            } else
            {
                newObj = (GameObject)Instantiate(ollaTomate3_prefab, punto.position, punto.rotation);
            }
        }
        else if (tipoAlimento == "cebolla" )
        {
            if (numAlim == 0)
            {
               
                newObj = (GameObject)Instantiate(ollaCebolla1_prefab, punto.position, punto.rotation);
            }
            else if (numAlim == 1)
            {
                newObj = (GameObject)Instantiate(ollaCebolla2_prefab, punto.position, punto.rotation);
            }
            else
            {
                newObj = (GameObject)Instantiate(ollaCebolla3_prefab, punto.position, punto.rotation);
            }
        }
        else
        {
            if (numAlim == 0)
            {
                newObj = (GameObject)Instantiate(ollaChamp1_prefab, punto.position, punto.rotation);
            }
            else if (numAlim == 1)
            {
                newObj = (GameObject)Instantiate(ollaChamp2_prefab, punto.position, punto.rotation);
            }
            else
            {
                newObj = (GameObject)Instantiate(ollaChamp3_prefab, punto.position, punto.rotation);
            }
        }
        alimentoTerminado= false; 
        Destroy(alim);
        return newObj; 
    }

    public GameObject VaciarOlla(Transform punto)
    {
        return (GameObject)Instantiate(ollaVacia_prefab, punto.position, punto.rotation); 
    }



}
