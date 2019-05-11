using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class SoundHover : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip audioClip;

    private VRInteractiveItem m_InteractiveItem;

    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        m_InteractiveItem = this.GetComponent<VRInteractiveItem>();

    }

    private void OnEnable()
    {
        if (m_InteractiveItem != null)
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
        }
    }

    public void HandleOver()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    private void HandleOut()
    {
        audioSource.clip = audioClip;
        audioSource.Stop();
    }

    // Use this for initialization
    void Start()
    {
       // if (audioSource != null)
        // audioSource.clip = audioClip;

    }
}

