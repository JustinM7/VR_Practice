using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ColorChangeGrab : MonoBehaviour
{


    public XRGrabInteractable grab;
    // Start is called before the first frame update
    Color original_color;
    void Start()
    {
     original_color = GetComponent<MeshRenderer>().material.color;

    }

    // Update is called once per frame
    void Update()
    {
        set_color(Color.red, original_color);
    }

    public void set_color(Color cust_color,Color original_color)
    {
        if (grab.isSelected == true)
        {
            GetComponent<MeshRenderer>().material.color = cust_color;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = original_color;

        }
    }
}
