using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tiempo_final());
    }

    void Update()
    {

    }
    
    IEnumerator Tiempo_final()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scenes/Title scene");
    }
}
