using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class livingFireplace : MonoBehaviour {

    public GameObject fireplaceText;
    public GameObject fireplaceCompleted;
    public SpriteRenderer fireplaceSprite;
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
        
        fireplaceText = GameObject.Find("Living_fireplace");
        fireplaceCompleted = GameObject.Find("Living_fireplace_completed");
        fireplaceSprite = gameObject.GetComponent<SpriteRenderer>();
        fireplaceText.SetActive(false);
        fireplaceCompleted.SetActive(false);
    }

    public void HandleOver()
    {

        fireplaceCompleted.SetActive(true);
        fireplaceSprite.enabled = false;
        
        if (!isIssueCalled)
        {
            Debug.Log("Living Fireplace called");
            fireplaceText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
        

    }
    private void HandleOut()
    {
        //fireplaceText.SetActive(false);
    }
}

