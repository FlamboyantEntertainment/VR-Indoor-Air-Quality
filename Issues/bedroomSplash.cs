using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class bedroomSplash : MonoBehaviour {

    public GameObject coText;
    public GameObject coCompleted;
    public SpriteRenderer coSprite;
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
        coText = GameObject.Find("Bedroom_splash");
        coCompleted = GameObject.Find("Bedroom_splash_completed");
        coSprite = gameObject.GetComponent<SpriteRenderer>();
        coText.SetActive(false);
        coCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        coCompleted.SetActive(true);
        coSprite.enabled = false;
        if (!isIssueCalled)
        {
            coText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
        //coText.SetActive(false);
    }
}

