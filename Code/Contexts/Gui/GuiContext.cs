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
using Services;

namespace Contexts
{
    public class GuiContext : MVCSContext
    {
        public GuiContext(MonoBehaviour contextView, bool autoMap) : base(contextView, autoMap) { }

        private MainMenuView mainMenuView { get; set; }
        private GuiViewManager guiViewManager { get; set; }

        #region Needed for the use of Signals
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override void Launch()
        {
            base.Launch();
            StartUpGuiSignal startUpGuiSig = (StartUpGuiSignal)injectionBinder.GetInstance<StartUpGuiSignal>();
            startUpGuiSig.Dispatch();
        }
        #endregion

        protected override void mapBindings()
        {
            GetGameObjectReferences();

            //All Cross Context Bindings need to be mapped in the first context that is loaded.
            #region Cross Context and Singleton Elements
            injectionBinder.Bind<LaunchNewGameSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<QuitGameSignal>().ToSingleton().CrossContext();

            injectionBinder.Bind<IGuiService>().To<GuiService>().ToSingleton().CrossContext();

            injectionBinder.Bind<IGuiViewManager>().ToValue(guiViewManager).ToSingleton().CrossContext();
            #endregion

            injectionBinder.Bind<IMainMenuView>().ToValue(mainMenuView);

            mediationBinder.Bind<MainMenuView>().To<MainMenuMediator>();

            commandBinder.Bind<StartUpGuiSignal>().To<StartUpGuiCommand>();
        }

        private void GetGameObjectReferences()
        {
            mainMenuView = GameObject.FindObjectOfType<MainMenuView>();
            guiViewManager = GameObject.FindObjectOfType<GuiViewManager>();
        }
    }
}