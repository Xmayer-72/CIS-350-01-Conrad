using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restart;
    public TextMeshProUGUI titleText;
    public GameObject difficultySelect;

    private int score;

    //num of spawns per second
    [SerializeField] private float spawnRate;

    public bool isGameActive;

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1/spawnRate);

            Instantiate(targets[Random.Range(0, targets.Count)]);
        }
    }

    // Update is called once per frame
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate = difficulty;
        
        isGameActive = true;

        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);

        restart.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        difficultySelect.SetActive(false);
    }
}
