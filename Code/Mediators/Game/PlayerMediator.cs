using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Views;
using Signals;

namespace Mediators
{
    public class PlayerMediator : EventMediator
    {
        [Inject]
        public IPlayerView view { get; set; }

        [Inject]
        public MoveRigidBodySignal moveRigidBodySig { get; set; }

        public override void OnRegister()
        {
            view.Init();
            view.movePlayer.AddListener(MovePlayer);
        }

        private void MovePlayer(Rigidbody playerRigidbody,Vector3 newPosition)
        {
            moveRigidBodySig.Dispatch(playerRigidbody, newPosition);
        }
    }
}