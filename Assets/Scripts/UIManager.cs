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
    private Text restartGameText;
    [SerializeField]
    private Image livesIMG;
    [SerializeField]
    private Sprite[] livesSprites;

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = "Score: " + 0;
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void updateScore (int playerScore)
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives (int currentLives)
    {
        livesIMG.sprite = livesSprites[currentLives];

        if (currentLives == 0)
        {
            gameManager.GameOver();
        }
       
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

    public void restartGame()
    {
        StartCoroutine(restartGameRoutine());
    }
    IEnumerator restartGameRoutine()
    {
        while (true)
        {
            restartGameText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            restartGameText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
