using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class Status : MonoBehaviour
{
    //Status
    public GameObject ScoreStatus;
    public GameObject ScoreStatusOpen;
    public GameObject ScoreStatusExit;

    public GameObject ScoreBoard;
    public GameObject RoomMenu;
    [SerializeField] private VRInteractiveItem btnClose;
    [SerializeField] private VRInteractiveItem btnCloseSSO;
    //[SerializeField] private VRInteractiveItem btnCloseSSOExit;
    [SerializeField] private VRInteractiveItem btnNext;
    [SerializeField] private VRInteractiveItem btnTrophy;
    [SerializeField] private SelectRadial m_SelectionRadial;
    public GameObject[] issueIcons;
    public bool isTwice;
    public Stars starScript;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnEnable()
    {

        isTwice = true;
        issueIcons = GameObject.FindGameObjectsWithTag("Issues");
        //IssuesActivate();
        ScoreStatus.SetActive(false);
        ScoreStatusOpen.SetActive(false);
        if (btnClose != null || btnCloseSSO !=null)
        {
            
            btnClose.OnOver += CloseStatus;
            btnCloseSSO.OnOver += CloseStatus;
            //btnCloseSSOExit.OnOver += CloseStatus;
        }
        if (btnNext != null)
        {
            btnNext.OnOver += RadialSelectionRoomMenu;
        }
        if (btnTrophy != null)
        {
            btnTrophy.OnOver += ShowStatus;
        }
        if (m_SelectionRadial != null)
            m_SelectionRadial.OnSelectionComplete += OpenRoomMenu;

    }

    // Use this for initialization
    void Start()
    {
    
    }



    public void ShowStatus()
    {
        starScript.isFirstRoom = false;
        //if (transform.position != new Vector3(0f, 0f, 0f))
        ScoreStatusOpen.SetActive(true);
        ScoreBoard.SetActive(false);
        audioSource.clip = audioClip;
        audioSource.Play();
        // if (transform.position != new Vector3(0f, 0f, 0f))
        // IssuesInactive();

    }
    public void CloseStatus()
    {
        if (Camera.main.transform.parent.position != new Vector3(0f, 0f, 10.52f))
        {
            starScript.isFirstRoom = true;
        }
            
        //IssuesActivate();
        if (ScoreStatus != null)
            ScoreStatus.SetActive(false);

        if (ScoreStatusOpen != null)
            ScoreStatusOpen.SetActive(false);

       

        if (transform.position != new Vector3(0f, 0f, 0f))
        ScoreBoard.SetActive(true);


    }
    public void RadialSelectionRoomMenu()
    {
        m_SelectionRadial.Show();
    }

    public void OpenRoomMenu()
    {

        RoomMenu.SetActive(true);
        ScoreStatus.SetActive(false);
        m_SelectionRadial.Hide();
    }



    public void OpenScoreBoard()
    {
        ScoreBoard.SetActive(true);
    }

  //  public void IssuesInactive()
   // {

     //   for (int i = 0; i < 30; i++)
      //  {
       //     issueIcons[i].SetActive(false);
       // }
    //}

   // public void IssuesActivate()
   // {
     //   Update();
       // for (int i = 0; i < 30; i++)
       // {
       //     issueIcons[i].SetActive(true);
       // }
  //  }
    void Update()
    {
        


    }

   
}

