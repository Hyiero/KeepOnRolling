using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using Signals;
using Commands;
using Views;
using Mediators;
using Managers;
using System;

namespace Contexts
{
    public class GameContext : MVCSContext
    {
        public GameContext(MonoBehaviour contextView,bool autoMap) : base(contextView,autoMap) { }

        #region Needed for the use of Signals
        public override void Launch()
        {
            base.Launch();
            StartUpGameSignal startUpGameSig = (StartUpGameSignal)injectionBinder.GetInstance<StartUpGameSignal>();
            startUpGameSig.Dispatch();
        }
        #endregion

        protected override void mapBindings()
        {
            GetGameObjectReferences();

            commandBinder.Bind<QuitGameSignal>().To<QuitGameCommand>();
            commandBinder.Bind<LaunchNewGameSignal>().To<LaunchNewGameCommand>();
            commandBinder.Bind<StartUpGameSignal>().To<StartUpGameCommand>();
        }

        private void GetGameObjectReferences()
        {
        }
    }
}