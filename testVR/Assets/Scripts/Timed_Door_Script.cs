using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timed_Door_Script : Base_Class
{
    [SerializeField] private GameObject m_Door;
    [SerializeField] private float m_AnimationStep;
    [SerializeField] private Animator m_Animator;
    private float animtime = 0.0f;
    private bool opening = false;
    private bool closing = false;

    // Start is called before the first frame update
    public override void Activate() 
    {
        opening = true;
        closing = false;
    }

    private void Update()
    {
        if (opening)
        {
            if (animtime < 1.0f)
            {
                animtime += m_AnimationStep;
                m_Animator.SetFloat("Time", animtime);
            }
            else
            {
                animtime = 1.0f;
                opening = false;
            }
        }
        else if (closing) 
        {
            if (animtime > 0.0f)
            {
                animtime -= m_AnimationStep;
                m_Animator.SetFloat("Time", animtime);
            }
            else
            {
                animtime = 0.0f;
                closing = false;
            }
        }

    }

    public override void Deactivate()
    {
        opening = false;
        closing = true;
    }
}
