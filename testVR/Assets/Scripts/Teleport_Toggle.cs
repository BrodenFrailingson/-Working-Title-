using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System;

public class Teleport_Toggle : MonoBehaviour
{
    static private bool m_TeleportIsActive = false;

    public enum ControllerType 
    {
        RightHand,
        LeftHand
    }

    [SerializeField] private ControllerType m_TargetController;
    [SerializeField] private InputActionAsset m_InputAction;
    [SerializeField] private XRRayInteractor m_RayInteractor;
    [SerializeField] private TeleportationProvider m_TeleportProvider;

    private InputAction m_ThumbStickInputAction, m_TeleportActive, m_TeleportCancel;

    private void Start()
    {
        m_RayInteractor.enabled = false;

        m_TeleportActive = m_InputAction.FindActionMap("XRI " + m_TargetController.ToString()).FindAction("Teleport Mode Activate");
        m_TeleportActive.Enable();
        m_TeleportActive.performed += OnTeleportActivate;

        m_TeleportCancel = m_InputAction.FindActionMap("XRI " + m_TargetController.ToString()).FindAction("Teleport Mode Cancel");
        m_TeleportCancel.Enable();
        m_TeleportCancel.performed += OnTeleportCancel;

        m_ThumbStickInputAction = m_InputAction.FindActionMap("XRI " + m_TargetController.ToString()).FindAction("Move");
    }

    private void Update()
    {
        if (!m_TeleportIsActive || !m_RayInteractor.enabled || m_ThumbStickInputAction.triggered)
            return;

        if (!m_RayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit raycastHit))
        {
            m_RayInteractor.enabled = false;
            m_TeleportIsActive = false;
            return;
        }

        if (raycastHit.collider.gameObject.tag == "Teleport")
        {
            TeleportRequest teleportRequest = new TeleportRequest()
            {
                destinationPosition = raycastHit.point,
            };

            m_TeleportProvider.QueueTeleportRequest(teleportRequest);

            m_RayInteractor.enabled = false;
            m_TeleportIsActive = false;
        }
        m_RayInteractor.enabled = false;
        m_TeleportIsActive = false;
    }

    private void OnDestroy()
    {
        m_TeleportActive.performed -= OnTeleportActivate;
        m_TeleportCancel.performed -= OnTeleportCancel;
    }

    private void OnTeleportCancel(InputAction.CallbackContext obj)
    {
        if (m_TeleportIsActive && m_RayInteractor.enabled) 
        {
            m_RayInteractor.enabled = false;
            m_TeleportIsActive = false;
        }
    }

    private void OnTeleportActivate(InputAction.CallbackContext obj)
    {
        if (!m_TeleportIsActive) 
        {
            m_RayInteractor.enabled = true;
            m_TeleportIsActive = true;
        }
    }
}
