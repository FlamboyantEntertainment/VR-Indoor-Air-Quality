using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class bathroomMoist2 : MonoBehaviour
{

    public GameObject bathMoist2;
    public GameObject bathMoist2Completed;
    public SpriteRenderer bathMoist2Sprite;
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
        bathMoist2 = GameObject.Find("moist_2");
        bathMoist2Completed = GameObject.Find("Bath_moist_2_completed");
        bathMoist2Sprite = gameObject.GetComponent<SpriteRenderer>();
        bathMoist2.SetActive(false);
        bathMoist2Completed.SetActive(false);
    }

    public void HandleOver()
    {
        
        bathMoist2Completed.SetActive(true);
        bathMoist2Sprite.enabled = false;
        if (!isIssueCalled)
        {
            bathMoist2.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
        //bathMoist2.SetActive(false);
    }
}

