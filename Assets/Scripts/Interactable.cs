using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnInteract;
    [SerializeField]
    private UnityEvent OnTurnOn;
    [SerializeField]
    private UnityEvent OnTurnOff;

    private bool _isOn = false;
    public void Interact() {
        _isOn = !_isOn;
        if (_isOn) {
            OnTurnOn.Invoke();
        } else {
            OnTurnOff.Invoke();
        }
        OnInteract.Invoke();
    }
}
