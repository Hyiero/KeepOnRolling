using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using Managers;
using Services;

namespace Commands
{
    public class StartUpGameCommand : Command
    {
        [Inject]
        public IGameService gameService { get; set; }

        public override void Execute()
        {
            gameService.Init();
            Debug.Log("GameContext has now been engaged");
        }
    }
}