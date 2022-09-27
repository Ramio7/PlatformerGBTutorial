using UnityEngine;

namespace PlatformerTutorial
{
    public class Main : MonoBehaviour
    {
        private PlayerView _playerView;
        private PlayerMovementController _playerMovement;
        private QuestObjectView _singleQuestItem;
        [SerializeField] private QuestView _questView;

        //private LevelGeneratorView _levelGeneratorView;
        //private LevelGeneratorController _levelGeneratorController;
        private QuestConfiguratorController _questController;

        private void Awake()
        {
            _playerView = FindObjectOfType<PlayerView>();
            _playerMovement = new(_playerView);

            //_levelGeneratorView = FindObjectOfType<LevelGeneratorView>();
            //_levelGeneratorController = new(_levelGeneratorView);
            //_levelGeneratorController.Start();

            //_singleQuestItem = FindObjectOfType<QuestObjectView>();
            _questView = FindObjectOfType<QuestView>();
            _questController = new(_playerView, _questView);
            _questController.Start();
        }

        void Update()
        {
            _playerMovement?.Update();
        }
    }
}