using UnityEngine;
using System.Collections;

namespace Managers
{
    public interface IGameManager
    {
        void SetNewGameElements(GameObject player, GameObject track);
    }
}