using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public GameObject cutLetucce_prefab; 

    public StatusBar statusBar;
    public Image img;
    int statusObject;
    float time;

    public AudioSource cortarAudio;
    public AudioSource avisoAudio;

    public ParticleSystem ensaladaParticulas;
    public ParticleSystem tomateParticulas;
    public ParticleSystem cebollaParticulas;
    public ParticleSystem champiñonParticulas;
    public ParticleSystem carneParticulas;
    public ParticleSystem pepinoParticulas;



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
                    new_obj = (GameObject)Instantiate(cutTomato_prefab, point.position, cutTomato_prefab.transform.rotation);
                }
                else if (obj.name.Contains("cebolla"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutOnion_prefab, point.position, cutOnion_prefab.transform.rotation);
                }
                else if (obj.name.Contains("champiñon"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutMushroom_prefab, point.position, cutMushroom_prefab.transform.rotation);
                }
                else if (obj.name.Contains("chuleta"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutMeet_prefab, point.position, cutMeet_prefab.transform.rotation);
                }
                else if (obj.name.Contains("lechuga"))
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutLetucce_prefab, point.position, cutLetucce_prefab.transform.rotation);
                }
                else
                {
                    Destroy(obj);
                    new_obj = (GameObject)Instantiate(cutPickle_prefab, point.position, cutPickle_prefab.transform.rotation);
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
        cortarAudio.Play();


        if (obj.name.Contains("tomate"))
        {
            tomateParticulas.gameObject.SetActive(true); 
        }
        else if (obj.name.Contains("cebolla"))
        {
            cebollaParticulas.gameObject.SetActive(true); 
        }
        else if (obj.name.Contains("champiñon"))
        {
            champiñonParticulas.gameObject.SetActive(true);
        }
        else if (obj.name.Contains("lechuga"))
        {
            ensaladaParticulas.gameObject.SetActive(true);
        }
        else if (obj.name.Contains("chuleta"))
        {
            carneParticulas.gameObject.SetActive(true);
        }
        else if (obj.name.Contains("pepinillo"))
        {
            pepinoParticulas.gameObject.SetActive(true); 
        }


        statusBar.Cut(); 
    }

    void FinishCuttingAction()
    {
        cortarAudio.Stop();
        avisoAudio.Play(); 
        img.enabled = true;
        player.transform.parent = null;
        player.GetComponent<MoveChef>().can_move = true;

        tomateParticulas.gameObject.SetActive(false);
        cebollaParticulas.gameObject.SetActive(false);
        champiñonParticulas.gameObject.SetActive(false);
        ensaladaParticulas.gameObject.SetActive(false);
        carneParticulas.gameObject.SetActive(false);
        pepinoParticulas.gameObject.SetActive(false);
    }


}
