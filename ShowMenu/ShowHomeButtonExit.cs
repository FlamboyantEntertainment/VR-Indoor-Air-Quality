using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class ShowHomeButtonExit : MonoBehaviour
{

    public GameObject ExitButton;
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

    // Use this for initialization
    void Awake()
    {
        ExitButton = GameObject.Find("Exit Button");
        if (ExitButton != null)
            ExitButton.SetActive(false);
    }

    public void HandleOver()
    {
        if (ExitButton != null)
            ExitButton.SetActive(true);

        displayInfo = true;
    }

    public void HandleOut()
    {
       // StartCoroutine(CloseMenu());

       // displayInfo = false;
    }

    IEnumerator CloseMenu()
    {
        yield return new WaitForSeconds(15);
        ExitButton.SetActive(false);
    }


}

