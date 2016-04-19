using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Signals;

namespace Views
{
    public class PlayerView : View, IPlayerView
    {
        [SerializeField]
        private Rigidbody playerRigidbody;

        [SerializeField]
        private bool isPlayerCentered;

        [SerializeField]
        private bool onTrack;

        private float centeredSpeed = 10.1f;
        private float nonCenteredSpeed = 12f;

        public void Init()
        {
            Debug.Log("Player View is alive");
        }

        protected override void Start()
        {
            base.Start();
            playerRigidbody = this.gameObject.GetComponent<Rigidbody>();
            isPlayerCentered = false;
            onTrack = true;
        }

        void FixedUpdate()
        {
            //if (onTrack)
            //{
                if (isPlayerCentered)
                {
                    //playerRigidbody.velocity = Vector3.forward * centeredSpeed;
                    //this.gameObject.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
                    transform.Translate(Vector3.forward * 10.1f * Time.deltaTime); //Stutters when doing this but gravity and map tilt works perfectly with this
                    MoveLeftOrRight(centeredSpeed);
                }
                else
                {
                    //playerRigidbody.velocity = Vector3.forward * nonCenteredSpeed;
                    //this.gameObject.transform.Translate(Vector3.forward * 12f * Time.deltaTime);
                    transform.Translate(Vector3.forward * 12f * Time.deltaTime); //Stutters when doing this but gravity and map tilt works perfectly with this
                    MoveLeftOrRight(nonCenteredSpeed);
                }
            //}
        }

        void OnCollisionExit(Collision col)
        {
            if (col.collider.tag == "Track")
            {
                Debug.Log("We fell");
                //playerRigidbody.velocity = new Vector3(0, -1, 0) * centeredSpeed;
                onTrack = false;
            }
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
                playerRigidbody.velocity = new Vector3(-1, 0, 1) * speed;
            else if (Input.GetKey(KeyCode.RightArrow))
                playerRigidbody.velocity = new Vector3(1, 0, 1) * speed;
        }
    }
}