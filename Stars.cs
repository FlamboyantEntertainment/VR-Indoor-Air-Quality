using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;
using System.Linq;


public class Stars : MonoBehaviour
{
    public AudioSource starSound;
    public AudioSource starsCompleted;
    public AudioSource badgeCompleted;
    public Color gold;
    public Transform starsConfetti;
    public GameObject FireworksAll;
    public GameObject ScoreBoard;
    public GameObject ScoreStatus;
    
    //Badges 
    public GameObject Badge1;
    public GameObject Badge2;
    public GameObject Badge3;
    public GameObject BadgeGrey1;
    public GameObject BadgeGrey2;
    public GameObject BadgeGrey3;

    public GameObject SSBadge1;
    public GameObject SSBadge2;
    public GameObject SSBadge3;


    //LivingRoom
    private int countStars;
    public int countOverallStars;
    public Text countText;
    public Text trophyMessage;
    private bool isLivingRoom, isBathRoom, isBedRoom, isKitchen, isLaundry, isGarage, isBasement, isOutside, isExit;
    private int count;
    private int numIssues;

    public Text starPoints;
    public Text badgePoints;
    public Text bonusPoints;
    public Text totalPoints;
    public Text timerText;

    //Stars
    public GameObject[] stars;
    public Sprite yellowStar;
    public Sprite greyStar;

    //Timer
    private float timer = 0.0f;
    private float waitTime = 5.0f;
    private float visualTime = 0.0f;
    public bool isFirstRoom;

    private int numberBadgePoints;
    private int numberStarPoints;

    //Last Message
    private ShowLiving lastRoom;



    private void OnEnable()
    {
        numIssues = 0;
        count = 0;
        countStars = 0;
        countOverallStars = 0;
        isLivingRoom = false;
        isBathRoom = false;
        isBedRoom = false;
        isKitchen = false;
        isLaundry = false;
        isGarage = false;
        isBasement = false;
        isOutside = false;
        isExit = false;
        isFirstRoom = false;
        numberBadgePoints = 0;
        numberStarPoints = 0;

        //starPoints = GameObject.Find("StarPoints-num").GetComponent<Text>();
        //badgePoints = GameObject.Find("Level-num").GetComponent<Text>();
        //bonusPoints = GameObject.Find("Bonus-num").GetComponent<Text>();
        //totalPoints = GameObject.Find("Total-num").GetComponent<Text>();
       // timerText = GameObject.Find("TimeElapsed-num").GetComponent<Text>();

        stars = GameObject.FindGameObjectsWithTag("StarCount").OrderBy(go => go.name).ToArray();
        //stars.Add("gangster");

        countText.text = "0/30";
        // gold = new Color(255f, 204f, 102f);

        //Disable Badges
        Badge1.SetActive(false);
        Badge2.SetActive(false);
        Badge3.SetActive(false);

    }

    // Use this for initialization
    void Start()
    {
        if (Camera.main.transform.position == new Vector3(0.0f, 0.0f, 0.0f))
        {
            // for (int i = 0; i < stars.Length; i++)
            //  {
            //      stars[i].SetActive(false);
            //  }
           // ScoreBoard.SetActive(false);
        }

        if (transform.position == new Vector3(0f, 0f, 0f))
        {
             

            foreach (GameObject item in stars)
            {
                item.SetActive(false);
            }

            ScoreBoard.SetActive(false);
        }

    }


    void Update()
    {
        if (isFirstRoom)
        {
            timer += Time.deltaTime;
            
            //timerText.text = "Timer value is: " + visualTime.ToString();

            float minutes = Mathf.Floor(timer / 60);
            float seconds = timer % 60;

            float bonusCalculations = Mathf.Floor(seconds * 5);

           
         
            float totalCalculations = bonusCalculations + numberStarPoints + numberBadgePoints;


            //visualTime = timer;
            bonusPoints.text = bonusCalculations.ToString();
            totalPoints.text = totalCalculations.ToString();
            timerText.text = minutes + ":" + Mathf.RoundToInt(seconds);
        }
        
        //Debug.Log("transform position" + transform.position);
        if (transform.position == new Vector3(-4.99f, 0f, 0f) && !isLivingRoom)
        {
            Debug.Log("Living" + timer);
            //Debug.Log("Living Room");
            numIssues = 6;
            StarReset();
            StarsActive();
           

            isLivingRoom = true;
        }
        if (transform.position == new Vector3(17.94f, -0.25f, 5.832f) && !isBathRoom)
        {
            Debug.Log("Bath" + timer);
            //Debug.Log("Bath Room");
            numIssues = 3;
            StarReset();
            StarsActive();
            isBathRoom = true;
           
        }

        if (transform.position == new Vector3(23.23f, -0.25f, 0.7492169f) && !isBedRoom)
        {
            Debug.Log("Bed" + timer);
            // Debug.Log("Bed Room");
            numIssues = 4;
            StarReset();
            StarsActive();
            isBedRoom = true;
           
        }

        if (transform.position == new Vector3(5.83f, -0.25f, 0.537f) && !isKitchen)
        {
          //  Debug.Log("Kitchen");
            numIssues = 3;
            StarReset();
            StarsActive();
            isKitchen = true;
           
        }
        if (transform.position == new Vector3(29.15f, -0.25f, 0.7492169f) && !isLaundry)
        {
            //Debug.Log("Laundry");
            numIssues = 2;
            StarReset();
            StarsActive();
            isLaundry = true;
            
        }
        if (transform.position == new Vector3(34.69f, -0.25f, 0.7492169f) && !isGarage)
        {
            //Debug.Log("Garage");
            numIssues = 2;
            StarReset();
            StarsActive();
            isGarage = true;
            
        }
        if (transform.position == new Vector3(11.81f, -0.25f, 0.7492169f) && !isBasement)

        {
           // Debug.Log("Basement");
            numIssues = 7;
            StarReset();
            StarsActive();
            isBasement = true;
            
        }
        if (transform.position == new Vector3(39.62f, -0.25f, 0.7492169f) && !isOutside)

        {
            //Debug.Log("Outside");
            numIssues = 3;
            StarReset();
            StarsActive();
            isOutside = true;
            
        }


    }

  

