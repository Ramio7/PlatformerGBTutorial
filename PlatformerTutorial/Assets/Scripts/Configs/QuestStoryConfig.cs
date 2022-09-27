using UnityEngine;

namespace PlatformerTutorial
{
    [CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "Configs / Quests / QuestStoryConfig", order = 1)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType questStoryType;
    }
    public enum QuestStoryType
    {
        Common,
        Resettable
    }
}
