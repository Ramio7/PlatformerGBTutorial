using UnityEngine;

namespace PlatformerTutorial
{
    public class PlayerMovement
    {
        private const float _walkForce = 4f;
        private const float _animationsSpeed = 15f;
        private const float _jumpForce = 20f;
        private const float _movingThreshold = 0.1f;
        private const float _jumpThreshold = 1f;

        private Vector3 _leftScale = new(-1, 1, 1);
        private Vector3 _rightScale = new(1, 1, 1);

        private float _yVelocity;
        private float _xVelocity;
        private bool _doJump;
        private float _xAxisInput;

        private readonly GameObjectView _view;
        private readonly AnimatorConfig _config;
        private readonly SpriteAnimationController _spriteAnimator;
        private readonly ContactsPooler _contactsPooler;

        public PlayerMovement(GameObjectView view)
        {
            _view = view;
            
            _config = Resources.Load<AnimatorConfig>("SpriteAnimatorCfg");

            _spriteAnimator = new(_config);
            _spriteAnimator.StartAnimation(_view.SpriteRenderer, AnimState.Idle, true, _animationsSpeed);

            _contactsPooler = new ContactsPooler(_view.Collider);
        }

        public void Update()
        {
            _spriteAnimator.Update();
            _contactsPooler.Update();

            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            _yVelocity = _view.Rigidbody.velocity.y;

            var goSideWay = Mathf.Abs(_xAxisInput) > _movingThreshold;

            _spriteAnimator.StartAnimation(_view.SpriteRenderer, goSideWay ? AnimState.Run : AnimState.Idle, true, _animationsSpeed);

            if (goSideWay)
            {
                GoSideWay();
            }
            else
            {
                _xVelocity = 0;
                _view.Rigidbody.velocity = new Vector2(0, _view.Rigidbody.velocity.y);
            }

            if (_contactsPooler.IsGrounded)
            {
                if (_doJump && _yVelocity <= _jumpThreshold && _contactsPooler.IsGrounded)
                {
                    _view.Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpThreshold)
                {
                    _spriteAnimator.StartAnimation(_view.SpriteRenderer, AnimState.Jump, true, _animationsSpeed);
                }
            }
        }
        private void GoSideWay()
        {
            _xVelocity += Time.fixedDeltaTime * _walkForce * (_xAxisInput < 0 ? -1 : 1);
            _view.Rigidbody.velocity = new Vector2(_xVelocity, _yVelocity);
            _view.transform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }

    }
}