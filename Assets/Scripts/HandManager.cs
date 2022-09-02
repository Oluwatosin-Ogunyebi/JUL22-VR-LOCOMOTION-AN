using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandManager : MonoBehaviour
{
    public Animator handAnimator;

    public InputActionReference gripButton;
    void Awake()
    {
        handAnimator = this.GetComponent<Animator>();
    }
    private void Start()
    {
        gripButton.action.started += Grip_Started;
        gripButton.action.canceled += Grip_Released;
    }

    private void Grip_Released(InputAction.CallbackContext obj)
    {
        Released();
    }

    private void Grip_Started(InputAction.CallbackContext obj)
    {
        Gripped();
    }

    public void Gripped()
    {
        handAnimator.SetBool("isGripped", true);
    }

    public void Released()
    {
        handAnimator.SetBool("isGripped", false);
    }

}
