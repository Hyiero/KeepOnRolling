using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Views;

namespace Managers
{
    public class GuiViewManager : View,IGuiViewManager
    {
        [SerializeField]
        private GameObject mainMenuViewGO;

        [SerializeField]
        private GameObject guiCamera;

        private AudioListener guiCameraAudioListener { get; set; }

        public void Init()
        {
            guiCameraAudioListener = guiCamera.GetComponent<AudioListener>();
            Debug.Log("We will deactive whatever we need to at this point and time");
            //TODO: BY Passes Start Menu. This is so we don't have to go through start menu, comment out if want to test with start menu screen
            ToggleMainMenu();
            ToggleGuiCameraAudioListener();
        }

        public void ToggleMainMenu()
        {
            if (mainMenuViewGO.activeInHierarchy)
                mainMenuViewGO.SetActive(false);
            else
                mainMenuViewGO.SetActive(true);
        }

        public void ToggleGuiCameraAudioListener()
        {
            if (guiCameraAudioListener.isActiveAndEnabled)
                guiCameraAudioListener.enabled = false;
            else
                guiCameraAudioListener.enabled = true;
        }
    }
}