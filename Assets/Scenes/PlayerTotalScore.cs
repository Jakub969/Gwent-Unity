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
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
