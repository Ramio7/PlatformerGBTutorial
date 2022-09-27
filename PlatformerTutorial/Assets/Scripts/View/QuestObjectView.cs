using System;

namespace PlatformerTutorial
{
    public class QuestObjectView : GameObjectView
    {
        public bool IsPickable;
        public bool IsInteractable;

        public int questObjectID;

        public Action QuestObjectUsed;

        public void ProcessComplete()
        {
            if (IsInteractable) QuestObjectUsed?.Invoke();
            if (IsPickable) gameObject.SetActive(false);
        }

        public void ProcessActivate()
        {
            gameObject.SetActive(true);
        }
    }
}