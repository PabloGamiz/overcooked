using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public GameObject finish;
    public GameObject countdown;
    public int seconds = 150;
    public bool takeAway = false;
    public bool initial = false;
   
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "2:30";
    }

    // Update is called once per frame
    void Update()
    {
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
            finish.enable = true;
            yield return new WaitForSeconds(5);
            Application.LoadLevel("escena2");

        }
    }

    IEnumerator InitialTexts()
    {
        yield return new WaitForSeconds(3);
        escena.enable = false;
        ready.enable = true;
        yield return new WaitForSeconds(2);
        ready.enable = false;
        go.enable = true;
        yield return new WaitForSeconds(3);
        go.enable = false;
    }

    IEnumerator TimerTake()
    {
        takeAway = true;
        yield return new WaitForSeconds(1);
        seconds -= 1;
        int d = seconds / 60;
        int r = seconds % 60;
        if (r > 9)
            textDisplay.GetComponent<Text>().text = d + ":" + r;
        else
            textDisplay.GetComponent<Text>().text = d + ":0" + r;
        takeAway = false;    
    }
}
