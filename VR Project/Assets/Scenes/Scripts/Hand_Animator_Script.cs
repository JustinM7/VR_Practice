using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;

public class Hand_Animator_Script : MonoBehaviour
{


    List<InputDevice> left_hand_device_list = new List<InputDevice>();
    public InputDevice left_hand_control;
    private XRGrabInteractable grab = null;
    private StateMachine _currentstate;


    private Animator hand_animator = null;

    // Start is called before the first frame update


    // Update is called once per frame

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, EmptyState>
        {
            {typeof(HoldingState) ,new HoldingState(this)},
            {typeof(FistState) ,new FistState(this)}
        };
        GetComponent<StateMachine>().SetState(states);
    }


     void Start()
    {

        hand_animator = GetComponent<Animator>();

        InputDeviceCharacteristics left_hand_device_char = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(left_hand_device_char, left_hand_device_list);
        left_hand_control = left_hand_device_list[0];
    }



    public void OnFist()
    {
        StartCoroutine(_currentstate.Fist());
    }

    public void OnEmpty()
    {
        StartCoroutine(_currentstate.Empty());
    }

    public void OnPoint()
    {
        StartCoroutine(_currentstate.Pointing());
    }

    public void SetState(StateMachine state)
    {
        _currentstate = state;
        StartCoroutine(_currentstate.Start());

    }

    void UpdateHandAnimation()
    {

        left_hand_control.TryGetFeatureValue(CommonUsages.primaryButton, out bool Primary_Button);

        if (left_hand_control.TryGetFeatureValue(CommonUsages.grip, out float left_grip_value))
        {

            hand_animator.SetFloat("Grab", left_grip_value);
            if (left_grip_value >= 1 )
            {

            }

        }
        else
        {
            hand_animator.SetFloat("Grab", 0);

        }



        if (Primary_Button)
        {
            hand_animator.SetBool("Point", Primary_Button);

        }
        else
        {
            hand_animator.SetBool("Point", false);

        }


    }

    void Update()
    {
        UpdateHandAnimation();
    }
}
