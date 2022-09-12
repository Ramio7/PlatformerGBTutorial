using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTutorial
{
    public class AmmunitionPool
    {
        public List<AmmunitionView> ammunitionViews;

        private readonly int index = 0;
        private readonly GameObject ammunitionPool;

        public AmmunitionPool(AmmunitionView ammunitionView)
        {
            ammunitionViews = new List<AmmunitionView>
            {
                ammunitionView
            };

            ammunitionPool = new(ammunitionView.GetType().Name);
            ammunitionPool.transform.position = Vector3.positiveInfinity;
        }

        public void UseAmmo(Transform ammoStartPosition)
        {
            var currentAmmo = ammunitionViews[index];
            currentAmmo.gameObject.SetActive(true);
            currentAmmo.transform.SetParent(ammoStartPosition);
            ammunitionViews.Remove(ammunitionViews[index]);
        }

        public void ReturnAmmo(AmmunitionView ammunitionView)
        {
            ammunitionViews.Add(ammunitionView);
            ammunitionView.transform.SetParent(ammunitionPool.transform);
            ammunitionView.gameObject.SetActive(false);
        }
    }
}