using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timed_Door_Script : Base_Class
{
    [SerializeField] GameObject m_Door;
    // Start is called before the first frame update
    public override void Activate() 
    {
        Vector3 newpos = m_Door.transform.position - Vector3.up;
        m_Door.transform.position = newpos;
    }

    public override void Deactivate()
    {
        Vector3 newpos = m_Door.transform.position + Vector3.up;
        m_Door.transform.position = newpos;
    }
}
