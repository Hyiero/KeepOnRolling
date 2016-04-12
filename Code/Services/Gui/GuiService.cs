using UnityEngine;
using System.Collections;
using Managers;

namespace Services
{
    public class GuiService : IGuiService
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
