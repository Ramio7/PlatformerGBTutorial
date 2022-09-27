using System;
using UnityEngine;

namespace PlatformerTutorial
{
    public class PlayerView : GameObjectView
    {
        public Action<AmmunitionView> TakeDamage { get; set; }
        public Action<QuestObjectView> OnQuestComplete { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out GameObjectView contactView))
            {
                if (contactView is AmmunitionView _view) TakeDamage?.Invoke(_view);
                if (contactView is QuestObjectView _view1) OnQuestComplete?.Invoke(_view1);
            }
        }
    }
}