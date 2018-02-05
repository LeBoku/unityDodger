using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnSpeed = 3;
    public GameObject enemy;

    private Vector3 bottomRight;
    private Vector3 topLeft;

    void Start() {
		topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        InvokeRepeating("SpawnEnemy", 0, spawnSpeed);
    }

    void SpawnEnemy() {
        var spawnPosition = new Vector3();
        var side = Random.Range(0, 4);

        switch (side) {
            case 0: // top
                spawnPosition.y = topLeft.y;
                spawnPosition.x = getRandomX();
                break;
            case 1: // right
                spawnPosition.y = getRandomY();
                spawnPosition.x = bottomRight.x;
                break;
            case 2: // bottom
                spawnPosition.y = bottomRight.y;
                spawnPosition.x = getRandomX();
                break;
            case 3: // left
                spawnPosition.y = getRandomY();
                spawnPosition.x = topLeft.x;
                break;
        }
		
        var mob = Instantiate(enemy);
		mob.transform.position = spawnPosition;
    }

	float getRandomX (){
		return Random.Range(topLeft.x, bottomRight.x);
	}

	float getRandomY (){
		return Random.Range(topLeft.y, bottomRight.y);
	}
}
