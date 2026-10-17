using UnityEngine;
using UnityEngine.UI;

namespace DataQuest
{
    public sealed class PrototypeUI : MonoBehaviour
    {
        private GameSession session;
        private Text content;
        private DetectiveCase selected;

        private void Start()
        {
            session = FindObjectOfType<GameSession>();
            if (session == null) session = new GameObject("GameSession").AddComponent<GameSession>();
            var canvas = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            var panel = new GameObject("Panel", typeof(Image));
            panel.transform.SetParent(canvas.transform, false);
            var r = panel.GetComponent<RectTransform>();
            r.anchorMin = new Vector2(.1f, .1f); r.anchorMax = new Vector2(.9f, .9f);
            panel.GetComponent<Image>().color = new Color(.06f, .08f, .13f, .98f);
            content = new GameObject("Content", typeof(Text)).GetComponent<Text>();
            content.transform.SetParent(panel.transform, false);
            var t = content.rectTransform; t.anchorMin = new Vector2(.06f, .08f); t.anchorMax = new Vector2(.94f, .92f);
            content.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); content.fontSize = 28; content.color = Color.white;
            ShowCases();
        }

        public void ShowCases()
        {
            var p = session.Progression.Progress;
            content.text = $"DATAQUEST HYBRID\n\nLevel {p.Level}   XP {p.Xp}   Cases solved {p.CompletedCases}\n\n";
            foreach (var c in CaseCatalog.All) content.text += session.IsUnlocked(c) ? $"[READY] {c.Title}\n{c.Briefing}\n\n" : $"[LOCKED] {c.Title} (Level {c.RequiredLevel})\n\n";
            content.text += "OpenCase(0) starts the first case.";
        }

        public void OpenCase(int index)
        {
            if (index < 0 || index >= CaseCatalog.All.Count || !session.IsUnlocked(CaseCatalog.All[index])) return;
            selected = CaseCatalog.All[index];
            if (selected.Challenges.Count == 0) return;
            var c = selected.Challenges[0]; content.text = $"{selected.Title}\n\n{c.Prompt}\n\n";
            for (var i = 0; i < c.Answers.Length; i++) content.text += $"{i + 1}. {c.Answers[i]}\n";
            content.text += "\nSubmitAnswer(2) submits the first answer.";
        }

        public void SubmitAnswer(int answerIndex)
        {
            if (selected == null || selected.Challenges.Count == 0) return;
            var c = selected.Challenges[0];
            if (answerIndex == c.CorrectAnswer) { session.Progression.AddXp(c.XpReward); session.Progression.CompleteCase(); content.text = $"Correct! +{c.XpReward} XP\n\nCall ShowCases() to continue."; }
            else content.text = "Not quite. Review the evidence and try again.";
        }
    }
}
