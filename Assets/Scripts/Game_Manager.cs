using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    int Player_Score = 0;
    int AI_Score = 0;
    [SerializeField] Ball_Behaviour Ball;
    [SerializeField] Text Player_ScoreCard;
    [SerializeField] Text AI_ScoreCard;
    [SerializeField] Transform Player_Scaler;
    [SerializeField] Transform AI_Scaler;
    [SerializeField] ParticleSystem Player_Effect;
    [SerializeField] ParticleSystem AI_Effect;
    [SerializeField] Text Game_Over_Text;
    [Space]
    [SerializeField] int Win_Point = 11;
  
    public void Add_Player_Score()
    {
        Player_Score++;
        Reset_Ball();
    }
    public void Add_AI_Score()
    {
        AI_Score++;
        Reset_Ball();
    }

    private bool Check_Winner()
    {
        if(AI_Score >= Win_Point)
        {
            AI_Effect.gameObject.SetActive(true);
            Game_Over_Text.gameObject.SetActive(true);
            Game_Over_Text.text = "AI WINS";
            return true;
        }
        else if(Player_Score >= Win_Point)
        {
            Player_Effect.gameObject.SetActive(true);
            Game_Over_Text.gameObject.SetActive(true);
            Game_Over_Text.text = "PLAYER WINS";
            return true;
        }
        return false;
    }

    public void Reset_Ball()
    {
        Update_ScoreCard();
        if (Check_Winner())
        {
            Ball.Set_Ball(false);
            FindObjectOfType<Player_Controller>().Disable_Movement();
        }
        Ball.Reset_Ball_To_Center();
    }

    private string Fancy_Number(float Score)
    {
        if(Score < 10)
        {
            return "0" + Score.ToString();
        }
        return Score.ToString();
    }
    public void Reset_Scene()
    {
        Player_Score = 0;
        AI_Score = 0;
        Player_Effect.gameObject.SetActive(false);
        AI_Effect.gameObject.SetActive(false);
        Ball.Set_Ball(true);
        Reset_Ball();
    }
    private void Update_ScoreCard()
    {
        Player_ScoreCard.text = Fancy_Number(Player_Score);
        Player_Scaler.localScale = new Vector3(Player_Scaler.localScale.x, Player_Score / 11f, Player_Scaler.localScale.z);
        AI_ScoreCard.text = Fancy_Number(AI_Score);
        AI_Scaler.localScale = new Vector3(AI_Scaler.localScale.x, AI_Score / 11f, AI_Scaler.localScale.z);
    }

}
