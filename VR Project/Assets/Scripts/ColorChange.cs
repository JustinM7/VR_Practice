using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChange : MonoBehaviour
{

    public GameObject grab;
    // Start is called before the first frame update
    public void Set_Red ()
    {


        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void Set_Blue ()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;

    }
}
