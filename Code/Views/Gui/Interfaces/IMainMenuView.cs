using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

namespace Views
{
    public interface IMainMenuView
    {
        Signal startGame { get; set; }
        Signal quitGame { get; set; }
        void Init();
    }
}