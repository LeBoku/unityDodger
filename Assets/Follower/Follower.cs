using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
    public float rotationSpeed;
    public float speed;

    private GameObject player;

    void Start() {
        player = GameObject.FindWithTag("Player");
        transform.localRotation = (player.transform.position - transform.position).ToRotation();
    }

    void Update() {
        LookAtPlayer();
    }

    void LookAtPlayer() {
        var playerDirection = player.transform.position - transform.position;
        var rotation = Quaternion.RotateTowards(transform.localRotation, playerDirection.ToRotation(), rotationSpeed * Time.deltaTime);

        transform.localRotation = rotation;
        transform.localPosition += rotation.ToDirection() * (speed * Time.deltaTime);
    }
}