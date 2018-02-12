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
            if (Input.anyKey) {
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

    void UpdateScore() {
        score += Time.deltaTime;
		scoreLabelText.text = score.ToString("F2");
    }

    void SetSpawnerState(bool toState) {
        foreach (var spawner in GameObject.FindGameObjectsWithTag("Spawner")) {
            spawner.GetComponent<Spawner>().enabled = toState;
        }
    }

    void DestroyEnemies() {
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            GameObject.Destroy(enemy);
        }
    }
}
