using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
    public float initialRotationSpeed;
    public float initialSpeed;
    public float aggressionThreshold;

    private GameObject player;

    void Start() {
        player = GameObject.FindWithTag("Player");
        transform.localRotation = (player.transform.position - transform.position).ToRotation();
    }

    void Update() {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer() {
        var playerDirection = player.transform.position - transform.position;

        float rotationSpeed = initialRotationSpeed;
        float speed = initialSpeed;

        if (playerDirection.magnitude < aggressionThreshold) {
            rotationSpeed /= 2;
            speed *= 2;
        }

        var rotation = Quaternion.RotateTowards(transform.localRotation, playerDirection.ToRotation(), rotationSpeed * Time.deltaTime);

        transform.localRotation = rotation;
        transform.localPosition += rotation.ToDirection() * (speed * Time.deltaTime);
    }
}