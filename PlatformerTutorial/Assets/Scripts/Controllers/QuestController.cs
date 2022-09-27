using System;

namespace PlatformerTutorial
{
    public class QuestController : IQuest
    {
        private PlayerView _player;
        private bool _active;
        private IQuestModel _model;
        private QuestObjectView _quest;

        public QuestController(PlayerView player, IQuestModel model, QuestObjectView view)
        {
            _model = model;
            _quest = view;
            _player = player;
            _active = false;
        }

        public bool IsCompleted { get; private set; }

        public event EventHandler<IQuest> QuestCompleted;

        public void OnContact(QuestObjectView questItem)
        {
            if (questItem != null)
            {
                if (_model.TryComplete(questItem.gameObject))
                {
                    if (questItem == _quest) Completed();
                }
            }
        }

        private void Completed()
        {
            if (!_active) return;

            _active = false;
            Dispose();
            _quest.ProcessComplete();
            QuestCompleted?.Invoke(this, this);
        }

        public void Dispose()
        {
            _player.OnQuestComplete -= OnContact;
        }

        public void Reset()
        {
            if (_active) return;

            _active = true;
            _player.OnQuestComplete += OnContact;
            _quest.ProcessActivate();
        }
    }
}