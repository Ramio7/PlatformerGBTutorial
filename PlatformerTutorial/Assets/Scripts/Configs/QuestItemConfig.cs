using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTutorial
{
    [CreateAssetMenu(fileName = "QuestItemsConfig", menuName = "Configs / Quests / QuestItemsConfig", order = 1)]
    public class QuestItemsConfig : ScriptableObject
    {
        public int questId;
        public List<int> questItemIdCollection;
    }

}