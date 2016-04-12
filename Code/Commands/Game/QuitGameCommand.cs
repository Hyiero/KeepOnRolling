using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using Managers;
using UnityEngine.SceneManagement;

namespace Commands
{
    public class QuitGameCommand : Command
    {
        public override void Execute()
        {
            Debug.Log("We will exit the application at this point");
        }
    }
}