using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
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
