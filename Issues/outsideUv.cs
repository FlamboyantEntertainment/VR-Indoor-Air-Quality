using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class outsideUv : MonoBehaviour {

    public GameObject uvText;
    public GameObject uvCompleted;
    public SpriteRenderer uvSprite;
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
        uvText = GameObject.Find("Outside_uv");
        uvCompleted = GameObject.Find("Outside_uv_completed");
        uvSprite = gameObject.GetComponent<SpriteRenderer>();
        uvText.SetActive(false);
        uvCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        uvCompleted.SetActive(true);
        uvSprite.enabled = false;
        if (!isIssueCalled)
        {
            uvText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
        //uvText.SetActive(false);
    }
}

