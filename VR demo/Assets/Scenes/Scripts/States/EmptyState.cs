using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EmptyState 
{
     public EmptyState(GameObject gameObject)
    {

        this.gameObject = gameObject;
        this.transform = gameObject.transform;
    }
    protected GameObject gameObject;
    protected Transform transform;

    public abstract Type Tick();

}
