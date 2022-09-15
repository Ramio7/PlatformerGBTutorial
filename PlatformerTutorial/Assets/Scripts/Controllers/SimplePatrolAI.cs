using System;
using UnityEngine;

namespace PlatformerTutorial
{
    public class SimplePatrolAI
    {
        #region Fields
        private readonly GameObjectView _view;
        private readonly SimplePatrolAIModel _model;
        #endregion
        #region Class life cycles
        public SimplePatrolAI(GameObjectView view, SimplePatrolAIModel model)
        {
            _view = view != null ? view : throw new
            ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new
            ArgumentNullException(nameof(model));
        }
        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view.transform.position) *
            Time.fixedDeltaTime;
            _view.Rigidbody.velocity = newVelocity;
        }
        #endregion
    }
}
