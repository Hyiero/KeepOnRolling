using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

namespace Views
{
    public interface IPlayerView
    {
        Signal<Rigidbody,Vector3> movePlayer { get; set; }
        void Init();
    }
}