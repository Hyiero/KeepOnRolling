using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace Views
{
    public class CameraChaseComponentView : View,ICameraChaseComponentView
    {
        [SerializeField]
        private Camera gameCamera;

        [SerializeField]
        private bool startChase;

        public void Init()
        {
            Debug.Log("Intialize any speed or constant values here for the chase component");
            startChase = false;
        }

        protected override void Start()
        {
            base.Start();
            gameCamera = this.gameObject.GetComponentInChildren<Camera>();
        }

        private void Update()
        {
            if(startChase)
                this.gameObject.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }
    }
}
