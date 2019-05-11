﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class outsideChemical : MonoBehaviour {

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
    void Start () {
        chemicalText = GameObject.Find("cm_out");
        chemicalCompleted = GameObject.Find("Outside_chemical_completed");
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
       // chemicalText.SetActive(false);
    }
}

