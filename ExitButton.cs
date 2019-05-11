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
    public class ExitButton : MonoBehaviour
    {
        // public event Action<MenuButtonHover> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

        [SerializeField] private SelectRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.

     
        private bool m_GazeOver;
      
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

          //  m_GazeOver = false;
       
        }


        public void HandleSelectionComplete()
        {
            // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
            if (m_GazeOver)
                Application.Quit();
           // Application.Quit();
            // StartCoroutine(ActivateButton());
            //GoToDone = true;
        }

        

    }
}