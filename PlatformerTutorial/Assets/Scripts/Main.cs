using UnityEngine;

namespace PlatformerTutorial
{
    public class Main : MonoBehaviour
    {
        private GameObjectView _playerView;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerView = FindObjectOfType<GameObjectView>();
            _playerMovement = new(_playerView);
        }

        void Update()
        {
            _playerMovement?.Update();
        }
    }
}