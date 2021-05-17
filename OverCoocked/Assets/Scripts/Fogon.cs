using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogon : MonoBehaviour
{
    public GameObject obj;
    public bool hasObject; 
    public bool tipoOlla;
    public Transform posiconObj;

    public bool on; 

    public StatusBar statusBar;
    int statusObject;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        hasObject = false;
        statusBar.SetMax(5);
        time = 0;
        statusBar.gameObject.SetActive(false);
        statusObject = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFood(GameObject alim)
    {
        if (tipoOlla)
        {   
            if (alim.name.Contains("tomate") || alim.name.Contains("cebolla") || alim.name.Contains("champiñon"))
            {
                
                if (obj.GetComponent<Olla>().numAlim == 0)
                {
                    GameObject newObject = obj.GetComponent<Olla>().AñadirAlimentoOlla(alim, posiconObj);
                    Destroy(obj); 
                    obj = newObject; 
                }else if(obj.GetComponent<Olla>().numAlim <= 3 && alim.name.Contains(obj.GetComponent<Olla>().tipoAlimento))
                {
                    GameObject newObject = obj.GetComponent<Olla>().AñadirAlimento(alim, posiconObj);
                    Destroy(obj); 
                    obj = newObject; 
                }
                
                
            }

        }
    }
}
