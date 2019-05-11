using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class basementMoist2 : MonoBehaviour {

    public GameObject moist2Text;
    public GameObject moist2Completed;
    public SpriteRenderer moist2Sprite;
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
        moist2Text = GameObject.Find("bt_moist2");
        moist2Completed = GameObject.Find("Basement_moist_2_completed");
        moist2Sprite = gameObject.GetComponent<SpriteRenderer>();
        moist2Text.SetActive(false);
        moist2Completed.SetActive(false);
    }

    public void HandleOver()
    {
        
        moist2Completed.SetActive(true);
        moist2Sprite.enabled = false;
        if (!isIssueCalled)
        {
            moist2Text.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
       // moist2Text.SetActive(false);
    }
}

