using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;



public class Weapon : MonoBehaviour
{
    [Header("Recoil Settings:")]
    public float recoil_animation_length = .5f;
    public Quaternion original_rot;
    public Quaternion recoil_pos = Quaternion.Euler(45, 0, 0);

    public Quaternion current_recoil_pos;
    public Quaternion new_recoil_pos;

    [Space]
    private float recoil_animation_timmer = .0f;


    [Header("Hand Prefab Settings:")]
    public GameObject hand_pos;
    public Vector3 gun_hand_attach_pos;
    public AnimationCurve curve;
    List<InputDevice> left_hand_device_list = new List<InputDevice>();
    public InputDevice left_hand_control; 


    [Space]

    [Header("Prefabs Settings:")]
    public Transform barrel = null;
    public GameObject bullet_prefab = null; 
    private XRGrabInteractable grab = null;


    void Awake()
    {


         grab = GetComponent<XRGrabInteractable>();



    }


    private void Start()
    {
        print("weapon");
        InputDeviceCharacteristics left_hand_device_char = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(left_hand_device_char, left_hand_device_list);

        left_hand_control = left_hand_device_list[0];




    }

    private void Update()
    {


        left_hand_control.TryGetFeatureValue(CommonUsages.triggerButton, out bool left_trigger);
        //If lefthand is grabbing gun then set weapon to child of left hand, then shoot and activate recoil animation.
        if (left_trigger && grab.isSelected == true)
        {
            transform.SetParent(hand_pos.transform);
            original_rot = transform.rotation;
            ApplyRecoil();

        }




    }
    private void OnEnable()
    {
        grab.onActivate.AddListener(Fire);
    }
    private void OnDisable()
    {
        grab.onActivate.RemoveListener(Fire);

    }
    // Update is called once per frame
    private void Fire(XRBaseInteractor interactor)
    {
        Create_Bullet();
    }

    private void Create_Bullet()
    {
        GameObject bullet_object = Instantiate(bullet_prefab, barrel.position, barrel.rotation);
        projectile projectile = bullet_object.GetComponent<projectile>();
        projectile.shoot();
    }

    

    private void ApplyRecoil()
    {



        float local_scaled_time = recoil_animation_timmer / recoil_animation_length;




        current_recoil_pos = transform.parent.rotation;

        new_recoil_pos = current_recoil_pos * recoil_pos;

        recoil_animation_timmer += Time.deltaTime;

        if (recoil_animation_timmer >= recoil_animation_length)
        {
            recoil_animation_timmer = 0.0f;
        }
        else
        {
            transform.rotation = Quaternion.Slerp(current_recoil_pos, new_recoil_pos, curve.Evaluate(local_scaled_time));
        }


    }



}
