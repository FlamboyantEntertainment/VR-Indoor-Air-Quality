using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour
{

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private string m_SceneToLoad;

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
        StartCoroutine(ActivateButton());
        print("dili lage 2");

    }
    private void HandleOut()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    IEnumerator ActivateButton()
    {
        // Load the level.
        SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
        yield return new WaitForSeconds(0.75f);
    }
}

