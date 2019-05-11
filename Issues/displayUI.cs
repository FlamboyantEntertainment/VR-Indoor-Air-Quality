using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class displayUI : MonoBehaviour {

	public string myString;

    public Text textFire;
    public Text titleFire;
    public Image imageFire;


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
        displayInfo = true;
        imageFire.enabled = true;
    
    }
    private void HandleOut()
    {
        displayInfo = false;
        imageFire.enabled = false;

    }


    // Use this for initialization
    void Start () {

        textFire = GameObject.Find("Fire_text").GetComponent<Text>();
        textFire.color = Color.clear;

        titleFire = GameObject.Find("Fire_title").GetComponent<Text>();
        titleFire.color = Color.clear;

        imageFire = GameObject.Find("Fire_image").GetComponent<Image>();
        imageFire.enabled = false;
    }

	// Update is called once per frame
	void Update () 
	{

		FadeText ();

		/*if (Input.GetKeyDown (KeyCode.Escape)) 
         
                {
                        Screen.lockCursor = false;
                         
                }
                */


	}

	void OnMouseOver()
	{
		displayInfo = true;

	}



	void OnMouseExit()

	{
		displayInfo = false;

	}


	void FadeText ()

	{


		if(displayInfo)
		{

            textFire.supportRichText = textFire;
            textFire.color = Color.Lerp(textFire.color, Color.black, fadeTime * Time.deltaTime);

            titleFire.supportRichText = titleFire;
            titleFire.color = Color.Lerp(titleFire.color, Color.black, fadeTime * Time.deltaTime);

        }

		else
		{

            textFire.color = Color.Lerp(textFire.color, Color.clear, fadeTime * Time.deltaTime);
            titleFire.color = Color.Lerp(titleFire.color, Color.clear, fadeTime * Time.deltaTime);
        }




	}



}

