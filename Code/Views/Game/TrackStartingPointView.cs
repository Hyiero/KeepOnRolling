using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace Views
{
    public class TrackStartingPointView : View,ITrackStartingPointView
    {
        [SerializeField]
        private Transform trackTransform;

        private bool notInStartingPosition = false;

        void Start()
        {
            base.Start();
            trackTransform = this.gameObject.transform.parent;
            MoveToStartingPoint();
        }

        public void MoveToStartingPoint()
        {
            notInStartingPosition = true;
            Debug.Log("Moving to starting point");
        }

        void Update()
        {
            if(notInStartingPosition)
            {
                Debug.Log("We should be moving");
                trackTransform.Translate(Vector3.forward * 105f * Time.deltaTime);
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Player")
            {
                Debug.Log("We got to the Starting Position");
                notInStartingPosition = false;
                //TODO: Here we will turn off this gameObject using a Signal, don't want the update constantly running
                //ToggleGameManagerElements((int)Constant.GameManagerElements.StartTrackPointView)
            }
        }
    }
}