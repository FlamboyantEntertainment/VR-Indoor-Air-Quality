using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class CloseButton : MonoBehaviour
{

    public GameObject closeButton;
    public float fadeTime;
    public bool displayInfo;

    [SerializeField] private VRInteractiveItem m_InteractiveItem;


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
        closeButton.SetActive(false);
    }
    private void HandleOut()
    {

    }

    // Use this for initialization
    void Start()
    {
        closeButton = GameObject.Find("NavMenu");
        closeButton.SetActive(true);
    }
}

