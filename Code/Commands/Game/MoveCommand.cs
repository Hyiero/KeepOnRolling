using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using Managers;
using Services;

namespace Commands
{
    public class MoveCommand : Command
    {
        #region Injections
        [Inject]
        public Rigidbody rigidBody { get; set; }

        [Inject]
        public Vector3 position { get; set; }
        #endregion

        public override void Execute()
        {
            if(rigidBody != null)
            {
                rigidBody.MovePosition(position);
            }
        }
    }
}