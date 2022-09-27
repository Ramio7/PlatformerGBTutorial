using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace PlatformerTutorial
{
    public sealed class QuestStoryController : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;

        public QuestStoryController(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection ?? throw new
            ArgumentNullException(nameof(questsCollection));
            Subscribe();
            ResetQuest(0);
        }

        private void Subscribe()
        {
            foreach (IQuest quest in _questsCollection) quest.QuestCompleted += OnQuestCompleted;
        }
        private void Unsubscribe()
        {
            foreach (IQuest quest in _questsCollection) quest.QuestCompleted -= OnQuestCompleted;
        }
        private void OnQuestCompleted(object sender, IQuest quest)
        {
            int index = _questsCollection.IndexOf(quest);
            if (IsDone)
            {
                Debug.Log("Story done!");
            }
            else
            {
                ResetQuest(++index);
            }
        }
        private void ResetQuest(int index)
        {
            if (index < 0 || index >= _questsCollection.Count) return;

            IQuest nextQuest = _questsCollection[index];

            if (nextQuest.IsCompleted) OnQuestCompleted(this, nextQuest);
            else _questsCollection[index].Reset();
        }

        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        public void Dispose()
        {
            Unsubscribe();
            foreach (IQuest quest in _questsCollection) quest.Dispose();
        }
    }
}