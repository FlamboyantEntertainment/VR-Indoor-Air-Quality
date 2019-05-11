using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;


namespace VRStandardAssets.Menu
{
    // This script is for loading scenes from the main menu.
    // Each 'button' will be a rendering showing the scene
    // that will be loaded and use the SelectionRadial.
    public class HomeButton : MonoBehaviour
    {
        // public event Action<MenuButtonHover> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

        [SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
        [SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
        [SerializeField] private SelectRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.

        [SerializeField] private Transform nextSphere;
       // public Transform basementSphere;
       // [SerializeField] public int sphereBasement;
       // [SerializeField] public int sphereKitchen;
        public Vector3 basement;
        // public Vector3 kitchen;

        //public List<Vector3> targetList = new List<Vector3>();

        public bool GoToDone = false;
        private bool m_GazeOver;
        [SerializeField] public ShowLiving m_ShowLiving;
        Camera cam;// Whether the user is looking at the VRInteractiveItem currently.
       

        private void OnEnable ()
        {
            if (m_InteractiveItem != null)
                m_InteractiveItem.OnOver += HandleOver;
            if (m_InteractiveItem != null)
                m_InteractiveItem.OnOut += HandleOut;
            if (m_SelectionRadial != null)
                m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
           // sphereBasement = 0;
           // sphereKitchen = 0;
        }


       
        private void HandleOver()
        {
            // When the user looks at the rendering of the scene, show the radial.
            m_SelectionRadial.Show();
            m_GazeOver = true;
        }


        private void HandleOut()
        {
            // When the user looks away from the rendering of the scene, hide the radial.
            m_SelectionRadial.Hide();

            m_GazeOver = false;
       
        }


        public void HandleSelectionComplete()
        {
            // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
            if (m_GazeOver)
                //Application.Quit();
               StartCoroutine(ActivateButton());
            GoToDone = true;
        }

        void Start()
         {
            //Debug.Log(Camera.main.transform.parent.position);
           // basement = new Vector3(11.8f, -0.3f, 0.7f);
           
        }

        void Update()
        {
            //Vector3 basement = cam.WorldToViewportPoint(basementSphere.position);
            //Debug.Log(basement);
            //if (basement.x > 5.8f)
            //{
            //Debug.Log(basementSphere + "Princess Got It");
            //}
           
        }


        IEnumerator ActivateButton()
        {
            // Load the level.
            SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
            yield return new WaitForSeconds(0.75f);
        }

    }
}