using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MesaEntrega : MonoBehaviour
{


    GameObject obj;
    public GameObject coins;
    public GameObject coins2; 
    public GameObject timeScript;

    public ParticleSystem coinsParticles; 

    public int escena; 
    
    public Transform puntoEntrega; 
    public bool tieneObjeto;

    public AudioSource audioEntregaCorrecto;
    public AudioSource audioEntregaIncorrecto;

    public Image correcto;
    public Image mal;

    int puntuacion;
    int timeMax;
    float time;
    private Color alphaColor;
    private float timeToFade = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        /*recetas = new List<string>();
        recetasParaHacer = new List<string>();
        recetas.Add("plato_lechuga_cebolla");
        recetas.Add("plato_lechuga_tomate");
        recetas.Add("plato_lechuga_tomate_cebolla");
        recetas.Add("plato_lechuga_tomate_cebolla");
        recetas.Add("plato_sopa_tomate");
        recetas.Add("plato_pan_ham_tomate_lechuga");*/

        //Random rnd_t = new Random();
        timeMax = Random.Range(10, 21);
        time = 0;
        coinsParticles.gameObject.SetActive(false); 
        //string plato = recetas[Random.Range(0, 6)];
        //recetasParaHacer.Add("plato_lechuga_tomate");
        //Debug.Log("plato_lechuga_tomate");
        correcto.enabled = false;
        puntuacion = 0;
        mal.enabled = false; 

    }

    // Update is called once per frame
    void Update()
    {
        /*if (time >= timeMax)
        {
           // Random rnd = new Random();
            string plato = recetas[Random.Range(0, 6)];
            recetasParaHacer.Add(plato);
            Debug.Log(plato);
            time = 0;
            timeMax = Random.Range(30, 40);
        }
        else time += Time.deltaTime; */

    }

    public void EntregarPlato(GameObject o)
    {

        o.transform.parent = puntoEntrega;
        o.transform.position = puntoEntrega.position;
        tieneObjeto = true;


        o.GetComponent<Rigidbody>().useGravity = true;
        o.GetComponent<Rigidbody>().isKinematic = false;
        o.GetComponent<Collider>().enabled = true;

        string plato = o.name;
        obj = o;
        int receta = ConvertNameToIdex(plato);
        List<int> recetas = GetRecetas(); 
        if (recetas.Contains(receta))
        {
            RemoveReceta(receta); 
            audioEntregaCorrecto.Play();
            coinsParticles.gameObject.SetActive(true);
            correcto.enabled = true;
            puntuacion += 1;
            coins.GetComponent<TextMesh>().text = "coins: " + puntuacion;
            coins2.GetComponent<TextMesh>().text = "coins: " + puntuacion;
            
        }
        else
        {
            audioEntregaIncorrecto.Play();
            mal.enabled = true;
            puntuacion -= 1;
            coins.GetComponent<TextMesh>().text = "coins: " + puntuacion;
            coins2.GetComponent<TextMesh>().text = "coins: " + puntuacion;
        }

        StartCoroutine(Waiter());
    }

    public GameObject CogerPlato()
    {
        tieneObjeto = false;
        mal.enabled = false;
        correcto.enabled = false;
        return obj;
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(obj);
        coinsParticles.gameObject.SetActive(false);
        correcto.enabled = false;
        tieneObjeto = false;
    } 


    public int ConvertNameToIdex(string name)
    {
        if (name.Contains("plato_lechuga_sola"))
        {
            return 1;
        }
        else if (name.Contains("plato_lechuga_tomate"))
        {
            return 2;
        }
        else if (name.Contains("plato_lechuga_cebolla"))
        {
            return 3;
        }
        else if (name.Contains("plato_sopa_tomate"))
        {
            return 4;
        }
        else if (name.Contains("plato_sopa_cebolla"))
        {
            return 5;
        }
        else if (name.Contains("plato_sopa_champiñon"))
        {
            return 6;
        }
        else if (name.Contains("plato_pan_ham_tomate_lechuga"))
        {
            return 7;
        }
        else if (name.Contains("plato_pan_ham_cebolla_pepinillo"))
        {
            return 8;
        }
        else return -1; 
    }

    List<int> GetRecetas()
    {
        if (escena == 1)
        {
            return timeScript.GetComponent<Countdown>().recetas_actuales(); 
        }
        else if(escena == 2)
        {
            return timeScript.GetComponent<Countdown2>().recetas_actuales();
        }
        else if (escena== 3)
        {
            return timeScript.GetComponent<Countdown3>().recetas_actuales();
        }
        else if (escena == 4)
        {
            return timeScript.GetComponent<Countdown4>().recetas_actuales();
        }
        else
        {
            return timeScript.GetComponent<Countdown5>().recetas_actuales();
        }
    }
    
    void RemoveReceta( int id)
    {
        if (escena == 1)
        {
            timeScript.GetComponent<Countdown>().eliminar_receta(id); 
        }
        else if(escena == 2)
        {
            timeScript.GetComponent<Countdown2>().eliminar_receta(id);
        }
        else if (escena== 3)
        {
           timeScript.GetComponent<Countdown3>().eliminar_receta(id);
        }
        else if (escena == 4)
        {
            timeScript.GetComponent<Countdown4>().eliminar_receta(id);
        }
        else
        {
            timeScript.GetComponent<Countdown5>().eliminar_receta(id);
        }
    }


}
