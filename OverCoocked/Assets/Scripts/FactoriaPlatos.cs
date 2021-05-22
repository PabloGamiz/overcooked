using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoriaPlatos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public Transform point;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CogerPlato(Transform t)
    {
        GameObject plato = (GameObject)Instantiate(prefab, t);
        return plato; 
    }
}
