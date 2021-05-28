using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public GameObject player;
    public GameObject confeti;
    public GameObject countdown;
    public GameObject ready;
    public GameObject Escene;
    public GameObject go;
    public GameObject countdown1;
    public GameObject ready1;
    public GameObject Escene1;
    public GameObject go1;
    int seconds = 150;
    bool takeAway = false;
    bool initial = true;
    bool finish_text = false;

    int numero_recetas;

    private List<GameObject> objetos_recetas;
    private List<int> recetas;

    private GameObject Receta_b;
    private GameObject Receta_1;
    private GameObject Receta_2;
    private GameObject Receta_3;
    private GameObject Receta_4;
    private GameObject Receta_5;
    private GameObject Receta_6;
    private GameObject Receta_7;
    private GameObject Receta_8;

    // Start is called before the first frame update
    void Start()
    {
        numero_recetas = 0;
        player.GetComponent<MoveChef>().can_move = false;
        recetas = new List<int>();
        objetos_recetas = new List<GameObject>();
        initial = true;
        Receta_b = Resources.Load("Receta_b") as GameObject;
        Receta_1 = Resources.Load("Receta_1") as GameObject;
        Receta_2 = Resources.Load("Receta_2") as GameObject;
        Receta_3 = Resources.Load("Receta_3") as GameObject;
        Receta_4 = Resources.Load("Receta_4") as GameObject;
        Receta_5 = Resources.Load("Receta_5") as GameObject;
        Receta_6 = Resources.Load("Receta_6") as GameObject;
        Receta_7 = Resources.Load("Receta_7") as GameObject;
        Receta_8 = Resources.Load("Receta_8") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            SceneManager.LoadScene("Scenes/escena1");
        else if (Input.GetKey(KeyCode.Alpha2))
            SceneManager.LoadScene("Scenes/escena2");
        else if (Input.GetKey(KeyCode.Alpha3))
            SceneManager.LoadScene("Scenes/escena3");
        else if (Input.GetKey(KeyCode.Alpha4))
            SceneManager.LoadScene("Scenes/escena4");
        else if (Input.GetKey(KeyCode.Alpha5))
            SceneManager.LoadScene("Scenes/escena5");
        if (initial)
        {
            StartCoroutine(InitialTexts());
            initial = false;

        }
        else if (!initial && takeAway && seconds > 0)
        {
            StartCoroutine(TimerTake());
        }
        else if (seconds == 0)
        {
            player.GetComponent<MoveChef>().can_move = false;
            Debug.Log("dentro de 0 segundos");  
            confeti.SetActive(true);
            StartCoroutine(esperar_confeti());
            confeti.SetActive(false);
            SceneManager.LoadScene("Scenes/escena2");
        }

    }
    IEnumerator esperar_confeti()
    {
        yield return new WaitForSeconds(3);
    }

    IEnumerator InitialTexts()
    {
        yield return new WaitForSeconds(3);
        Escene.SetActive(false);
        Escene1.SetActive(false);
        ready.SetActive(true);
        ready1.SetActive(true);
        yield return new WaitForSeconds(2);
        ready.SetActive(false);
        ready1.SetActive(false);
        go.SetActive(true);
        go1.SetActive(true);
        yield return new WaitForSeconds(3);
        go.SetActive(false);
        go1.SetActive(false);
        takeAway = true;
        player.GetComponent<MoveChef>().can_move = true;
    }

    IEnumerator TimerTake()
    {
        takeAway = false;
        if (seconds % 15 == 0)
        {
            Debug.Log("antes de escojer");
            escojerRecetas();

        }
        yield return new WaitForSeconds(1);
        seconds -= 1;
        int d = seconds / 60;
        int r = seconds % 60;
        if (r > 9)
        {
            countdown.GetComponent<TextMesh>().text = d + ":" + r;
            countdown1.GetComponent<TextMesh>().text = d + ":" + r;
        }
        else
        {
            countdown.GetComponent<TextMesh>().text = d + ":0" + r;
            countdown1.GetComponent<TextMesh>().text = d + ":0" + r;
        }
        takeAway = true;
    }

    void escojerRecetas()
    {
        if (numero_recetas < 5)
            ++numero_recetas;
        Debug.Log("dentro escojer");
        int n = Random.Range(1, 9);
        if (n >= 1 && n <= 1)
        {
            recetas.Add(1);
            if (numero_recetas < 5)
                objetos_recetas.Add((GameObject)Instantiate(Receta_1, new Vector3(-5.5f + 2.75f * (numero_recetas - 1), 14, -10.75f), Receta_1.transform.rotation));

        }
        else if (n >= 4 && n <= 6)
        {
            recetas.Add(2);
            if (numero_recetas < 5)
                objetos_recetas.Add((GameObject)Instantiate(Receta_2, new Vector3(-5.5f + 2.75f * (numero_recetas - 1), 14, -10.75f), Receta_2.transform.rotation));
        }
        else
        {
            recetas.Add(4);
            if (numero_recetas < 5)
                objetos_recetas.Add((GameObject)Instantiate(Receta_4, new Vector3(-5.5f + 2.75f * (numero_recetas - 1), 14, -10.75f), Receta_4.transform.rotation));
        }

        Debug.Log("final escojer");
        Debug.Log("tamaño recetas: " + recetas.Count);
    }

    void actualizar_recetas(int n)
    {
        Debug.Log("dentro crear");
        if (recetas.Count < 5 && recetas.Count != 0)
        {
            Debug.Log("dentro <5");
            for (int i = (n - 1); i < recetas.Count; ++i)
            {

                if (recetas[i] == 0)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_b, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_b.transform.rotation));
                else if (recetas[i] == 1)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_1, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_1.transform.rotation));
                else if (recetas[i] == 2)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_2, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_2.transform.rotation));
                else if (recetas[i] == 3)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_3, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_3.transform.rotation));
                else if (recetas[i] == 4)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_4, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_4.transform.rotation));
                else if (recetas[i] == 5)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_5, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_5.transform.rotation));
                else if (recetas[i] == 6)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_6, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_6.transform.rotation));
                else if (recetas[i] == 7)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_7, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_7.transform.rotation));
                else
                    objetos_recetas.Add((GameObject)Instantiate(Receta_8, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_8.transform.rotation));

                Debug.Log("crea objeto");
                //obj.GetComponent<change_material>().cambiar_material(recetas[i]);
                Debug.Log("ha cambiado material");
            }
            numero_recetas = recetas.Count;
        }
        else if (recetas.Count != 0)
        {
            Debug.Log("dentro >=5");
            for (int i = (n - 1); i < 5; ++i)
            {
                if (recetas[i] == 0)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_b, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_b.transform.rotation));
                else if (recetas[i] == 1)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_1, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_1.transform.rotation));
                else if (recetas[i] == 2)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_2, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_2.transform.rotation));
                else if (recetas[i] == 3)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_3, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_3.transform.rotation));
                else if (recetas[i] == 4)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_4, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_4.transform.rotation));
                else if (recetas[i] == 5)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_5, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_5.transform.rotation));
                else if (recetas[i] == 6)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_6, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_6.transform.rotation));
                else if (recetas[i] == 7)
                    objetos_recetas.Add((GameObject)Instantiate(Receta_7, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_7.transform.rotation));
                else
                    objetos_recetas.Add((GameObject)Instantiate(Receta_8, new Vector3(-5.5f + 2.75f * i, 14, -10.75f), Receta_8.transform.rotation));
                //  GameObject obj = (GameObject)Instantiate(Receta, new Vector3(-5.5f + 2.75f * i, 14, -10.6f), Receta.transform.rotation);
                //  obj.GetComponent<change_material>().cambiar_material(recetas[i]);
            }
            numero_recetas = 5;
        }
        //Debug.Log("final crear");
    }


    public List<int> recetas_actuales()
    {
        List<int> aux = new List<int>();
        if (recetas.Count < 5)
        {
            for (int i = 0; i < recetas.Count; ++i)
            {
                aux.Add(recetas[i]);
            }
        }
        else
        {
            for (int i = 0; i < 5; ++i)
            {
                aux.Add(recetas[i]);
            }
        }
        return aux;
    }


    public void eliminar_receta(int id)
    {
        bool borrada = false;
        int i = 0;
        while (!borrada)
        {
            if (recetas[i] == id)
            {
                recetas.RemoveAt(i);
                borrada = true;
                Destroy(objetos_recetas[i]);
            }

            ++i;
        }
        if (objetos_recetas.Count < 5)
        {
            for (int j = i - 1; j < recetas.Count; ++j)
            {
                Destroy(objetos_recetas[j]);
            }
            --numero_recetas;
        }
        else
        {
            for (int j = i - 1; j < 5; ++j)
            {
                Destroy(objetos_recetas[j]);
            }
        }


        actualizar_recetas(i);
    }

}