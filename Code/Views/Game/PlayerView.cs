using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Signals;

namespace Views
{
    public class PlayerView : View, IPlayerView
    {
        [SerializeField]
        private CharacterController playerCharacterController;

        [SerializeField]
        private bool isPlayerCentered;

        [SerializeField]
        private bool onTrack;

        private float centeredSpeed = 10f;
        private float nonCenteredSpeed = 12f;

        public void Init()
        {
            Debug.Log("Player View is alive");
        }

        protected override void Start()
        {
            base.Start();
            playerCharacterController = this.gameObject.GetComponent<CharacterController>();
            isPlayerCentered = false;
            onTrack = true;
        }

        void Update()
        {
            if (isPlayerCentered)
            {
                //playerRigidbody.velocity = Vector3.forward * centeredSpeed;
                playerCharacterController.Move(Vector3.forward * centeredSpeed * Time.deltaTime);
                //this.gameObject.transform.Translate(Vector3.forward * centeredSpeed * Time.deltaTime); //Transform.Translate actually doesn't check for collisions??
                MoveLeftOrRight(centeredSpeed);
            }
            else
            {
                //playerRigidbody.velocity = Vector3.forward * nonCenteredSpeed;
                playerCharacterController.Move(Vector3.forward * nonCenteredSpeed * Time.deltaTime);
                //transform.Translate(Vector3.forward * nonCenteredSpeed * Time.deltaTime); //Transform.Translate actually doesn't check for collisions??
                MoveLeftOrRight(nonCenteredSpeed);
            }
        }

        void OnCollisionExit(Collision col)
        {
            if (col.collider.tag == "Track")
                onTrack = false;
        }

        void OnTriggerEnter(Collider col)
        {
            Debug.Log("Entered a trigger zone");
            isPlayerCentered = true;
        }
        
        void OnTriggerExit(Collider col)
        {
            Debug.Log("Exited a trigger zone");
            isPlayerCentered = false;
        }

        private void MoveLeftOrRight(float speed)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                playerCharacterController.Move(Vector3.left * 10f * Time.deltaTime);
            else if (Input.GetKey(KeyCode.RightArrow))
                playerCharacterController.Move(Vector3.right * 12f * Time.deltaTime);
        }
    }
}