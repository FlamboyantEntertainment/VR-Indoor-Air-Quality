using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class bathroomMoist : MonoBehaviour
{

    public GameObject moistText;
    public GameObject moistCompleted;
    public SpriteRenderer moistSprite;
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
    void Awake()
    {
        moistText = GameObject.Find("Bathroom_moist");
        moistCompleted = GameObject.Find("Bath_moist_1_completed");
        moistSprite = gameObject.GetComponent<SpriteRenderer>();
        moistText.SetActive(false);
        moistCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        moistCompleted.SetActive(true);
        moistSprite.enabled = false;
        if (!isIssueCalled)
        {
            moistText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
       // moistText.SetActive(false);
    }
}

