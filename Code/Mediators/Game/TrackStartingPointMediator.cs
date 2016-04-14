using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Views;
using Signals;

namespace Mediators
{
    public class TrackStartingPointMediator : EventMediator
    {
        [Inject]
        public ITrackStartingPointView view { get; set; }
        [Inject]
        public MoveTrackToStartPointSignal moveTrackToStartPoint { get; set; }

        public override void OnRegister()
        {
            moveTrackToStartPoint.AddListener(MoveTrackToStartingPoint);
        }

        private void MoveTrackToStartingPoint()
        {
            view.MoveToStartingPoint();
        }
    }
}