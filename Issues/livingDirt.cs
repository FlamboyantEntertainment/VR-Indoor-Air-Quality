using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class livingDirt : MonoBehaviour {

    public GameObject scentsText;
    public GameObject scentsCompleted;
    public SpriteRenderer scentsSprite;
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
        scentsText = GameObject.Find("Living_dirt");
        scentsCompleted = GameObject.Find("Dirt_completed");
        scentsSprite = gameObject.GetComponent<SpriteRenderer>();
        scentsText.SetActive(false);
        scentsCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        scentsCompleted.SetActive(true);
        scentsSprite.enabled = false;
        if (!isIssueCalled)
        {
            scentsText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
       
    }
    private void HandleOut()
    {
       // scentsText.SetActive(false);
    }
}

