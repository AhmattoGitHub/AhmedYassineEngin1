using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private static ParticleManager _instance;

    [SerializeField]
    private ParticleSystem m_playerExplosion;

    public static ParticleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("There is no ParticleManager");
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
    public void SpawnExplosion()
    {
        m_playerExplosion.Play();
    }
}
