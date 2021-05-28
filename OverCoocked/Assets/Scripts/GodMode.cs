using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public GameObject player; 
    public GameObject fogon1;
    public GameObject fogon2;

    public GameObject mesaCortar1;
    public GameObject mesaCortar2;

    public GameObject contrl;
    public GameObject plato; 
    public int escena; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnearPlato();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            CompletarAcciones();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ModoInvencible(); 
        }
    }


    void SpawnearPlato()
    {
        if (escena == 1)
        {
            SpawnearPlatoEscena1(); 
        }
        else if (escena == 2)
        {
            SpawnearPlatoEscena2();
        }
        else if (escena == 3)
        {
            SpawnearPlatoEscena3();
        }
        else if (escena == 4)
        {
            SpawnearPlatoEscena4();
        }
        else
        {
            SpawnearPlatoEscena5();
        }
    }

    void CompletarAcciones()
    {
        if (mesaCortar1.GetComponent<InfoTable>().hasObject)
        {
            mesaCortar1.GetComponent<CuttingTable>().statusBar.hasFinished = true;
            mesaCortar1.GetComponent<CuttingTable>().statusBar.AcabaAccion();
        }
        if (mesaCortar2.GetComponent<InfoTable>().hasObject)
        {
            mesaCortar2.GetComponent<CuttingTable>().statusBar.hasFinished = true;
            mesaCortar2.GetComponent<CuttingTable>().statusBar.AcabaAccion();
        }


        if (fogon1.GetComponent<Fogon>().tieneAlimento)
        {
            fogon1.GetComponent<Fogon>().statusBar.hasFinished = true;
            fogon1.GetComponent<Fogon>().statusBar.AcabaAccion(); 
        }
        if (fogon2.GetComponent<Fogon>().tieneAlimento)
        {
            fogon2.GetComponent<Fogon>().statusBar.hasFinished = true;
            fogon2.GetComponent<Fogon>().statusBar.AcabaAccion();
        }


    }

    void ModoInvencible()
    {
        fogon1.GetComponent<Fogon>().puedeQuemarse = !fogon1.GetComponent<Fogon>().puedeQuemarse; 
        fogon2.GetComponent<Fogon>().puedeQuemarse = !fogon2.GetComponent<Fogon>().puedeQuemarse; 

    }


    void SpawnearPlatoEscena1()
    {
        List<int> recetas = contrl.GetComponent<Countdown>().recetas_actuales(); 
        if ( recetas.Count > 0)
        {
            if(player.GetComponent<Pickup>().holdingObject)
            {
                player.GetComponent<Pickup>().DejarCaerObjeto(); 
            }
            int id = recetas[0];
            GameObject platoT = plato.GetComponent<Plato>().PlatosGodMode(id);
            player.GetComponent<Pickup>().CogerObjeto(platoT); 


        }
    }


    void SpawnearPlatoEscena2()
    {
        List<int> recetas = contrl.GetComponent<Countdown2>().recetas_actuales();
        if (recetas.Count > 0)
        {
            if (player.GetComponent<Pickup>().holdingObject)
            {
                player.GetComponent<Pickup>().DejarCaerObjeto();
            }
            int id = recetas[0];
            GameObject platoT = plato.GetComponent<Plato>().PlatosGodMode(id);
            player.GetComponent<Pickup>().CogerObjeto(platoT);


        }
    }


    void SpawnearPlatoEscena3()
    {
        List<int> recetas = contrl.GetComponent<Countdown3>().recetas_actuales();
        if (recetas.Count > 0)
        {
            if (player.GetComponent<Pickup>().holdingObject)
            {
                player.GetComponent<Pickup>().DejarCaerObjeto();
            }
            int id = recetas[0];
            GameObject platoT = plato.GetComponent<Plato>().PlatosGodMode(id);
            player.GetComponent<Pickup>().CogerObjeto(platoT);


        }
    }


    void SpawnearPlatoEscena4()
    {
        List<int> recetas = contrl.GetComponent<Countdown4>().recetas_actuales();
        if (recetas.Count > 0)
        {
            if (player.GetComponent<Pickup>().holdingObject)
            {
                player.GetComponent<Pickup>().DejarCaerObjeto();
            }
            int id = recetas[0];
            GameObject platoT = plato.GetComponent<Plato>().PlatosGodMode(id);
            player.GetComponent<Pickup>().CogerObjeto(platoT);


        }
    }


    void SpawnearPlatoEscena5()
    {
        List<int> recetas = contrl.GetComponent<Countdown5>().recetas_actuales();
        if (recetas.Count > 0)
        {
            if (player.GetComponent<Pickup>().holdingObject)
            {
                player.GetComponent<Pickup>().DejarCaerObjeto();
            }
            int id = recetas[0];
            GameObject platoT = plato.GetComponent<Plato>().PlatosGodMode(id);
            player.GetComponent<Pickup>().CogerObjeto(platoT);


        }
    }
}
