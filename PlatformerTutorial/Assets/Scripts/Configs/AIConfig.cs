using System;
using UnityEngine;

namespace PlatformerTutorial
{
    [Serializable]
    public struct AIConfig
    {
        public float speed;
        public float minDistanceToTarget;
        public Transform[] waypoints;
        public float minSqrDistanceToTarget;
    }
}