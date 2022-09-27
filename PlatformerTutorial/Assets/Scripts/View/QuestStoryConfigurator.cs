using PlatformerTutorial;
using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestStoryConfigurator : MonoBehaviour
{
    [SerializeField] private QuestObjectView _singleQuestView;
    [SerializeField] private QuestStoryConfig[] _questStoryConfigs;
    [SerializeField] private QuestObjectView[] _questObjects;

    private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories =
    new Dictionary<QuestType, Func<IQuestModel>>
    {
        { QuestType.Switch, () => new SwitchQuestModel() },
    };

    private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>
    _questStoryFactories = new Dictionary<QuestStoryType, Func<List<IQuest>,
    IQuestStory>>
    {
        { QuestStoryType.Common, questCollection => new QuestStoryController(questCollection) },
    };

}
