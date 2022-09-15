using Pathfinding;
using System;

namespace PlatformerTutorial
{
    public class AIPatrolPath : AIPath
    {
        #region Events
        public event EventHandler TargetReach;
        #endregion
        #region Inheritance
        public override void OnTargetReached()
        {
            base.OnTargetReached();
            DispatchTargetReached();
        }
        #endregion
        #region Methods
        protected virtual void DispatchTargetReached()
        {
            TargetReach?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
