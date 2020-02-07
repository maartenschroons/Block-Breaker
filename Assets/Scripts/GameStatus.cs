using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f, 10f)] [SerializeField] float timeScale = 1f;
    [SerializeField] int playercurrentScore = 0;
    [SerializeField] int scorePerBlock = 80;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            scoreText.text = playercurrentScore.ToString();
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
        scoreText.text = playercurrentScore.ToString();
    }

    public void addScore()
    {
        playercurrentScore += scorePerBlock;
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }

}
