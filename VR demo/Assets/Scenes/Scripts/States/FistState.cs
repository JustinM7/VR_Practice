using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class FistState : EmptyState
{

    private Hand_Animator_Script _hand;

    public FistState(Hand_Animator_Script hand) : base(hand.gameObject)
    {
        _hand = hand;
    }

    public override Type Tick()
    {
        return typeof(EmptyState);
    }
}
