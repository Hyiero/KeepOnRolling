using UnityEngine;
using System.Collections;
using Managers;
using strange.extensions.mediation.impl;

namespace Services
{
    public class GuiService : MonoBehaviour, IGuiService
    {
        [Inject]
        public IGuiViewManager guiViewManager { get; set; }

        public void StartNewGame()
        {
            guiViewManager.ToggleMainMenu();
            guiViewManager.ToggleGuiCameraAudioListener();
        }
    }
}
