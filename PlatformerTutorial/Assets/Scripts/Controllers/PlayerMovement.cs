using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTutorial
{
    public class PlayerMovement
    {
        private const float _walkSpeed = 4f;
        private const float _animationsSpeed = 15f;
        private const float _jumpForce = 8f;
        private const float _movingThresh = 0.1f;
        private const float _jumpThresh = 1f;
        private const float _groundLevel = 0.0f;
        private const float _g = -9.8f;

        private Vector3 _leftScale = new(-1, 1, 1);
        private Vector3 _rightScale = new(1, 1, 1);

        private float _yVelocity;
        private bool _doJump;
        private float _xAxisInput;

        private readonly GameObjectView _view;
        private readonly AnimatorConfig _config;
        private readonly SpriteAnimationController _spriteAnimator;

        public PlayerMovement(GameObjectView view)
        {
            _view = view;

            _config = Resources.Load<AnimatorConfig>("SpriteAnimatorCfg");
            _spriteAnimator = new(_config);
            _spriteAnimator.StartAnimation(_view.SpriteRenderer, AnimState.Idle, true, _animationsSpeed);
        }

        public void Update()
        {
            _spriteAnimator.Update();

            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");

            var goSideWay = Mathf.Abs(_xAxisInput) > _movingThresh;

            if (IsGrounded())
            {
                if (goSideWay) GoSideWay();
                _spriteAnimator.StartAnimation(_view.SpriteRenderer, goSideWay ? AnimState.Run : AnimState.Idle, true, _animationsSpeed);

                if (_doJump && _yVelocity == 0)
                {
                    _yVelocity = _jumpForce;
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = 0;
                    _view.transform.position.Set(_view.transform.position.x, _groundLevel, _view.transform.position.z);
                }
            }
            else
            {
                if (goSideWay) GoSideWay();

                if (Mathf.Abs(_yVelocity) > _jumpThresh)
                {
                    _spriteAnimator.StartAnimation(_view.SpriteRenderer, AnimState.Jump, true, _animationsSpeed);
                }

                _yVelocity += _g * Time.deltaTime;
                _view.transform.position += Vector3.up * (Time.deltaTime *
                _yVelocity);
            }
        }
        private void GoSideWay()
        {
            _view.transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _view.transform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }
        public bool IsGrounded()
        {
            return _view.transform.position.y <= _groundLevel && _yVelocity <= 0;
        }

    }
}