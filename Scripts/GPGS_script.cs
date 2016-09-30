using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GPGS_script : MonoBehaviour {

    void Start()
    {
        PlayGamesPlatform.Activate(); //activating google play games platform 
        Social.localUser.Authenticate((bool success) => //login screen opens and lets you choose your gmail account
        {
            if (success)
            {
                Debug.Log("You've successfully logged in.");
            }
            else
            {
                Debug.Log("Login failed for some reason.");
            }
        });
    }

    public void AchievementSuccess(string achievementString)
    {
        Social.ReportProgress(achievementString, 100.0f, (bool success) =>
          {
              //what to do when achievement is successfully unlocked!
              Debug.Log("Achievement is successfully unlocked!");

          });
    }

    //public void IncAchievementSuccess(string incAchievement)
    //{
    //    ((PlayGamesPlatform) Social.Active).IncrementAchievement(incAchievement,5,(bool success)=>
    //    {
    //        //Incremental Achievement unlocked successfully!
    //    });
    //}

    public static void PostScore()
    {
        Social.ReportScore((int)ScoreScript.score, AchievementLeaderBoardScript.leaderboard, (bool success) =>
          {
              //score posted to the leaderboard.
          });
    }

    public void showLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }
    public void showSpecLeaderboard()
    {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(AchievementLeaderBoardScript.leaderboard);
    }
    public void showAchievement()
    {
        Social.ShowAchievementsUI();
    }
    //public void SignOut()
    //{
    //    ((PlayGamesPlatform)Social.Active).SignOut();
    //}


}
