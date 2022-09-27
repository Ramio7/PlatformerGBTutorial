using UnityEngine;

namespace PlatformerTutorial
{
    public sealed class SwitchQuestModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag("Player");
        }
    }
}