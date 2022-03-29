using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class Teleport_Toggle : MonoBehaviour
{
    [SerializeField] private InputActionReference TeleportToggle;

    public UnityEvent OnTeleportActivate, OnTeleportCancel;

    private void OnEnable()
    {
        TeleportToggle.action.performed += ActivateTeleport;
        TeleportToggle.action.canceled += DeactivateTeleport;
    }

    private void OnDisable()
    {
        TeleportToggle.action.performed -= ActivateTeleport;
        TeleportToggle.action.canceled -= DeactivateTeleport;
    }

    private void DeactivateTeleport(InputAction.CallbackContext obj) => OnTeleportActivate.Invoke();

    private void ActivateTeleport(InputAction.CallbackContext obj) => Invoke("DisableTeleport", 0.1f);

    private void DisableTeleport() => OnTeleportCancel.Invoke();
}
