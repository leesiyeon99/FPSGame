using UnityEngine;
using UnityEngine.UI;

public class TextSupporter : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] public Text text;
    [SerializeField] GameManager gameManager;
    private void Update()
    {
        if (playerController.score == 15)
        {
            gameManager.GameOver();
        }
        ScoreText();
    }
    public void ScoreText()
    {
        text.text = playerController.score.ToString();
    }

}
