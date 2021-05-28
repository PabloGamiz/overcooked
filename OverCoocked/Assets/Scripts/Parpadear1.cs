using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parpadear1 : MonoBehaviour
{
    public GameObject Press;
    public GameObject Press1;
    private bool enabled;
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Application.LoadLevel("Scenes/escena1");
        }
        else
        {
            StartCoroutine(parpadear());
        }

    }
    IEnumerator parpadear()
    {
        if (enabled)
        {
            yield return new WaitForSeconds(0.5f);
            Press.SetActive(false);
            Press1.SetActive(false);
            enabled = false;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            Press.SetActive(true);
            Press1.SetActive(true);
            enabled = true;
        }
    }
}
