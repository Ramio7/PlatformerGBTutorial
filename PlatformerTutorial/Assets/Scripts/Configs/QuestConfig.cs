using UnityEngine;

namespace PlatformerTutorial
{
    [CreateAssetMenu(fileName = "QuestConfig", menuName = "Configs / Quests / QuestConfig", order = 1)]
    public class QuestConfig : ScriptableObject
    {
        public int id;
        public QuestType questType;
    }
    public enum QuestType
    {
        Switch,
        Coins,
    }

}