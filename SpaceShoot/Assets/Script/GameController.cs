using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazards;
    public GameObject player;
    public Vector3 spawnValues;
    public int hazardCount;
    public int score;
    public float spawnWait;
    public float waveWait;
    public float startWait;
    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;

    private bool gameOver;
    private bool restart;
    // Start is called before the first frame update

    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        UpdateScore();
        StartCoroutine( SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazards, spawnPosition, spawnRotation);// as GameObject;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver == true)
            {
                RestartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score : " + score;
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }

}
