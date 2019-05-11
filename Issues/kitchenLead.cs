using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class kitchenLead : MonoBehaviour {

    public GameObject leadText;
    public GameObject leadCompleted;
    public SpriteRenderer leadSprite;
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
        leadText = GameObject.Find("Kitchen_lead");
        leadCompleted = GameObject.Find("Kitchen_lead_completed");
        leadSprite = gameObject.GetComponent<SpriteRenderer>();
        leadText.SetActive(false);
        leadCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        leadCompleted.SetActive(true);
        leadSprite.enabled = false;
        if (!isIssueCalled)
        {
            leadText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
        //leadText.SetActive(false);
    }
}

