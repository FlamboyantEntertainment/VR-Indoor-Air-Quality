using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.Video;


public class VideoPlayerPlay : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public GameObject issueIcon;
    public GameObject[] issuesDisable;
    public GameObject[] issueCompleted;
    public SphereCollider sphereCollider;

    private GameObject homeButton;
    private GameObject trophyButton;
    public bool isPlaying;

    void Awake()
    {
        //videoPlayer = this.GetComponent<VideoPlayer>();

        homeButton = GameObject.Find("homeButton");
        trophyButton = GameObject.Find("trophy");
        isPlaying = true;
        
        videoPlayer.loopPointReached += EndReached;
        

    }

    void DisableIcons()
    {
        sphereCollider.enabled = false;
        foreach (GameObject issues in issuesDisable)
        {
            if (issues != issueIcon)
            {
                issues.GetComponent<SphereCollider>().enabled = false;
                //issues.SetActive(false);
            }
           
        }

        homeButton.GetComponent<SphereCollider>().enabled = false;
        trophyButton.GetComponent<SphereCollider>().enabled = false;
        // Completed dont need to be hidden if it's not clickable. So I'll comment it out
        //foreach (GameObject issueC in issueCompleted)
        // {
        //  if (issueC != issueIcon)
        // {
        //issueC.GetComponent<SphereCollider>().enabled = false;
        //issueC.SetActive(false);
        //  }

        // }
        isPlaying = false;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video is done.");
        issueIcon.SetActive(false);
        //sphereCollider.enabled = true;
        foreach (GameObject issues in issuesDisable)
        {
            if (issues != issueIcon)
            {
                issues.GetComponent<SphereCollider>().enabled = true;
                //issues.SetActive(true);
            }

        }

        homeButton.GetComponent<SphereCollider>().enabled = true;
        trophyButton.GetComponent<SphereCollider>().enabled = true;

        //if (issueCompleted != null)
        //foreach (GameObject issueC in issueCompleted)
        //{
        //if (issueC != issueIcon)
        // {
        //    issueC.SetActive(true);
        //}

        // }


    }

    private void OnEnable()
    {
        issuesDisable = GameObject.FindGameObjectsWithTag("Issues");
        issueCompleted = GameObject.FindGameObjectsWithTag("IssueCompleted");
    }

    public void Update()
    {
       if (isPlaying)
       {
            Debug.Log("Disable Icons");
            DisableIcons();

       }
    }
    private void HandleOut()
    {
      
    }

    // Use this for initialization
    void Start()
    {
        // if (audioSource != null)
        // audioSource.clip = audioClip;

    }
}

