using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class outsideAir : MonoBehaviour {

    public GameObject airText;
    public GameObject airCompleted;
    public SpriteRenderer airSprite;
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
    void Start () {
        airText = GameObject.Find("Outside_air");
        airCompleted = GameObject.Find("Outside_air_completed");
        airSprite = gameObject.GetComponent<SpriteRenderer>();
        airText.SetActive(false);
        airCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        airCompleted.SetActive(true);
        airSprite.enabled = false;
        if (!isIssueCalled)
        {
            airText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
       // airText.SetActive(false);
    }
}