    public void StarReset()
    {
        countStars = 0;
        foreach (GameObject item in stars)
        {
            item.SetActive(false);
        }
    }

    public void StarsActive()
    {
        ScoreBoard.SetActive(true);
       // for (int i = 0; i < numIssues; i++)
      //  {

            //stars[i].gameObject.GetComponent<Renderer>().material.color = Color.grey;
           // stars[i].gameObject.GetComponent<Image>().sprite = greyStar;
          //  stars[i].SetActive(true);
       //}

        var amount = Random.Range(0.2f, 0.2f);
        for (var i = 0; i < numIssues; i++)
        {

            stars[i].gameObject.GetComponent<Image>().sprite = greyStar;
            //petalClone.transform.position = new Vector3(-23.2f, -4.9f, 1.2f);
            //Instantiate(greyStar, new Vector3(-23.2F, -4.9f, 1.2f), Quaternion.identity);
            stars[i].SetActive(true);
        }
    }
    public void StarTurnGold()
    {
        starSound.Play();
        //Debug.Log("StarTurnGold");
        countStars++;
        countOverallStars++;
       numberStarPoints = countOverallStars * 100;
        
        starPoints.text = numberStarPoints.ToString();
        countText.text = countOverallStars.ToString() + "/30";
        for (int i = 0; i < countStars; i++)
        {

            //stars[i].gameObject.GetComponent<Renderer>().material.color = gold;
            stars[i].gameObject.GetComponent<Image>().sprite = yellowStar;
            //Instantiate(stars, new Vector3(i + 3, 0.9f, 0), Quaternion.identity);
        }

        

        if (countStars == numIssues)    
        {
            //Debug.Log("Stars Fulfilled");
            countStars = 0;
            Explode();
        }
        if(countOverallStars == 10)
        {
            Badge1.SetActive(true);
            BadgeGrey1.SetActive(false);

            numberBadgePoints = 500;
            badgePoints.text = numberBadgePoints.ToString();

            //show score
            ScoreStatus.SetActive(true);
            badgeCompleted.Play();
            //isFirstRoom = false;
        }
        if (countOverallStars == 20)
        {
            Badge2.SetActive(true);
            BadgeGrey2.SetActive(false);
            trophyMessage.text = "Well done! You found 20 out of 30 hazards. You earned the Silver trophy";
            SSBadge2.SetActive(true);
            SSBadge1.SetActive(false);
            SSBadge3.SetActive(false);

            numberBadgePoints = 1500;
            badgePoints.text = numberBadgePoints.ToString();

            ScoreStatus.SetActive(true);
            badgeCompleted.Play();
        }
        if (countOverallStars == 30)
        {
            Badge3.SetActive(true);
            BadgeGrey3.SetActive(false);
            trophyMessage.text = "Well done! You found them all! You earned the Gold trophy. You are a 'Healthy Environment' champion!";
            SSBadge3.SetActive(true);
            SSBadge1.SetActive(false);
            SSBadge2.SetActive(false);

            numberBadgePoints = 2500;
            badgePoints.text = numberBadgePoints.ToString();

            ScoreStatus.SetActive(true);
            badgeCompleted.Play();
        }
    }

    void Explode()
    {
        starsCompleted.Play();
        GameObject firework = Instantiate(FireworksAll, starsConfetti.position, Quaternion.identity);
        firework.GetComponent<ParticleSystem>().Play();
    }
}

