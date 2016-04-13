using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace Contexts
{
    public class GameContextView : ContextView
    {
        void Start()
        {
            context = new GameContext(this, true);
            context.Start();
            DontDestroyOnLoad(this);
        }
    }
}