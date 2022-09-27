using UnityEngine;

namespace PlatformerTutorial
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}