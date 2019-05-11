using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class laundryDust : MonoBehaviour {

    public GameObject dustText;
    public GameObject dustCompleted;
    public SpriteRenderer dustSprite;
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
        dustText = GameObject.Find("dust_laundry");
        dustCompleted = GameObject.Find("Laundry_dust_completed");
        dustSprite = gameObject.GetComponent<SpriteRenderer>();
        dustText.SetActive(false);
        dustCompleted.SetActive(false);
    }

    public void HandleOver()
    {
       
        dustCompleted.SetActive(true);
        dustSprite.enabled = false;
        if (!isIssueCalled)
        {
            dustText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
        
       

    }
    private void HandleOut()
    {
        //dustText.SetActive(false);
    }
}

