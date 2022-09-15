using UnityEngine;

namespace PlatformerTutorial
{
    public interface IProtector
    {
        void StartProtection(GameObject invader);
        void FinishProtection(GameObject invader);
    }

}