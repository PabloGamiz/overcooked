using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingTable : MonoBehaviour
{
    public bool hasObject;
    public Transform positionPlayer;
    public GameObject player;
    public GameObject obj;
    public GameObject new_obj;

    public GameObject cutTomato_prefab;
    public GameObject cutOnion_prefab;
    public GameObject cutMeet_prefab;
    public GameObject cutMushroom_prefab;
    public GameObject cutPickle_prefab;

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
        if (statusBar.hasFinished)
        {
            Transform point = gameObject.GetComponent<InfoTable>().point;
            if (obj != null)
            {
                if (obj.name.Contains("tomate"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutTomato_prefab, point.position, point.rotation);
                }
                else if (obj.name.Contains("cebolla"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutOnion_prefab, point.position, point.rotation);
                }
                else if (obj.name.Contains("champiñon"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutMushroom_prefab, point.position, point.rotation);
                }
                else if (obj.name.Contains("chuleta"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutMeet_prefab, point.position, point.rotation);
                }
                else
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutPickle_prefab, point.position, point.rotation);
                }

                gameObject.GetComponent<InfoTable>().obj = new_obj;
                FinishCuttingAction();
            }  
        }
    }


    public void Cut()
    {
        player.transform.parent = positionPlayer;
        player.transform.position = positionPlayer.position;
        player.GetComponent<MoveChef>().can_move = false;
        statusBar.Cut(); 
    }

    void FinishCuttingAction()
    {
        player.transform.parent = null;
        player.GetComponent<MoveChef>().can_move = true;
    }


}
