using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class CloseStatus : MonoBehaviour
{
    public Status ScoreStatus;
    [SerializeField] private VRInteractiveItem m_InteractiveItem;

    private void OnEnable()
    {
       
        if (m_InteractiveItem != null)
        {
            m_InteractiveItem.OnOver += HandleOver;
        }

    }

    public void HandleOver()
    {
        Debug.Log("Close Button");
        ScoreStatus.CloseStatus();
    }



}

