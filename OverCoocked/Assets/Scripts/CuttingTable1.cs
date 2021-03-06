using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingTable1 : MonoBehaviour
{
    public bool hasObject;
    public Transform positionPlayer;
    public GameObject player;
    public GameObject obj;
    public GameObject new_obj;

    public Animator anim;

    public GameObject cutTomato_prefab;
    public GameObject cutOnion_prefab;
    public GameObject cutMeet_prefab;
    public GameObject cutMushroom_prefab;
    public GameObject cutPickle_prefab;
    public GameObject cutLetucce_prefab; 

    public StatusBar statusBar;
    public Image img;
    int statusObject;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        hasObject = false;
        statusBar.SetMax(5);
        time = 0; 
        statusBar.gameObject.SetActive(false);
        img.enabled =false;
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
                else if (obj.name.Contains("champi?on"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutMushroom_prefab, point.position, point.rotation);
                }
                else if (obj.name.Contains("chuleta"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutMeet_prefab, point.position, point.rotation);
                }
                else if (obj.name.Contains("lechuga"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutLetucce_prefab, point.position, point.rotation);
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
        MoveChef1 mc = player.GetComponent<MoveChef1>();
        mc.update_anim("Cutting", true);
        player.transform.parent = positionPlayer;
        player.transform.position = positionPlayer.position;
        player.GetComponent<MoveChef>().can_move = false;
        statusBar.Cut();
    }

    void FinishCuttingAction()
    {
        img.enabled = true;
        player.transform.parent = null;
        player.GetComponent<MoveChef>().can_move = true;
        MoveChef1 mc = player.GetComponent<MoveChef1>();
        mc.update_anim("Cutting", false);
    }


}
