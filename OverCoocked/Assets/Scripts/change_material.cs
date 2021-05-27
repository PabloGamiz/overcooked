using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class change_material : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
       /* rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];*/
    }

    public void cambiar_material(int numero)
    {
        //rend.sharedMaterial = material[numero];
    }


}
