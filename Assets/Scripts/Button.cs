using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public Transform buttonNormal;
    public Transform buttonPressed;
    public Transform buttonReleased;

    public UnityEvent onButtonPressed;
    public UnityEvent onButtonReleased;


    public void OnPressed()
    {
        buttonNormal.position = buttonPressed.position;
        onButtonPressed.Invoke();
    }

    public void OnReleased()
    {
        buttonNormal.position = buttonReleased.position;
        onButtonReleased.Invoke();
    }
}
