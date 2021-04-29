using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingTable : MonoBehaviour
{
    public bool hasObject;
    public StatusBar statusBar;
    int statusObject;


    // Start is called before the first frame update
    void Start()
    {
        hasObject = false;
        statusBar.SetMax(10);
        statusBar.gameObject.SetActive(false);
        statusObject = -1;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void CutObject()
    {
        if (statusObject == -1) StartCuttingAction(); 
        else if (statusObject > -1 && statusObject < 10)
        {
            statusObject++;
            statusBar.SetStatus(statusObject);
        }
        else FinishCuttingAction();
        
    }

    void StartCuttingAction()
    {
        statusObject = 0;
        statusBar.SetStatus(statusObject);
        statusBar.gameObject.SetActive(true);
    }


    void FinishCuttingAction()
    {
        statusObject = -1; 
        statusBar.gameObject.SetActive(false);
    }

}
