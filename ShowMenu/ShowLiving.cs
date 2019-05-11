using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;
using System.Collections.Generic;
using VRStandardAssets.Menu;

public class ShowLiving : MonoBehaviour
{
    [SerializeField] public SelectRadial m_SelectionRadial;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public bool visitedAll;
    bool m_ToggleChange;
    bool m_Play;

    //public GameObject smokeText;
    public int sphereLiving;
    public int sphereBasement;
    public int sphereBathroom;
    public int sphereBedroom;
    public int sphereKitchen;
    public int sphereLaundry;
    public int sphereGarage;
    public int sphereOutside;
    public int sphereEntrance;
    private bool isLivingRoom, isBathRoom, isBedRoom, isKitchen, isLaundry, isGarage, isBasement, isOutside;

    public Vector3 currentSphere;
    //List<GameObject> arrayCompleted = new List<GameObject>();

    public GameObject livingCompleted;
    public GameObject basementCompleted;
    public GameObject bathroomCompleted;
    public GameObject bedroomCompleted;
    public GameObject garageCompleted;
    public GameObject kitchenCompleted;
    public GameObject laundryCompleted;
    public GameObject outsideCompleted;

    public GameObject LivingIcon;
    public GameObject Basement;
    public GameObject Bathroom;
    public GameObject Bedroom;
    public GameObject Garage;
    public GameObject Kitchen;
    public GameObject Laundry;
    public GameObject Outside;
    public GameObject LookHere;

    public GameObject ExitBtn;

    public GameObject showMenu;
    public GameObject homeButtonExit;
    public GameObject homeButton;
    private GameObject trophyButton;

    //public SpriteRenderer homeRenderer; 

    public GameObject Living_text;
    public GameObject Kitchen_text;
    public GameObject Bathroom_text;
    public GameObject Bedroom_text;
    public GameObject Basement_text;
    public GameObject Laundry_text;
    public GameObject Garage_text;
    public GameObject Outside_text;

    public GameObject LivingRoomSphere;
    public GameObject KitchenRoomSphere;
    public GameObject BathRoomSphere;
    public GameObject BedRoomSphere;
    public GameObject BasementRoomSphere;
    public GameObject LaundryRoomSphere;
    public GameObject GarageRoomSphere;
    public GameObject OutsideRoomSphere;
    public GameObject EntranceRoomSphere;
    //public GameObject ExitButton;
    public SpriteRenderer homeRenderer;
    public SpriteRenderer trophyRenderer;
    private int count;

    public bool GoToDone;

    public bool m_GazeOver;
   // public bool onetime = false;

    public CanvasGroup uiElement;
    [SerializeField] private VRInteractiveItem m_InteractiveItem;

