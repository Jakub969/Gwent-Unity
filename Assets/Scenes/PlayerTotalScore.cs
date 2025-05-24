using UnityEngine;
using UnityEngine.UI;

public class PlayerTotalScore : MonoBehaviour
{
    public PlayerRowScore meleeScore;
    public PlayerRowScore rangedScore;
    public PlayerRowScore siegeScore;
    public Text totalScoreText;

    void Update()
    {
        int total =
            meleeScore.GetCurrentScore() +
            rangedScore.GetCurrentScore() +
            siegeScore.GetCurrentScore();

        totalScoreText.text = total.ToString();
    }

    public int CalculatePlayerScore() {
        int total =
            meleeScore.GetCurrentScore() +
            rangedScore.GetCurrentScore() +
            siegeScore.GetCurrentScore();
        return total;
    }
    public void ResetScores()
    {
        meleeScore.ResetScore();
        rangedScore.ResetScore();
        siegeScore.ResetScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
