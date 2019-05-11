using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class ShowHomeButton : MonoBehaviour
{

    public GameObject showMenu;
    public bool isEntrance;
    //public GameObject showBG;
    public GameObject welcomeTexts;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float fadeTime;
    private int count;
    public bool m_GazeOver;
    public bool GoToDone = false;
    public Status ShowStatus;
    public Stars overallStar;
    
  
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    private bool isDone;

    private void OnEnable()
    {
     
        count = 1;
        isDone = false;
        isEntrance = true;
        //showMenu = GameObject.Find("UniversalNavigation");

        //Debug.Log("Show Home Button");
        if (m_InteractiveItem != null)
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
        }

        //Debug.Log(isDone);
        
    }

    public void Update()
    {
        count++;
        if(count == 2)
        {
            StartCoroutine(ShowHome());
        }
    }

    public void HandleOver()
    {


        //showBG.SetActive(true);


        
        

        if (isDone == true)
        {
            //if (overallStar.countOverallStars == 10 || overallStar.countOverallStars == 20 || overallStar.countOverallStars == 30)
            //{
             //   ShowStatus.ShowStatus();
           // }
            //else
           // {
                showMenu.SetActive(true);
            ShowStatus.CloseStatus();
            //}

            //Debug.Log(isEntrance.position);
            if (isEntrance)
            {
                //showMenu.SetActive(true);
               
                isEntrance = false;
            }
                

            welcomeTexts.SetActive(false);
            //scriptLivingScents.enabled = false;

            m_GazeOver = true;

            //m_Audio.clip = m_OnOverClip;
            audioSource.clip = audioClip;
            audioSource.Play();
        }

       




    }
    private void HandleOut()
    {
        // m_GazeOver = false;
        if (isDone == true)
        {
            //if (showMenu != null)
            //    showMenu.SetActive(true);
            //StartCoroutine(CloseMenu());
            //displayInfo = false;
        }
    }



    // Use this for initialization
    void Start()
    {
        audioSource.clip = audioClip;
        showMenu.SetActive(false);
        
        //showMenu.SetActive(true);
        // showMenu = GameObject.Find("UniversalNavigation");
        // if (showBG != null)
        //  showBG = GameObject.Find("UNBg");
    }


    IEnumerator ShowHome()
    {
        yield return new WaitForSeconds(4);
        isDone = true;
       // Debug.Log("ShowHome" + isDone);
        //showMenu.GetComponent<Renderer>().enabled = false;
    

    }
}

