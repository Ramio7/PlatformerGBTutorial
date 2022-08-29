using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTutorial
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        Jump = 2,
        Crouch = 3,
        Climb = 4,
        Hurt = 5,
    }

    [CreateAssetMenu(fileName = "SpriteAnimatorCfg", menuName = "Configs / Animation", order = 1)]
    public class AnimatorConfig : ScriptableObject
    {
        [Serializable]
        public class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new();
        }

        public List<SpriteSequence> Sequences = new();
    }
}

