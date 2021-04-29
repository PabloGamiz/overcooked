using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFood : MonoBehaviour
{

    public GameObject prefab;
    public GameObject food; 
    

    public void GrabFoodFromBox()
    {
       food = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
       food.transform.parent = transform; 
    }
}
