using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public  class StateMachine : MonoBehaviour
{
    private Dictionary<Type, EmptyState> _availiblestate;

    public EmptyState CurrentState { get; private set; }
    public event Action<EmptyState> OnStateChange;


    public void SetState(Dictionary<Type, EmptyState> state)
    {
        _availiblestate = state;
    }

    private void Update()
    {
        if (CurrentState == null)
        {
            CurrentState = _availiblestate.Values.First();
        }
        var nextState = CurrentState?.Tick();

        if (nextState != null && nextState != CurrentState?.GetType())
        {
            SwitchToNewState(nextState);
        }
    }


    public void SwitchToNewState(Type nextState)
    {
        CurrentState = _availiblestate[nextState];
        OnStateChange?.Invoke(CurrentState);
    }
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator Holding()
    {
        yield break;
    }
    public virtual IEnumerator Empty()
    {
        yield break;
    }
    public virtual IEnumerator Pointing()
    {
        yield break;
    }

    public virtual IEnumerator Fist()
    {
        yield break;
    }

    public virtual IEnumerator Shoot()
    {
        yield break;
    }
}
