using System;
using System.Collections.Generic;

namespace DataQuest
{
    [Serializable]
    public class Challenge
    {
        public string Prompt;
        public string[] Answers;
        public int CorrectAnswer;
        public int XpReward = 100;
    }

    [Serializable]
    public class DetectiveCase
    {
        public string Id;
        public string Title;
        public string Briefing;
        public int RequiredLevel;
        public List<Challenge> Challenges = new();
    }
}
