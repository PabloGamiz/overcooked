using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public List<int> recetas;
    public GameObject Receta;
    public GameObject finish;
    public GameObject countdown;
    public GameObject ready;
    public GameObject Escene1;
    public GameObject go;
    public int seconds = 150;
    public bool takeAway = false;
    public bool initial = false;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("dentro de start");
        recetas = new List<int>();

    }

    // Update is called once per frame
    IEnumerator Update()
    {
        Debug.Log("dentro de update");
        if (initial == true)
        {
            StartCoroutine(InitialTexts());
            initial = false;
        }
        else if(initial == false && takeAway == false && seconds > 0)
        {
            StartCoroutine(TimerTake());
        }
        else
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Scenes/escena2");

        }
    }

    IEnumerator InitialTexts()
    {
        Debug.Log("dentro de texto iniciales");
        yield return new WaitForSeconds(3);
        Escene1.SetActive(false);
        ready.SetActive(true);
        yield return new WaitForSeconds(2);
        ready.SetActive(false);
        go.SetActive(true);
        yield return new WaitForSeconds(3);
        go.SetActive(false);
        Debug.Log("final de texto iniciales");
    }

    IEnumerator TimerTake()
    {
        takeAway = true;
        yield return new WaitForSeconds(1);
        seconds -= 1;
        int d = seconds / 60;
        int r = seconds % 60;
        if (r > 9)
            countdown.GetComponent<Text>().text = d + ":" + r;
        else
            countdown.GetComponent<Text>().text = d + ":0" + r;
        takeAway = false;    
    }

    void escojerRecetas()
    {
        int n = Random.Range(1, 9);
        if (n >=1 && n<=3)
        {
            recetas.Add(1);
        }
        else if (n >= 4 && n <= 6)
        {
            recetas.Add(2);
        }
        else
        {
            recetas.Add(4);
        }
    }

    void crear_recetas(List<int> recetas)
    {
        if (recetas.Count < 5 && recetas.Count != 0) {
            for (int i = 0; i < recetas.Count; ++i)
            {
                GameObject obj = (GameObject)Instantiate(Receta, new Vector3(-5.5f + 2.75f * i, 14, -11.5f), Receta.transform.rotation);
                obj.GetComponent<change_material>().cambiar_material(recetas[i]);
            }
        }
        else if (recetas.Count != 0) {
            for (int i = 0; i < 5; ++i)
            {
                GameObject obj = (GameObject)Instantiate(Receta, new Vector3(-5.5f + 2.75f * i, 14, -11.5f), Receta.transform.rotation);
                obj.GetComponent<change_material>().cambiar_material(recetas[i]);
            }
        }
    }

}
