using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public Vector3 playerStartPosition;

    public GameObject scoreLabel;
    public GameObject gameTextLabel;

    public GameObject player;

    private Text scoreLabelText;

    private bool isRunning = false;
    private float score = 0;

    void Start() {
        scoreLabelText = scoreLabel.GetComponent<Text>();
        SetSpawnerState(false);
        player.GetComponent<Player>().enabled = false;
    }

    void Update() {
        if (isRunning) {
            UpdateScore();
        } else {
            if (Input.anyKey || Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) {
                StartGame();
            }
        }
    }

    void StartGame() {
        isRunning = true;
        score = 0;
        gameTextLabel.SetActive(false);

        DestroyEnemies();
        SetSpawnerState(true);

        player.transform.position = playerStartPosition;
        player.GetComponent<Player>().enabled = true;
    }

    void GameOver() {
        isRunning = false;

        foreach (var actor in GetAllActors()) {
            actor.GetComponent<MonoBehaviour>().enabled = false;
        }

        SetSpawnerState(false);
        gameTextLabel.SetActive(true);
    }

    void UpdateScore() {
        score += Time.deltaTime;
        scoreLabelText.text = score.ToString("F2");
    }

    void SetSpawnerState(bool toState) {
        foreach (var spawner in GameObject.FindGameObjectsWithTag("Spawner")) {
            spawner.GetComponent<Spawner>().enabled = toState;
        }
    }

    List<GameObject> GetAllActors() {
        var actors = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        actors.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("Obstacle")));

        return actors;
    }

    void DestroyEnemies() {
        foreach (var enemy in GetAllActors()) {
            GameObject.Destroy(enemy);
        }
    }
}
