using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    private TextMesh textMesh = null;


    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();

    }


    public void showScore(int score)
    {

        textMesh.text = score.ToString(); 

    }
}
