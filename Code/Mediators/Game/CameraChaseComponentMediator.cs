using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Views;

namespace Mediators
{
    public class CameraChaseComponentMediator : EventMediator
    {
        [Inject]
        public ICameraChaseComponentView view { get; set; }

        public override void OnRegister()
        {
            Debug.Log("Chase Component is now alive");
            view.Init();
        }
    }
}
