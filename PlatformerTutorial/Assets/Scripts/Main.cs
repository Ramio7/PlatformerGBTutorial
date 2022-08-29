using UnityEngine;

namespace PlatformerTutorial
{
    public class Main : MonoBehaviour
    {
        private AnimatorConfig _config;
        private GameObjectView _playerView;
        private SpriteAnimationController _playerAnimator;

        private void Awake()
        {
            _config = Resources.Load<AnimatorConfig>("SpriteAnimatorCfg");
            _playerAnimator = new SpriteAnimationController(_config);
            _playerView = FindObjectOfType<GameObjectView>();
            _playerAnimator.StartAnimation(_playerView.spriteRenderer, AnimState.Idle, true, 10);
        }

        void Update()
        {
            _playerAnimator?.Update();
        }
    }
}