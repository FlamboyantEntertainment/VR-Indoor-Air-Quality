    using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class livingVoc : MonoBehaviour {

    public GameObject vocText;
    public GameObject vocCompleted;
    public SpriteRenderer vocSprite;
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
        vocText = GameObject.Find("Living_voc");
        vocCompleted = GameObject.Find("Living_voc_completed");
        vocSprite = gameObject.GetComponent<SpriteRenderer>();
        vocText.SetActive(false);
        vocCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        vocCompleted.SetActive(true);
        vocSprite.enabled = false;
        if (!isIssueCalled)
        {
            vocText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
        
    }
    private void HandleOut()
    {
       // vocText.SetActive(false);
    }
}

