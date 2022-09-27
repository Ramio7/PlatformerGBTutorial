using UnityEngine;

namespace PlatformerTutorial
{
    public class QuestCoinModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag("QuestCoin");
        }
    }
}