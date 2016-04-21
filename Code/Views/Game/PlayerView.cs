using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Signals;
using strange.extensions.signal.impl;
using strange.extensions.promise.api;

namespace Views
{
    public class PlayerView : View, IPlayerView
    {
        public Signal<Rigidbody,Vector3> movePlayer { get; set; }

        #region Private Variables
        private CharacterController playerCharacterController { get; set; }
        private Rigidbody playerRigidbody { get; set; }

        [SerializeField]
        private bool isPlayerCentered;

        [SerializeField]
        private float centeredSpeed;
        private float nonCenteredSpeed { get; set; }
        private Vector3 forwardAndLeftVector { get; set; }
        private Vector3 forwardAndRightVector { get; set; }
        #endregion

        public void Init()
        {
            Debug.Log("Player View is alive");
            centeredSpeed = 10f;
            nonCenteredSpeed = 12f;
            isPlayerCentered = false;
            playerRigidbody = this.gameObject.GetComponent<Rigidbody>();
            forwardAndLeftVector = new Vector3(-1, 0, 1);
            forwardAndRightVector = new Vector3(1, 0, 1);
            movePlayer = new Signal<Rigidbody, Vector3>();
        }

        void Update()
        {
            MovePlayer();
        }

        #region Private Methods
        private void OnTriggerEnter(Collider col)
        {
            if(col.tag == "ChaseComponent")
               isPlayerCentered = true;
        }
        
        private void OnTriggerExit(Collider col)
        {
           if(col.tag == "ChaseComponent")
               isPlayerCentered = false;
        }

        private void MovePlayer()
        {
            if (isPlayerCentered)
            {
                movePlayer.Dispatch(playerRigidbody, (transform.position + (Vector3.forward * centeredSpeed * Time.deltaTime)));
                MoveLeftOrRight(centeredSpeed);
            }
            else
            {
                movePlayer.Dispatch(playerRigidbody, (transform.position + (Vector3.forward * nonCenteredSpeed * Time.deltaTime)));
                MoveLeftOrRight(nonCenteredSpeed);
            }
        }

        private void MoveLeftOrRight(float speed)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                movePlayer.Dispatch(playerRigidbody, (transform.position + (forwardAndLeftVector * speed * Time.deltaTime)));
            else if (Input.GetKey(KeyCode.RightArrow))
                movePlayer.Dispatch(playerRigidbody, (transform.position + (forwardAndRightVector * speed * Time.deltaTime)));
        }
        #endregion
    }
}