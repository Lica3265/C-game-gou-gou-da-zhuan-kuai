using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button button;
    public int brickCount = 14;
    public Text scoreText;
    public Text winText;

    int score = 0;


    void TaskOnClick (){
        Time.timeScale = 1;
        brickCount = 14;
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.name);
    }
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        scoreText.text = "Score = 0 ";
    
    }

    // Update is called once per frame
    void Update()
    {
        CheckWinCondition();
    }
    public void UpdateScore()
    {
        score++;
        brickCount--;
        scoreText.text = "Score : " + score.ToString();
    }

    public void CheckWinCondition()
    {
        if (brickCount <= 0)
        {
            winText.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
