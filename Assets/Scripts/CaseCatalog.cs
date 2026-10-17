using System.Collections.Generic;

namespace DataQuest
{
    public static class CaseCatalog
    {
        public static IReadOnlyList<DetectiveCase> All { get; } = new[]
        {
            new DetectiveCase
            {
                Id = "falling-sales", Title = "The Falling Sales", RequiredLevel = 1,
                Briefing = "Find the month where the sales trend changed.",
                Challenges = new List<Challenge>
                {
                    new Challenge
                    {
                        Prompt = "Which month shows the first sustained decline?",
                        Answers = new[] { "January", "March", "June", "December" },
                        CorrectAnswer = 2, XpReward = 100
                    }
                }
            },
            new DetectiveCase
            {
                Id = "chart-master", Title = "Chart Master", RequiredLevel = 2,
                Briefing = "Match each chart to the business question it answers.",
                Challenges = new List<Challenge>()
            }
        };
    }
}
