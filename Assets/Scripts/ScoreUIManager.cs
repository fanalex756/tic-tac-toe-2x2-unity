using UnityEngine;
using static TileManager;
using TMPro;

public class ScoreUIManager : MonoBehaviour
{
    public TextMeshProUGUI shieldScoreUI;
    public TextMeshProUGUI swordScoreUI;
    public int shieldScore;
    public int swordScore;

    void Start()
    {
        shieldScore = 0;
        swordScore = 0;
        shieldScoreUI.text = "Shield: " + shieldScore;
        swordScoreUI.text = "Sword: " + swordScore;
    }

    public void UpdateScore(Owner owner)
    {
        if (owner == Owner.Shield)
        {
            shieldScore++;
            shieldScoreUI.text = "Shield: " + shieldScore;
        }

        else
        {
            swordScore++;
            swordScoreUI.text = "Sword: " + swordScore;
        }
    }
}
