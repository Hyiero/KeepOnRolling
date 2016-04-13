using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace Views
{
    public class PlayerView : View, IPlayerView
    {
        protected override void Start()
        {
            base.Start();
            Debug.Log("Hi im the player and Im awake");
        }

        public void Init()
        {
            Debug.Log("Player View is alive");
        }
    }
}