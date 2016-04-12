using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace Contexts
{
    public class GuiContextView : ContextView
    {
        void Awake()
        {
            GuiContext context = new GuiContext(this, true);
            context.Start();
            DontDestroyOnLoad(this);
        }
    }
}