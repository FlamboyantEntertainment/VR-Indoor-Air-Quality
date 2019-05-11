using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class bedroomChemical : MonoBehaviour {

    public GameObject chemicalText;
    public GameObject chemicalCompleted;
    public SpriteRenderer chemicalSprite;
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
        chemicalText = GameObject.Find("Bedroom_chemical_hazard");
        chemicalCompleted = GameObject.Find("Bedroom_chemical_hazard_completed");
        chemicalSprite = gameObject.GetComponent<SpriteRenderer>();
        chemicalText.SetActive(false);
        chemicalCompleted.SetActive(false);
    }

    public void HandleOver()
    {
        
        chemicalCompleted.SetActive(true);
        chemicalSprite.enabled = false;
        if (!isIssueCalled)
        {
            chemicalText.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
        //chemicalText.SetActive(false);
    }
}

