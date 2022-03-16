using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    private int highScore;
    public GameObject resultUI;
    public Text resultTime;
    public Text baseTime;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 999;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Goal.goal == true)
        {
            resultUI.SetActive(true);
            int result = Mathf.FloorToInt(Timer.time);
            resultTime.text = "ResultTime : " + result;
            baseTime.text = "BaseTime :" + highScore;

            if (highScore > result)
            {
                PlayerPrefs.SetInt("HighScore" , result);
            }
        }
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
