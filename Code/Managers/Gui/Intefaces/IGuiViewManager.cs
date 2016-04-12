using UnityEngine;
using System.Collections;

namespace Managers
{
    public interface IGuiViewManager
    {
        void Init();
        void ToggleMainMenu();
        void ToggleGuiCameraAudioListener();
    }
}