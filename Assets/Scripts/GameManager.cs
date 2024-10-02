using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static reference to the instance of our SceneManager
    public static GameManager instance;

    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject menuGraphics;

    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject yourScorePanel;
    [SerializeField] TextMeshProUGUI yourScoreText;
    [SerializeField] GameObject newRecordPanel;
    [SerializeField] GameObject titleScreenPanel;

    [SerializeField] float blinkingSpeed = 0.4f;

    public static int score = 0;
    int oldRecord = 0;

    public static bool gameOver = false;

    private void Awake()
    {
        // Check if instance already exists. If not, set instance to this
        if (instance == null)
        {
            instance = this;
        }
        
        else
        {
            Destroy(gameObject);
        }
        


        // Set this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        /*
        menuCanvas = GameObject.Find("Canvas");
        menuGraphics = GameObject.Find("Menu Graphics");

        gameOverText = menuCanvas.transform.GetChild(1).gameObject;
        yourScorePanel = menuCanvas.transform.GetChild(3).gameObject;
        yourScoreText = yourScorePanel.transform.GetComponent<TextMeshProUGUI>();
        newRecordPanel = menuCanvas.transform.GetChild(5).gameObject;
        titleScreenPanel = menuCanvas.transform.GetChild(2).gameObject;
        */

        if (gameOver)
        {
            gameOverText.SetActive(true);
            yourScorePanel.SetActive(true);
            yourScoreText.text = score.ToString();
        }
        ResetGameScene();
        LoadScore();


        //PlayerData data = SavingRecord.LoadRecord();
        //oldRecord = data.record;

    }

    void ResetGameScene()
    {
        //If there is already a game loaded, for example after a GAME OVER, remove it
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    //Called by pressing the Start button
    public void PressedStart()
    {
        //Load a new GameScene (Level1), without removing the Menu scene (additive)
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

        gameOver = false;
        titleScreenPanel.SetActive(false);
        menuCanvas.SetActive(false);
        menuGraphics.SetActive(false);
    }

    public void GameEnded()
    {
        if (gameOver)
        {
            gameOverText.SetActive(true);
            yourScorePanel.SetActive(true);
            yourScoreText.text = score.ToString();
        }




        if (score > oldRecord)
        {
            newRecordPanel.SetActive(true);
            StartCoroutine(BlinkText(blinkingSpeed));
            SaveScore();
        }



    }

    private IEnumerator BlinkText(float speed)
    {
        while (true)
        {
            if (newRecordPanel.activeInHierarchy)
            {
                newRecordPanel.SetActive(false);
            }
            else
            {
                newRecordPanel.SetActive(true);
            }
            yield return new WaitForSeconds(speed);
        }
    }

    //These 2 methods will be used by SavingRecord to read and save the player record
    public void SaveScore()
    {
        SavingRecord.SaveRecord(score);
    }

    public void LoadScore()
    {
        PlayerData data = SavingRecord.LoadRecord();
        if (data == null)
        {
            SaveScore();
        }
        else
        {
            oldRecord = data.record;
            Debug.Log("The current record is " + oldRecord);

        }
    }

}