    public void OnEnable()
    {
        isLivingRoom = false;
        isBathRoom = false;
        isBedRoom = false;
        isKitchen = false;
        isLaundry = false;
        isGarage = false;
        isBasement = false;
        isOutside = false;
        count = 1;
        sphereBasement = 0;
        sphereKitchen = 0;
        sphereBathroom = 0;
        sphereBedroom = 0;
        sphereGarage = 0;
        sphereLaundry = 0;
        sphereOutside = 0;
        sphereLiving = 0;
        sphereEntrance = 0;

        visitedAll = false;
        m_ToggleChange = false;

        LivingIcon = GameObject.Find("toLiving");
        Basement = GameObject.Find("toBasement");
        Kitchen = GameObject.Find("toKitchen");
        Garage = GameObject.Find("toGarage");
        Bedroom = GameObject.Find("toBedroom");
        Bathroom = GameObject.Find("toBathroom");
        Laundry = GameObject.Find("toLaundry");
        Outside = GameObject.Find("toOutside");
        LookHere = GameObject.Find("LookHere");
       

        livingCompleted = GameObject.Find("living-c");
        garageCompleted = GameObject.Find("garage-c");
        bedroomCompleted = GameObject.Find("bedroom-c");
        laundryCompleted = GameObject.Find("laundry-c");
        basementCompleted = GameObject.Find("basement-c");
        bathroomCompleted = GameObject.Find("bathroom-c");
        kitchenCompleted = GameObject.Find("kitchen-c");
        outsideCompleted = GameObject.Find("outside-c");

       //showMenu = GameObject.Find("UniversalNavigation");
        ExitBtn = GameObject.Find("MessageExit");
        homeButtonExit = GameObject.Find("homeButtonExit");
        homeButton = GameObject.Find("homeButton");
        trophyButton = GameObject.Find("trophy");

        homeRenderer = homeButton.GetComponent<SpriteRenderer>();
        trophyRenderer = trophyButton.GetComponent<SpriteRenderer>();

        Living_text = GameObject.Find("Living_text");
        Kitchen_text = GameObject.Find("Kitchen_text");
        Bathroom_text = GameObject.Find("Bath_text");
        Bedroom_text = GameObject.Find("Bedroom_text");
        Laundry_text = GameObject.Find("Laundry_text");
        Garage_text = GameObject.Find("Garage_text");
        Basement_text = GameObject.Find("Basement_text");
        Outside_text = GameObject.Find("Outside_text");

        LivingRoomSphere = GameObject.Find("Living");
        KitchenRoomSphere = GameObject.Find("Kitchen");
        BathRoomSphere = GameObject.Find("Bathroom");
        BedRoomSphere = GameObject.Find("Bedroom");
        LaundryRoomSphere = GameObject.Find("Laundry");
        GarageRoomSphere = GameObject.Find("Garage");
        BasementRoomSphere = GameObject.Find("Basement");
        OutsideRoomSphere = GameObject.Find("Outside");
        EntranceRoomSphere = GameObject.Find("Entrance");

        EntranceRoomSphere.SetActive(true);
        // ExitButton = GameObject.Find("Exit Button");

        //basementCompleted = GameObject.Find("basementCompleted");
        //basementCompleted.SetActive(false);
        if (m_SelectionRadial != null)
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        if (m_InteractiveItem != null)
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
        }



    }

    void OnDisable()
    {
       // Debug.Log("PrintOnDisable: script was disabled");
    }

    public void HandleOver()
    {
    }
    public void HandleOut()
    {
        if (m_SelectionRadial != null)
            m_SelectionRadial.Hide();
        //m_GazeOver = false;

    }


    public void HandleSelectionComplete()
    {
        //  if (m_GazeOver)
        //CheckedItems();
        //livingCompleted.SetActive(true);
    }

    private void Update()
    {
        count++;
        //Show Home Button
        if (count == 2)
        {
             
            StartCoroutine(ShowHomeMenu());
            homeButton.SetActive(true);
            //showMenu.SetActive(true);
        }

        StartCoroutine(GoTos());
        CheckedItems();
        

        if (m_Play == true && m_ToggleChange == true)
        {
            //if (visitedAll == true)
            // {
            //Debug.Log("HERRERRRRRR");
            if (audioSource != null)
                audioSource.clip = audioClip;
            if (audioSource != null)
                //audioSource.PlayOneShot(audioClip);
            // }

            m_ToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (m_Play == false && m_ToggleChange == true)
        {
            //if (visitedAll == true)
            // {
            if (audioSource != null)
                audioSource.clip = audioClip;
            if (audioSource != null)
              //  audioSource.Stop();
            // }
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
    }



    void Awake()
    {
        
    }

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        //showMenu.SetActive(false);
        m_Play = true;

        //  if (basementCompleted != null)
        basementCompleted.SetActive(false);
        //  if (livingCompleted != null)
        livingCompleted.SetActive(false);
        //  if (garageCompleted != null)
        garageCompleted.SetActive(false);
        //  if (bedroomCompleted != null)
        bedroomCompleted.SetActive(false);
        //  if (laundryCompleted != null)
        laundryCompleted.SetActive(false);
        //  if (bathroomCompleted != null)
        bathroomCompleted.SetActive(false);
        // if (kitchenCompleted != null)
        kitchenCompleted.SetActive(false);
        outsideCompleted.SetActive(false);

        homeButtonExit.SetActive(false);
        if (ExitBtn != null)
            ExitBtn.SetActive(false);

        currentSphere = transform.position;
        //print(currentSphere);
        //if (livingCompleted != null)

       // if (Entrance != null)
        LookHere.SetActive(false);
        //Entrance.GetComponent<Renderer>().enabled = false;


        homeButton.SetActive(false);
       // homeButton.GetComponent<Renderer>().enabled = false;

        //homeRenderer = homeButton.GetComponent<SpriteRenderer>();
        Color c = homeRenderer.material.color;
        c.a = 0f;
        homeRenderer.material.color = c;

        Color b = trophyRenderer.material.color;
        b.a = 0f;
        trophyRenderer.material.color = b;

        StartCoroutine(ShowHomeButton());


    }

    IEnumerator FadeInHere()
    {
       
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = homeRenderer.material.color;
            c.a = f;
            homeRenderer.material.color = c;

            Color b = trophyRenderer.material.color;
            b.a = f;
            trophyRenderer.material.color = b;
            yield return new WaitForSeconds(0.05f);

        }
    }

    IEnumerator ShowHomeButton()
    {
      yield return new WaitForSeconds(4);


        homeButton.SetActive(true);
        trophyButton.SetActive(true);
        //homeButton.GetComponent<Renderer>().enabled = true;

        StartCoroutine(FadeInHere());

        //LookHere.SetActive(true);

        //  showMenu.SetActive(true);
    }

    IEnumerator ShowHomeMenu()
    {
        yield return new WaitForSeconds(4);
        homeButton.SetActive(true);
        //showMenu.SetActive(true);
    }




    public void CheckedItems()
    {

        if (sphereBasement == 1)
        {
            if (basementCompleted != null)
                basementCompleted.SetActive(true);
                Basement.GetComponent<Renderer>().enabled = false;
            //LookHere.SetActive(false);
        }
        if (sphereKitchen == 1)
        {
            if (kitchenCompleted != null)
                kitchenCompleted.SetActive(true);
                Kitchen.GetComponent<Renderer>().enabled = false;
           // LookHere.SetActive(false);

        }
        if (sphereLaundry == 1)
        {
            if (laundryCompleted != null)

                laundryCompleted.SetActive(true);
                Laundry.GetComponent<Renderer>().enabled = false;
            //LookHere.SetActive(false);
        }
        if (sphereBedroom == 1)
        {
            if (laundryCompleted != null)
                bedroomCompleted.SetActive(true);
                Bedroom.GetComponent<Renderer>().enabled = false;
           // LookHere.SetActive(false);
        }
        if (sphereGarage == 1)
        {
            if (garageCompleted != null)
                garageCompleted.SetActive(true);
                Garage.GetComponent<Renderer>().enabled = false;
           // LookHere.SetActive(false);
        }
        if (sphereBathroom == 1)
        {
            if (bathroomCompleted != null)
                bathroomCompleted.SetActive(true);
                Bathroom.GetComponent<Renderer>().enabled = false;
            //LookHere.SetActive(false);
        }
        if (sphereOutside == 1)
        {
            if (outsideCompleted != null)
                outsideCompleted.SetActive(true);
                Outside.GetComponent<Renderer>().enabled = false;
            //LookHere.SetActive(false);
        }
        if (sphereLiving == 1)
        {
            if (livingCompleted != null)
                livingCompleted.SetActive(true);
            LivingIcon.GetComponent<Renderer>().enabled = false;
            //LookHere.SetActive(false);
        }

        if (sphereBathroom == 1 && sphereGarage == 1 && sphereBedroom == 1 && sphereLaundry == 1 && sphereKitchen == 1 && sphereBasement == 1 && sphereOutside == 1 && sphereLiving == 1)
        {
            // print("All rooms are completed");
            if (Camera.main.transform.parent.position != new Vector3(0f, 0f, 10.52f))
                homeButtonExit.SetActive(true);
           // showMenu.SetActive(false);
            homeButton.SetActive(false);
            visitedAll = true;

            //Debug.Log(visitedAll + "last room");
            //if (ExitBtn != null)
            //ExitBtn.SetActive(true);

        }

    }

    public IEnumerator GoTos()
    {

        ///arrayCompleted.Add(livingCompleted);
        // if (livingCompleted != null)
        ///
        //livingCompleted.SetActive(true);
       

        if (transform.position == new Vector3(11.81f, -0.25f, 0.7492169f))
        {
            if (Basement != null)
            {
                sphereBasement = 1;
                Basement.SetActive(false);
                Basement.GetComponent<Renderer>().enabled = false;
                Basement_text.SetActive(true);
                BasementRoomSphere.SetActive(true);

                if (Kitchen_text != null)
                    Kitchen_text.SetActive(false);
                if (Bedroom_text != null)
                    Bedroom_text.SetActive(false);
                if (Bathroom_text != null)
                    Bathroom_text.SetActive(false);
                if (Garage_text != null)
                    Garage_text.SetActive(false);
                if (Laundry_text != null)
                    Laundry_text.SetActive(false);
                if (Outside_text != null)
                    Outside_text.SetActive(false);


                KitchenRoomSphere.SetActive(false);
                BathRoomSphere.SetActive(false);
                BedRoomSphere.SetActive(false);
                LivingRoomSphere.SetActive(false);
                LaundryRoomSphere.SetActive(false);
                GarageRoomSphere.SetActive(false);
                OutsideRoomSphere.SetActive(false);
               // LookHere.SetActive(false);
            }

        }
        // Kitchen
        else if (transform.position == new Vector3(5.83f, -0.25f, 0.537f))
        {
           // Debug.Log("Kitchen");

            if (Kitchen != null)
            {
                sphereKitchen = 1;
                Kitchen.SetActive(false);
                Kitchen.GetComponent<Renderer>().enabled = false;
                Kitchen_text.SetActive(true);
                KitchenRoomSphere.SetActive(true);

                if (Basement_text != null)
                    Basement_text.SetActive(false);
                if (Bedroom_text != null)
                    Bedroom_text.SetActive(false);
                if (Bathroom_text != null)
                    Bathroom_text.SetActive(false);
                if (Garage_text != null)
                    Garage_text.SetActive(false);
                if (Laundry_text != null)
                    Laundry_text.SetActive(false);
                if (Outside_text != null)
                    Outside_text.SetActive(false);
                if (Living_text != null)
                    Living_text.SetActive(false);

                LivingRoomSphere.SetActive(false);
                BathRoomSphere.SetActive(false);
                BedRoomSphere.SetActive(false);
                BasementRoomSphere.SetActive(false);
                LaundryRoomSphere.SetActive(false);
                GarageRoomSphere.SetActive(false);
                OutsideRoomSphere.SetActive(false);
              //  LookHere.SetActive(false);

            }

        }

        // Bathroom

        else if (transform.position == new Vector3(17.94f, -0.25f, 5.832f))
        {
            if (Bathroom != null)
            {
                sphereBathroom = 1;
                Bathroom.SetActive(false);
                Bathroom.GetComponent<Renderer>().enabled = false;
                Bathroom_text.SetActive(true);
                BathRoomSphere.SetActive(true);

                if (Kitchen_text != null)
                    Kitchen_text.SetActive(false);
                if (Basement_text != null)
                    Basement_text.SetActive(false);
                if (Bedroom_text != null)
                    Bedroom_text.SetActive(false);
                if (Garage_text != null)
                    Garage_text.SetActive(false);
                if (Laundry_text != null)
                    Laundry_text.SetActive(false);
                if (Outside_text != null)
                    Outside_text.SetActive(false);
                LookHere.SetActive(false);
                KitchenRoomSphere.SetActive(false);
                LivingRoomSphere.SetActive(false);
                BedRoomSphere.SetActive(false);
                BasementRoomSphere.SetActive(false);
                LaundryRoomSphere.SetActive(false);
                GarageRoomSphere.SetActive(false);
                OutsideRoomSphere.SetActive(false);
                //LookHere.SetActive(false);
            }
        }
        // Bedroom
        else if (transform.position == new Vector3(23.23f, -0.25f, 0.7492169f))
        {
            if (Bedroom != null)
            {
                sphereBedroom = 1;
                Bedroom.SetActive(false);
                Bedroom.GetComponent<Renderer>().enabled = false;
                Bedroom_text.SetActive(true);
                BedRoomSphere.SetActive(true);

                if (Kitchen_text != null)
                    Kitchen_text.SetActive(false);
                if (Basement_text != null)
                    Basement_text.SetActive(false);
                if (Bathroom_text != null)
                    Bathroom_text.SetActive(false);
                if (Garage_text != null)
                    Garage_text.SetActive(false);
                if (Laundry_text != null)
                    Laundry_text.SetActive(false);
                if (Outside_text != null)
                    Outside_text.SetActive(false);
               

                KitchenRoomSphere.SetActive(false);
                BathRoomSphere.SetActive(false);
                LivingRoomSphere.SetActive(false);
                BasementRoomSphere.SetActive(false);
                LaundryRoomSphere.SetActive(false);
                GarageRoomSphere.SetActive(false);
                OutsideRoomSphere.SetActive(false);
               // LookHere.SetActive(false);
            }
        }
        // Laundry
        else if (transform.position == new Vector3(29.15f, -0.25f, 0.7492169f))
        {
            if (Laundry != null)
            {
                sphereLaundry = 1;
                Laundry.SetActive(false);
                Laundry.GetComponent<Renderer>().enabled = false;
                Laundry_text.SetActive(true);
                LaundryRoomSphere.SetActive(true);
                //laundryCompleted.SetActive(true);

                if (Kitchen_text != null)
                    Kitchen_text.SetActive(false);
                if (Basement_text != null)
                    Basement_text.SetActive(false);
                if (Bedroom_text != null)
                    Bedroom_text.SetActive(false);
                if (Bathroom_text != null)
                    Bathroom_text.SetActive(false);
                if (Garage_text != null)
                    Garage_text.SetActive(false);
                if (Outside_text != null)
                    Outside_text.SetActive(false);

               // LookHere.SetActive(false);
                KitchenRoomSphere.SetActive(false);
                BathRoomSphere.SetActive(false);
                BedRoomSphere.SetActive(false);
                BasementRoomSphere.SetActive(false);
                LivingRoomSphere.SetActive(false);
                GarageRoomSphere.SetActive(false);
                OutsideRoomSphere.SetActive(false);
            }
        }

        // Garage
        else if (transform.position == new Vector3(34.69f, -0.25f, 0.7492169f))
        {
            if (Garage != null)
            {
                sphereGarage = 1;
                Garage.SetActive(false);
                Garage.GetComponent<Renderer>().enabled = false;
                Garage_text.SetActive(true);
                GarageRoomSphere.SetActive(true);

                if (Kitchen_text != null)
                    Kitchen_text.SetActive(false);
                if (Basement_text != null)
                    Basement_text.SetActive(false);
                if (Bedroom_text != null)
                    Bedroom_text.SetActive(false);
                if (Bathroom_text != null)
                    Bathroom_text.SetActive(false);
                if (Laundry_text != null)
                    Laundry_text.SetActive(false);
                if (Outside_text != null)
                    Outside_text.SetActive(false);

               // LookHere.SetActive(false);
                KitchenRoomSphere.SetActive(false);
                BathRoomSphere.SetActive(false);
                BedRoomSphere.SetActive(false);
                BasementRoomSphere.SetActive(false);
                LaundryRoomSphere.SetActive(false);
                LivingRoomSphere.SetActive(false);
                OutsideRoomSphere.SetActive(false);
            }
        }
        // Outside
        else if (transform.position == new Vector3(39.62f, -0.25f, 0.7492169f))
        {
            if (Outside != null)
            {
                sphereOutside = 1;
                Outside.SetActive(false);
                Outside.GetComponent<Renderer>().enabled = false;
                Outside_text.SetActive(true);
                OutsideRoomSphere.SetActive(true);

                if (Kitchen_text != null)
                    Kitchen_text.SetActive(false);
                if (Basement_text != null)
                    Basement_text.SetActive(false);
                if (Bedroom_text != null)
                    Bedroom_text.SetActive(false);
                if (Bathroom_text != null)
                    Bathroom_text.SetActive(false);
                if (Laundry_text != null)
                    Laundry_text.SetActive(false);
                if (Garage_text != null)
                    Garage_text.SetActive(false);

                LookHere.SetActive(false);
                KitchenRoomSphere.SetActive(false);
                BathRoomSphere.SetActive(false);
                BedRoomSphere.SetActive(false);
                BasementRoomSphere.SetActive(false);
                LaundryRoomSphere.SetActive(false);
                GarageRoomSphere.SetActive(false);
              //  LivingRoomSphere.SetActive(false);
            }
        }
        //Living Room
        else if (transform.position == new Vector3(-4.99f, 0f, 0f) && !isLivingRoom)
        {
            if (LivingIcon != null)
                sphereLiving = 1;
            LivingIcon.SetActive(false);
            LivingIcon.GetComponent<Renderer>().enabled = false;
                Living_text.SetActive(true);
                LivingRoomSphere.SetActive(true);

            if (Kitchen_text != null)
                Kitchen_text.SetActive(false);
            if (Basement_text != null)
                Basement_text.SetActive(false);
            if (Bedroom_text != null)
                Bedroom_text.SetActive(false);
            if (Bathroom_text != null)
                Bathroom_text.SetActive(false);
            if (Garage_text != null)
                Garage_text.SetActive(false);
            if (Laundry_text != null)
                Laundry_text.SetActive(false);
            if (Outside_text != null)
                Outside_text.SetActive(false);

            KitchenRoomSphere.SetActive(false);
            BathRoomSphere.SetActive(false);
            BedRoomSphere.SetActive(false);
            BasementRoomSphere.SetActive(false);
            LaundryRoomSphere.SetActive(false);
            GarageRoomSphere.SetActive(false);
            OutsideRoomSphere.SetActive(false);
            //LookHere.SetActive(false);
            Debug.Log("Living ~ ShowLiving");
            isLivingRoom = true;
        }
        else if (transform.position == new Vector3(0f, 0f, 0f))
        {
            if (sphereBathroom == 1 && sphereGarage == 1 && sphereBedroom == 1 && sphereLaundry == 1 && sphereKitchen == 1 && sphereBasement == 1 && sphereOutside == 1 && sphereLiving == 1)
            {

                //LookHere.GetComponent<Renderer>().enabled = false;
             //   if (ExitBtn != null)
              //      ExitBtn.SetActive(true);
                homeButtonExit.SetActive(false);
                homeButton.SetActive(false);
                m_ToggleChange = true;
                visitedAll = true ;
                

}
        }
        else
        {


          
        }
        yield return new WaitForSeconds(2);

    }


    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }

        print("done");
    }



}

