using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parpadear : MonoBehaviour
{
    public GameObject Press;
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
            Application.LoadLevel("escena1");
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
            yield return new WaitForSeconds(1);
            Press.enabled = false;
            enabled = false;
        }
        else
        {
            yield return new WaitForSeconds(1);
            Press.enabled = true;
            enabled = true;
        }
    }
}
