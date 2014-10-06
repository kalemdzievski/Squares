using System;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine;

namespace AssemblyCSharp
{
	public static class Achievements
	{
		public static readonly float PROGRESS = 100.0f;

		public static readonly string LINE5 = "CgkIip-4vp4DEAIQAQ";
		public static readonly string LINE6 = "CgkIip-4vp4DEAIQAg";
		public static readonly string LINE7 = "CgkIip-4vp4DEAIQAw";

		public static void unlockAchievement(String achievementCode, float progress)
		{
			Social.ReportProgress(achievementCode, progress, (bool success) => {});
		}
	}
}

