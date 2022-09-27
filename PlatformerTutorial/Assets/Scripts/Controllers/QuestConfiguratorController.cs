using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlatformerTutorial
{
    public class QuestConfiguratorController
    {
        private QuestObjectView _singleQuestView;
        private QuestController _singleQuestController;
        private QuestStoryConfig[] _questStoryConfig;
        private QuestObjectView[] _storyQuestsView;
        private QuestCoinModel _questCoinModel;

        private List<IQuestStory> _questStoryList;
        private PlayerView _player;

        private Dictionary<QuestType, Func<IQuestModel>> _questFactory = new Dictionary<QuestType, Func<IQuestModel>>();
        private Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactory = new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>();

        public QuestConfiguratorController(PlayerView player, QuestView questView)
        {
            _player = player;
            _singleQuestView = questView.singleQuest;
            _storyQuestsView = questView.questObjects;
            _questCoinModel = new QuestCoinModel();
            _questStoryConfig = questView.storyConfig;
        }

        public void Start()
        {
            _singleQuestController = new(_player, _questCoinModel, _singleQuestView);
            _singleQuestController.Reset();

            _questFactory.Add(QuestType.Coins, ()=>new QuestCoinModel());
            _questStoryFactory.Add(QuestStoryType.Common, questCollection => new QuestStoryController(questCollection));

            _questStoryList = new List<IQuestStory>();
            foreach (QuestStoryConfig questStoryConfig in _questStoryConfig)
            {
                _questStoryList.Add(CreateQuestStory(questStoryConfig));
            }
        }

        private IQuestStory CreateQuestStory(QuestStoryConfig questStoryConfig)
        {
            List<IQuest> quests = new();
            foreach (QuestConfig item in questStoryConfig.quests)
            {
                IQuest quest = CreateQuest(item);

                if (quest == null) continue;

                quests.Add(quest);
                Debug.Log("Quest added");
            }

            return _questStoryFactory[questStoryConfig.questStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig questConfig)
        {
            int questID = questConfig.id;
            QuestObjectView questObjectView = _storyQuestsView.FirstOrDefault(value => value.questObjectID == questID);

            if (questObjectView == null)
            {
                Debug.Log("Quest Object View is empty");
                return null;
            }

            if (_questFactory.TryGetValue(questConfig.questType, out var factory))
            {
                IQuestModel qModel = factory.Invoke();
                return new QuestController(_player, qModel, questObjectView);
            }

            Debug.Log("Quest Object Model is empty");
            return null;
        }
    }
}