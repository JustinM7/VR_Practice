using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float launch_force = 10.0f;
    private Rigidbody rigid = null;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void shoot()
    {

        rigid.AddRelativeForce(Vector3.forward * launch_force, ForceMode.Impulse);
        Destroy(gameObject, 5.0f);
    }

}