using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField] private LevelManager m_manager;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        m_manager.NextLevel();
    }
}
