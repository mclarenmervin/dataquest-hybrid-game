using System;
using UnityEngine;

namespace DataQuest
{
    [Serializable]
    public class PlayerProgress
    {
        public int Xp;
        public int CompletedCases;
        public int Level => Math.Max(1, (Xp / 500) + 1);
    }

    public sealed class ProgressionService
    {
        private const string SaveKey = "dataquest.progress.v1";
        public PlayerProgress Progress { get; private set; }

        public ProgressionService() => Load();

        public void AddXp(int amount)
        {
            Progress.Xp = Math.Max(0, Progress.Xp + amount);
            Save();
        }

        public void CompleteCase()
        {
            Progress.CompletedCases++;
            Save();
        }

        public void Save() => PlayerPrefs.SetString(SaveKey, JsonUtility.ToJson(Progress));

        private void Load()
        {
            var json = PlayerPrefs.GetString(SaveKey, string.Empty);
            Progress = string.IsNullOrEmpty(json)
                ? new PlayerProgress()
                : JsonUtility.FromJson<PlayerProgress>(json) ?? new PlayerProgress();
        }
    }
}
