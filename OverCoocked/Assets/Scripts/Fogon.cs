using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fogon : MonoBehaviour
{
    public GameObject obj;
    public bool tieneObjecto;
    public bool tipoOlla;

    public Transform posicionOlla;
    public Transform posicionSarten;

    public AudioSource boiling;
    public AudioSource freirAudio; 
    public AudioSource alarmaIncendios;
    public AudioSource fuegoAudio; 
    public AudioSource avisoAcabadoAudio; 

    public bool on; 

    public StatusBar statusBar;
    int statusObject;
    float time;

    public ParticleSystem humoParticulas;
    public ParticleSystem fuegoParticulas;

    public Image acabado;
    public MaskableGraphic peligro;

    public bool cocinado;
    public bool quemando;
    bool warning; 
    float tiempoQuemado;
    

    // Start is called before the first frame update
    void Start()
    {
        tieneObjecto = true;
        cocinado = false;
        quemando = false;
        warning = false;

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
            if (tipoOlla)
            {
                obj.GetComponent<Olla>().alimentoTerminado = true;
                
            }
            else
            {

                GameObject newObject = obj.GetComponent<Sarten>().AlimentoHecho(posicionSarten);
                Destroy(obj);
                obj = newObject;
                obj.GetComponent<Sarten>().alimentoTerminado = true;
            }
            avisoAcabadoAudio.Play(); 
            acabado.enabled = true;
            cocinado = true;
            tiempoQuemado = 0;
            time = 0; 

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
                boiling.Stop();
                freirAudio.Stop();
                fuegoAudio.Play();
                alarmaIncendios.Play(); 
            }

        }
        
    }

    public bool AddFood(GameObject alim)
    { 
        if (tieneObjecto)
        {
            Debug.Log("Estoy aqui");
            if (tipoOlla)
            {
                if (alim.name.Contains("tomate_cortado") || alim.name.Contains("cebolla_cortada") || alim.name.Contains("champiñon_cortado"))
                {

                    if (obj.GetComponent<Olla>().numAlim == 0)
                    {
                        boiling.Play();
                        humoParticulas.gameObject.SetActive(true);
                        cocinado = false; 
                        statusBar.Cut();
                        GameObject newObject = obj.GetComponent<Olla>().AñadirAlimentoOlla(alim, posicionOlla);
                        Destroy(obj);
                        obj = newObject;
                        return true;
                    }
                    else if (obj.GetComponent<Olla>().numAlim <= 2 && alim.name.Contains(obj.GetComponent<Olla>().tipoAlimento))
                    {
                        statusBar.time = statusBar.time - 6;
                        GameObject newObject = obj.GetComponent<Olla>().AñadirAlimento(alim, posicionOlla);
                        Destroy(obj);
                        obj = newObject;
                        return true;
                    }

                }
            }
            else //Tipo sarten
            {
                Debug.Log("Estoy aqui"); 
                if (alim.name.Contains("chuleta_cortada"))
                {
                    freirAudio.Play(); 
                    humoParticulas.gameObject.SetActive(true);
                    cocinado = false;
                    statusBar.Cut();
                    GameObject newObject = obj.GetComponent<Sarten>().AñadirAlimento(alim, posicionSarten);
                    Destroy(obj);
                    obj = newObject;
                    return true;
                }
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
        tipoOlla = false; 
        cocinado = false;
        warning = false;
        boiling.Stop();
        obj.GetComponent<BoxCollider>().enabled = true;


        //Desactiva las imagenes de información del fogon
        ApagarFogon(); 

        return obj; 
    }

    public void ColocarUtensilioCocina(GameObject utensilio)
    {
        /* Coloca el utensilio que ha cogido anteriormente en el fogon*/
        tieneObjecto = true;
        obj = utensilio;
        utensilio.GetComponent<Rigidbody>().isKinematic = true;
        

        if (utensilio.name.Contains("olla"))
        {
            tipoOlla = true; 
            utensilio.transform.parent = posicionOlla;
            utensilio.transform.position = posicionOlla.position;
            utensilio.transform.localRotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));


            if (utensilio.GetComponent<Olla>().tieneAlimento)
            {
                utensilio.GetComponent<BoxCollider>().enabled = false;
                //Empieza de nuevo la accion de cocinar
                humoParticulas.gameObject.SetActive(true);
                boiling.Play();
                statusBar.Cut();
                
            }
        }
        else
        {
            tipoOlla = false; 
            utensilio.transform.parent = posicionSarten;
            utensilio.transform.position = posicionSarten.position;
            utensilio.transform.rotation =posicionSarten.rotation;

            if (utensilio.GetComponent<Sarten>().tieneAlimento)
            {
                utensilio.GetComponent<BoxCollider>().enabled = false;
                //Empieza de nuevo la accion de cocinar
                humoParticulas.gameObject.SetActive(true);
                statusBar.Cut();
            }
        }
       

        

    }

    public string AñadirComidaPlato()
    {
        GameObject newUtensilio;
        string tipoPlato; 
        if (tipoOlla)
        {
            string alimento = obj.GetComponent<Olla>().tipoAlimento;

            if (alimento == "tomate") tipoPlato = "sopa_tomate";
            else if (alimento == "cebolla") tipoPlato = "sopa_cebolla";
            else tipoPlato = "sopa_champiñon"; 

            newUtensilio = obj.GetComponent<Olla>().VaciarOlla(posicionOlla);
            
        }
        else
        {
            tipoPlato = "carne";
            newUtensilio = obj.GetComponent<Sarten>().VaciarSarten(posicionSarten);
        }

        Destroy(obj);
        boiling.Stop();
        freirAudio.Stop();
        obj = newUtensilio;
        obj.GetComponent<BoxCollider>().enabled = false;
        obj.GetComponent<Rigidbody>().isKinematic = true;
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
        freirAudio.Stop();
        boiling.Stop(); 
        CancelInvoke("ToggleState");
    }

    public void ApagarFuego()
    {
        quemando = false;
        GameObject newUtensilio;
        
        if (tipoOlla)
        {
            newUtensilio = obj.GetComponent<Olla>().VaciarOlla(posicionOlla);
        }
        else
        {
            newUtensilio = obj.GetComponent<Sarten>().VaciarSarten(posicionSarten);
        }
        fuegoParticulas.gameObject.SetActive(false);
        Destroy(obj);
        obj = newUtensilio;
        alarmaIncendios.Stop();
        fuegoAudio.Stop(); 
        ApagarFogon(); 

    }
}
