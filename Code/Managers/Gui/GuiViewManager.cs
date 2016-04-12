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