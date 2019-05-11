using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class kitchenVentilation : MonoBehaviour {

    public GameObject ventilationText;
    public GameObject ventilationCompleted;
    public SpriteRenderer ventilationSprite;
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
        ventilationText = GameObject.Find("Kitchen_ventilation");
        ventilationCompleted = GameObject.Find("Kitchen_ventilation_completed");
        ventilationSprite = gameObject.GetComponent<SpriteRenderer>();
        ventilationText.SetActive(false);
        ventilationCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        ventilationCompleted.SetActive(true);
        ventilationSprite.enabled = false;
        if (!isIssueCalled)
        {
            ventilationText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
        //ventilationText.SetActive(false);
    }
}

