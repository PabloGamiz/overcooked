using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFood : MonoBehaviour
{
    
    public Transform point;
    public GameObject prefab;
    public GameObject food;
    public bool hasFood;

    void Start()
    {
        hasFood = false;
    }

    public void GrabFoodFromBox()
    {
       food = (GameObject)Instantiate(prefab, point.position, point.rotation);
       //food.transform.parent = point;
       hasFood = true; 
    }
}
