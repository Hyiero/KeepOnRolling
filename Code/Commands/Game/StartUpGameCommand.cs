using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using Managers;

namespace Commands
{
    public class StartUpGameCommand : Command
    {
        public override void Execute()
        {
            Debug.Log("GameContext has now been engaged");
        }
    }
}