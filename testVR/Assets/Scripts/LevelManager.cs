using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Scene m_CurrentScene;
    [SerializeField] private AudioClip m_StartingAudio;
    [SerializeField] private AudioSource m_AudioSource;
    private int m_CurrentLevelIndex;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        m_CurrentScene = SceneManager.GetActiveScene();
        m_CurrentLevelIndex = m_CurrentScene.buildIndex;
        Debug.Log("Level" + m_CurrentLevelIndex + " Loaded");

        yield return new WaitForSecondsRealtime(10);
        Debug.Log("Times UP");
        m_AudioSource.PlayOneShot(m_StartingAudio);
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(m_CurrentLevelIndex + 1);
    }
}
