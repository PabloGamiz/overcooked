using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extintor : MonoBehaviour
{
    public bool encendido;
    public bool puedoApagar;
    public GameObject fogon; 
    public ParticleSystem humoParticulas;

    float time; 
    // Start is called before the first frame update
    void Start()
    {
        time = 0; 
        encendido = false;
        humoParticulas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (puedoApagar && encendido)
        {
            if (time < 2)
            {
                time += Time.deltaTime;
            }
            else
            {
                puedoApagar = false;
                fogon.GetComponent<Fogon>().ApagarFuego(); 
            }
            
        }
        else
        {
           // Debug.Log("No puedo");
        }

    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name.Contains("fogon") )
        {
            if (collision.gameObject.GetComponent<Fogon>().quemando)
            {
                time = 0;
                
                puedoApagar = true;
                fogon = collision.gameObject; 
            }
        }
        else
        {
            //puedoApagar = false;
            //time = 0;
        }

    }

    void OnTriggerExit(Collider collision)
    {

        puedoApagar = false;
        //time = 0; 

    }

    public void EncenderApagarExtintor()
    {
        if (encendido)
        {
            time = 0; 
            encendido = false;
            humoParticulas.gameObject.SetActive(false);
        }
        else
        {
            time = 0;
            encendido = true;
            humoParticulas.gameObject.SetActive(true);
        }
    }
}
