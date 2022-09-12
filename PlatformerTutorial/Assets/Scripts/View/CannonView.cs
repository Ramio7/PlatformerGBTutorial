using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTutorial
{
    public class CannonView : GameObjectView
    {
        public Transform _targetTransform;
        public Transform _ammoStartTransform;

        private AmmunitionPool _ammoPool;

        void OnEnable()
        {
            _targetTransform = FindObjectOfType<PlayerView>().gameObject.transform;
            _ammoStartTransform = transform.Find("AmmoStartPosition");

            if (_targetTransform == null) throw new System.Exception("No player found on scene");
            if (_ammoStartTransform == null) throw new System.Exception("Add AmmoStartPosition empty child object to game object");
        }
    }
}