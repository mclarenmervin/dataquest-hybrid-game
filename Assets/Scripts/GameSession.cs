using UnityEngine;

namespace DataQuest
{
    public sealed class GameSession : MonoBehaviour
    {
        public ProgressionService Progression { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Progression = new ProgressionService();
        }

        public bool IsUnlocked(DetectiveCase detectiveCase) =>
            Progression.Progress.Level >= detectiveCase.RequiredLevel;
    }
}
