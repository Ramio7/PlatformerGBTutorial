using System;

namespace PlatformerTutorial
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }

}