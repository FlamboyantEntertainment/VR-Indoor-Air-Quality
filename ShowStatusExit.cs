using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class ShowStatusExit : MonoBehaviour
{

    public GameObject ShowStatusExitBoard;
    public GameObject Scoreboard;
    [SerializeField] private VRInteractiveItem m_InteractiveItem;

    private void OnEnable()
    {

        ShowStatusExitBoard.SetActive(false);
        if (m_InteractiveItem != null)
            m_InteractiveItem.OnOver += HandleOver;

    }

    private void HandleOver()
    {
        Scoreboard.SetActive(false);
        ShowStatusExitBoard.SetActive(true);
    }

}

