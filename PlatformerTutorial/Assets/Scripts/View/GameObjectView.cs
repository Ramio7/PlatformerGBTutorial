using UnityEngine;

namespace PlatformerTutorial
{
    public class GameObjectView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Collider2D Collider;
        public Rigidbody2D Rigidbody;

        private void Awake()
        {
            if (TryGetComponent(out Collider2D collider)) Collider = collider;
            else throw new System.Exception("No 2D collider attached");
            
            if (TryGetComponent(out Rigidbody2D rigidbody)) Rigidbody = rigidbody;
            else throw new System.Exception("No 2D rigidbody attached");

            if (TryGetComponent(out SpriteRenderer spriteRenderer)) SpriteRenderer = spriteRenderer;
            else throw new System.Exception("No sprite renderer attached");
        }
    }
}