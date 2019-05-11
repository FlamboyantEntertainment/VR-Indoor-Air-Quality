using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class basementMoist3 : MonoBehaviour {

    public GameObject moist3Text;
    public GameObject moist3Completed;
    public SpriteRenderer moist3Sprite;
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
        moist3Text = GameObject.Find("bt_moist3");
        moist3Completed = GameObject.Find("Basement_moist_3_completed");
        moist3Sprite = gameObject.GetComponent<SpriteRenderer>();
        moist3Text.SetActive(false);
        moist3Completed.SetActive(false);
    }

    public void HandleOver()
    {
        
        moist3Completed.SetActive(true);
        moist3Sprite.enabled = false;
        if (!isIssueCalled)
        {
            moist3Text.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
        //moist3Text.SetActive(false);
    }
}

