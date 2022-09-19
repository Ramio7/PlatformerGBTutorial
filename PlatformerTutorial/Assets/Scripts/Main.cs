using UnityEngine;

namespace PlatformerTutorial
{
    public class Main : MonoBehaviour
    {
        private GameObjectView _playerView;
        private PlayerMovement _playerMovement;

        private LevelGeneratorView _levelGeneratorView;
        private LevelGeneratorController _levelGeneratorController;

        private void Awake()
        {
            _playerView = FindObjectOfType<GameObjectView>();
            _playerMovement = new(_playerView);

            _levelGeneratorView = FindObjectOfType<LevelGeneratorView>();
            _levelGeneratorController = new(_levelGeneratorView);
            _levelGeneratorController.Start();
        }

        void Update()
        {
            _playerMovement?.Update();
        }
    }
}