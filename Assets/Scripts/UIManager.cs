using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Image livesIMG;
    [SerializeField]
    private Sprite[] livesSprites;
    
    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = "Score: " + 0;
    }

    public void updateScore (int playerScore)
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives (int currentLives)
    {
        livesIMG.sprite = livesSprites[currentLives];
    }

    public void _gameOver()
    {
        StartCoroutine(GameOverFlickerRoutine());
    }
    IEnumerator GameOverFlickerRoutine()
    {
        while (true) 
        {
            gameOverText.gameObject.SetActive(true); 
            yield return new WaitForSeconds(0.5f); 

            gameOverText.gameObject.SetActive(false); 
            yield return new WaitForSeconds(0.5f); 
        }
    }
}
