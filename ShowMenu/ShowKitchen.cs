using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class ShowKitchen : MonoBehaviour
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

        displayInfo = true;

    }
    private void HandleOut()
    {
        StartCoroutine(CloseMenu());
        displayInfo = false;
    }

    IEnumerator CloseMenu()
    {
        yield return new WaitForSeconds(15);
        showMenu.SetActive(false);
    }

    // Use this for initialization
    void Awake()
    {
        showMenu = GameObject.Find("KitchenNavigation");
        showMenu.SetActive(false);
    }

}

