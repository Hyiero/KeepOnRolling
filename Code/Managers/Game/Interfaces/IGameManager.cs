using UnityEngine;
using System.Collections;

namespace Managers
{
    public interface IGameManager
    {
        void SetGameObjectReference(GameObject player, GameObject track);
    }
}