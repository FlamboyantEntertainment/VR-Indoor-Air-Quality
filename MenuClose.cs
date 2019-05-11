using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class MenuClose : MonoBehaviour
{

    public GameObject showMenu;
    public float fadeTime;
    public bool displayInfo;

    [SerializeField] private VRInteractiveItem m_InteractiveItem;


    private void OnEnable()
    {
        if (m_InteractiveItem != null)
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
        }
    }

    public void HandleOver()
    {
        showMenu.SetActive(true);
        Debug.Log("Princess handle over");
    }
    private void HandleOut()
    {
        showMenu.SetActive(false);
        Debug.Log("Princess handle out");
    }

    // Use this for initialization
    void Start()
    {
        showMenu = GameObject.Find("NavMenu");
       // showMenu.SetActive(false);
    }
}

