using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class livingRadon : MonoBehaviour {

    public GameObject radonText;
    public GameObject radonCompleted;
    public SpriteRenderer radonSprite;
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
        
        radonText = GameObject.Find("Living_radon");
        radonCompleted = GameObject.Find("Living_radon_completed");
        radonSprite = gameObject.GetComponent<SpriteRenderer>();
        radonText.SetActive(false);
        radonCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        
        radonCompleted.SetActive(true);
        radonSprite.enabled = false;
        if (!isIssueCalled)
        {
            radonText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
       
    }
    private void HandleOut()
    {
       // radonText.SetActive(false);
    }
}

