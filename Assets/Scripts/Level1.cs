using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Level1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI yourScoreText;
    [SerializeField] TextMeshProUGUI newRecordText;

    
    public int levelScore = 0;
    int oldRecord;
 
    void Start()
    {
        GameManager.gameOver = false;
        scoreText.text = levelScore.ToString();

        //PlayerData data = SavingRecord.LoadRecord();
        //oldRecord = data.record;
        if (!GameManager.gameOver)
        {

        int index = Random.Range(1, 40);
        string strindex = index.ToString();
        Instantiate(Resources.Load("lotus_" + strindex), transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        // Check if the user is on a non-main scene and presses the Escape key (only on PC)
        if (SceneManager.GetActiveScene().buildIndex != 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the main scene (assuming the main scene is at build index 0)
            SceneManager.LoadScene(0);
        }
    }



    public void UpdateScore(int pointsToAdd)
    {
        levelScore += pointsToAdd;
        scoreText.text = levelScore.ToString();
    }

    public void GameOver()
    {
        GameManager.score = levelScore;
        GameManager.gameOver = true;
        GameManager.instance.GetComponent<GameManager>().GameEnded();
        Debug.Log("Level1 activated GameEnded in GameManager");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Debug.Log("Scene 0 loaded");

    }




}