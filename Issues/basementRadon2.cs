using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class basementRadon2 : MonoBehaviour
{

    public GameObject radon2Text;
    public GameObject radon2Completed;
    public SpriteRenderer radon2Sprite;
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
        radon2Text = GameObject.Find("bt_radon2");
        radon2Completed = GameObject.Find("Basement_radon_2_completed");
        radon2Sprite = gameObject.GetComponent<SpriteRenderer>();
        radon2Text.SetActive(false);
        radon2Completed.SetActive(false);
    }

    public void HandleOver()
    {
       
        radon2Completed.SetActive(true);
        radon2Sprite.enabled = false;
        if (!isIssueCalled)
        {
            radon2Text.SetActive(true);
            StarsScript.StarTurnGold();
            isIssueCalled = true;
        }
    }
    private void HandleOut()
    {
      //  radon2Text.SetActive(false);
    }
}

