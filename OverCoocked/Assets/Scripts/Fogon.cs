using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fogon : MonoBehaviour
{
    public GameObject obj;
    public bool tieneObjecto;
    public bool tipoOlla;
    public Transform posiconObj;

    public bool on; 

    public StatusBar statusBar;
    int statusObject;
    float time;

    public ParticleSystem humoParticulas;
    public ParticleSystem fuegoParticulas;

    public Image acabado;
    public MaskableGraphic peligro;

    public bool cocinado;
    bool quemando;
    bool warning; 
    float tiempoQuemado;
    

    // Start is called before the first frame update
    void Start()
    {
        tieneObjecto = true;
        cocinado = false;
        quemando = false;
        warning = false;
        tipoOlla = true; 

        peligro.enabled = false;
        statusBar.SetMax(15);
        time = 0;
        
        humoParticulas.gameObject.SetActive(false);
        fuegoParticulas.gameObject.SetActive(false);
        statusObject = -1;

        acabado.enabled = false;
        statusBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (statusBar.hasFinished && !cocinado && !quemando && tieneObjecto)
        {
            obj.GetComponent<Olla>().alimentoTerminado = true; 
            acabado.enabled = true;
            cocinado = true;
            tiempoQuemado = 0;

        }

        if (cocinado && !quemando && tieneObjecto)
        {
            time += Time.deltaTime;
            if (!warning)
            {
                InvokeRepeating("ToggleState", 3.2f, 0.2f);
                warning = true;             
            }

            if (time >= 3 && time <= 8)
            {     
                acabado.enabled = false;
            }
            else if (time> 8)
            {
                cocinado = false;
                quemando = true;
                CancelInvoke("ToggleState");
                peligro.enabled = false;
                humoParticulas.gameObject.SetActive(false);
                fuegoParticulas.gameObject.SetActive(true);
            }

        }
        
    }

    public bool AddFood(GameObject alim)
    { 
        if (tieneObjecto)
        {
            if (tipoOlla)
            {
                if (alim.name.Contains("tomate_cortado") || alim.name.Contains("cebolla_cortada") || alim.name.Contains("champiñon_cortado"))
                {

                    if (obj.GetComponent<Olla>().numAlim == 0)
                    {
                        humoParticulas.gameObject.SetActive(true);
                        cocinado = false; 
                        statusBar.Cut();
                        GameObject newObject = obj.GetComponent<Olla>().AñadirAlimentoOlla(alim, posiconObj);
                        Destroy(obj);
                        obj = newObject;
                        return true;
                    }
                    else if (obj.GetComponent<Olla>().numAlim <= 2 && alim.name.Contains(obj.GetComponent<Olla>().tipoAlimento))
                    {
                        statusBar.time = statusBar.time - 6;
                        GameObject newObject = obj.GetComponent<Olla>().AñadirAlimento(alim, posiconObj);
                        Destroy(obj);
                        obj = newObject;
                        return true;
                    }

                }

            }
            else
            {
                Debug.Log("Es sarten");
            }
        }
        return false; 
    }

    public GameObject CogerUtensilioCocina()
    {
        //Coge el utensilio del fogon si este tiene
        time = 0;
        //obj.GetComponent<Olla>().alimentoTerminado = false;
        tieneObjecto = false; 
        cocinado = false;
        warning = false;

        //Desactiva las imagenes de información del fogon
        ApagarFogon(); 

        return obj; 
    }

    public void ColocarUtensilioCocina(GameObject utensilio)
    {
        /* Coloca el utensilio que ha cogido anteriormente en el fogon*/

        tieneObjecto = true;
        obj = utensilio; 
        utensilio.transform.parent = posiconObj;
        utensilio.transform.position = posiconObj.position;

        if (utensilio.GetComponent<Olla>().tieneAlimento)
        {
            //Empieza de nuevo la accion de cocinar
            humoParticulas.gameObject.SetActive(true);
            statusBar.Cut();
        }

    }

    public string AñadirComidaPlato()
    {
        GameObject newOlla;
        string tipoPlato; 
        if (tipoOlla)
        {
            string alimento = obj.GetComponent<Olla>().tipoAlimento;

            if (alimento == "tomate") tipoPlato = "sopa_tomate";
            else if (alimento == "cebolla") tipoPlato = "sopa_cebolla";
            else tipoPlato = "sopa_champiñon"; 

            newOlla = obj.GetComponent<Olla>().VaciarOlla(posiconObj);
            Destroy(obj);
            obj = newOlla; 
        }
        else
        {
            tipoPlato = "carne";
        }

        ApagarFogon(); 
        return tipoPlato; 
    }


    void ToggleState()
    {
        //Función que hace parpadear la imagen de peligro
        peligro.enabled = !peligro.enabled;
    }

    void ApagarFogon()
    {
        cocinado = false;
        warning = false; 
        humoParticulas.gameObject.SetActive(false);
        statusBar.AcabaAccion();
        statusBar.hasFinished = false; 
        acabado.enabled = false;
        peligro.enabled = false;
        CancelInvoke("ToggleState");
    }
}
