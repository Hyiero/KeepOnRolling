using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using Managers;
using Contexts;

namespace Commands
{
    public class StartUpGuiCommand : Command
    {
        [Inject]
        public IGuiViewManager guiViewManager { get; set; }

        public override void Execute()
        {
            guiViewManager.Init();
        }
    }
}