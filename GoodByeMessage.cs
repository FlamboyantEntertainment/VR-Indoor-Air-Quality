using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class GoodByeMessage : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;
    private bool isExit;
    private int count;
    public GameObject ScoreBoard;
    public Stars starScript;

    public GameObject homeButton;
    public GameObject trophyButton;

    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
      
    }

    private void OnEnable()
    {
        count = 1;

    }

    void Update()
    {
        if (Camera.main.transform.parent.position == new Vector3(0f, 0f, 10.52f))
        {
            // Debug.Log("HERRER Exit");
            isExit = true;
            
            count++;
        }
        if (isExit && count == 2)
        {
            starScript.isFirstRoom = false;
            StartCoroutine(ExitHere());
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    IEnumerator ExitHere()
    {
        isExit = false;
        ScoreBoard.SetActive(false);
        //Debug.Log("HERRER Exit");
        audioSource.clip = audioClip;
        audioSource.Play();

        homeButton.SetActive(false);
        trophyButton.SetActive(false);
        yield return true;
        
    }
}

