using UnityEngine;
using System.Collections;

namespace Services
{
    public interface IGameService
    {
        void Init();
        void LoadNewGameObjectsAndSetParent();
    }
}