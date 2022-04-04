using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{
    [SerializeField] Base_Class[] m_AttachedObjects;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Base_Class b in m_AttachedObjects)
        {
            b.Activate();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        foreach (Base_Class b in m_AttachedObjects)
        {
            b.Deactivate();
        }
    }
}
