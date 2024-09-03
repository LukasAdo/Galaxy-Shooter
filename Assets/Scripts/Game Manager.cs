using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool isGameOver;


    private void Update()
    {
        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }


}
