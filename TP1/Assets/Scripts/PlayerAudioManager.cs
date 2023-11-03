using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    private static PlayerAudioManager _instance;

    [SerializeField] 
    private AudioSource m_playerAudioSource;
    [SerializeField]
    private AudioClip m_hitSound;
    [SerializeField]
    private AudioClip m_jumpSound;
    [SerializeField]
    private AudioClip m_landingSound;

    public static PlayerAudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("There is no AudioManagerInstance");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void PlayHitSound()
    {
        m_playerAudioSource.PlayOneShot(m_hitSound);
    }

    public void PlayJumpSound()
    {
        m_playerAudioSource.PlayOneShot(m_jumpSound);
    }

    public void PlayLandingSound()
    {
        m_playerAudioSource.PlayOneShot(m_landingSound);
    }
}
