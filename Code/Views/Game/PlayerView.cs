using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Signals;

namespace Views
{
    public class PlayerView : View, IPlayerView
    {
        public void Init()
        {
            Debug.Log("Player View is alive");
        }
    }
}