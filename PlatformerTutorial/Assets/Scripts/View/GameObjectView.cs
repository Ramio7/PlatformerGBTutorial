using UnityEngine;

namespace PlatformerTutorial
{
    public class GameObjectView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Collider2D Collider;
        public Rigidbody2D Rigidbody;

        private void OnEnable()
        {
            Collider = GetComponent<Collider2D>();
            Rigidbody = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}