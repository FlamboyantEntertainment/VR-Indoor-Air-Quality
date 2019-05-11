using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class kitchenVoc : MonoBehaviour {

    public GameObject vocText;
    public float fadeTime;
    public Stars StarsScript;
    private bool isIssueCalled;

    [SerializeField] private VRInteractiveItem m_InteractiveItem;

    private void OnEnable()
    {
        isIssueCalled = false;
        if (m_InteractiveItem != null)
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
        }
    }

    // Use this for initialization
    void Awake () {
        vocText = GameObject.Find("Kitchen_voc");
        vocText.SetActive(false);
    }

    public void HandleOver()
    {
        vocText.SetActive(true);
        if (!isIssueCalled)
        {
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
        vocText.SetActive(false);
    }
}

