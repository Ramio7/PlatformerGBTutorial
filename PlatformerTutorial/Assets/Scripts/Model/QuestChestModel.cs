using UnityEngine;

namespace PlatformerTutorial
{
    public class QuestChestModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag("QuestChest");
        }
    }
}
