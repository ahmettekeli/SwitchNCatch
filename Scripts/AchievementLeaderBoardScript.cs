using UnityEngine;
using System.Collections;

public class AchievementLeaderBoardScript : MonoBehaviour {

    public GPGS_script gpgs;
    public static string leaderboard = "CgkI3vnGwcYdEAIQBg";

  
    private string scored25 = "CgkI3vnGwcYdEAIQAQ";
    private string scored50 = "CgkI3vnGwcYdEAIQAg";
    private string scored100 = "CgkI3vnGwcYdEAIQAw";
    private string scored150 = "CgkI3vnGwcYdEAIQBA";
    private string scored200 = "CgkI3vnGwcYdEAIQBQ";

   
    // Update is called once per frame
    void Update()
    {

        //Unlocking Score based achievements
        switch ((int)ScoreScript.score)
        {
            case 25:
                {
                    gpgs.AchievementSuccess(scored25);
                    break;
                }
            case 50:
                {
                    gpgs.AchievementSuccess(scored50);
                    break;
                }
            case 100:
                {
                    gpgs.AchievementSuccess(scored100);
                    break;
                }
            case 150:
                {
                    gpgs.AchievementSuccess(scored150);
                    break;
                }
            case 200:
                {
                    gpgs.AchievementSuccess(scored200);
                    break;
                }
        }


    }
}
