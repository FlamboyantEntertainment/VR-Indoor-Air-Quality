using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class kitchenSmoke : MonoBehaviour {

    public GameObject smokeText;
    public GameObject smokeCompleted;
    public SpriteRenderer smokeSprite;
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
        smokeText = GameObject.Find("Kitchen_smoke");
        smokeCompleted = GameObject.Find("Kitchen_smoke_completed");
        smokeSprite = gameObject.GetComponent<SpriteRenderer>();
        smokeText.SetActive(false);
        smokeCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        smokeCompleted.SetActive(true);
        smokeSprite.enabled = false;
        if (!isIssueCalled)
        {
            smokeText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
        //smokeText.SetActive(false);
    }
}

