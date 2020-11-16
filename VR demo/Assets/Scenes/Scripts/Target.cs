using System;
using UnityEngine;
using UnityEngine.Events; 
public class Target : MonoBehaviour
{


    [Serializable] public class HitEvent : UnityEvent<int> { }
    public HitEvent OnHit = new HitEvent();

    void Awake()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        int score = 0; 

        if (collision.gameObject.CompareTag("bullet"))
        {
            if (this.CompareTag("Center"))
            {
                score += 25;
            }
            else if (this.CompareTag("Middle"))
            {
                score += 10;

            }
            else if (this.CompareTag("Outer"))
            {
                score += 5;

            }
        }
        OnHit.Invoke(score);


    }

    private void FigureOutScore( Vector3 hitpos)
    {



    }




}
