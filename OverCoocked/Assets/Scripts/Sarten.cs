using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarten : MonoBehaviour
{

    public GameObject prefab_sartenVacia;
    public GameObject prefab_sartenHamburgesaNoHecha;
    public GameObject prefab_sartenHamburgesaHecha;

    public bool tieneAlimento;
    public bool alimentoTerminado; 

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject AñadirAlimento(GameObject alim, Transform punto)
    {
        GameObject newObj = (GameObject)Instantiate(prefab_sartenHamburgesaNoHecha, punto.position, punto.rotation);
        tieneAlimento = true; 
        Destroy(alim);
        return newObj;

    }

    public GameObject AlimentoHecho(Transform punto)
    {
       return (GameObject)Instantiate(prefab_sartenHamburgesaHecha, punto.position, punto.rotation);
    }

    public GameObject VaciarSarten(Transform punto)
    {
        return (GameObject)Instantiate(prefab_sartenVacia, punto.position, punto.rotation);
    }
}
