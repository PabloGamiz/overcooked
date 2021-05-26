using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MesaEntrega : MonoBehaviour
{
    List<string> recetas;
    List<string> recetasParaHacer;

    GameObject obj;
    public Transform puntoEntrega; 
    public bool tieneObjeto; 

    public Image correcto;
    public Image mal;

    int timeMax;
    float time;
    private Color alphaColor;
    private float timeToFade = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        recetas = new List<string>();
        recetasParaHacer = new List<string>();
        recetas.Add("plato_lechuga_cebolla");
        recetas.Add("plato_lechuga_tomate");
        recetas.Add("plato_lechuga_tomate_cebolla");
        recetas.Add("plato_lechuga_tomate_cebolla");
        recetas.Add("plato_sopa_tomate");
        recetas.Add("plato_pan_ham_tomate_lechuga");

        //Random rnd_t = new Random();
        timeMax = Random.Range(10, 21);
        Debug.Log(timeMax); 
        time = 0;
        string plato = recetas[Random.Range(0, 6)];
        recetasParaHacer.Add("plato_lechuga_tomate");
        Debug.Log("plato_lechuga_tomate");
        correcto.enabled = false;
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

        string plato = o.name;
        obj = o;
        if (recetasParaHacer.Contains(plato))
        {
            recetasParaHacer.Remove(plato); 
            correcto.enabled = true;
            StartCoroutine(Waiter());
        }
        else mal.enabled = true;


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
        correcto.enabled = false;
        tieneObjeto = false;
    }



}
