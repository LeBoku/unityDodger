using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
    public float initialRotationSpeed;
    public float initialSpeed;
    public float aggressionThreshold;

    private GameObject player;
    private Animator stateMachine;
    private Rigidbody2D body;

    void Start() {
        player = GameObject.FindWithTag("Player");
        stateMachine = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        transform.localRotation = (player.transform.position - transform.position).ToRotation();
    }

    void FixedUpdate() {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer() {
        var playerDirection = player.transform.position - transform.position;
        stateMachine.SetFloat("Distance", playerDirection.magnitude);

        float rotationSpeed = initialRotationSpeed;
        float speed = initialSpeed;

        if (stateMachine.GetCurrentAnimatorStateInfo(0).IsName("Charging")) {
            rotationSpeed = initialRotationSpeed / 3;
            speed = initialSpeed * 3;
        } else if (stateMachine.IsInTransition(0)) {
            rotationSpeed = initialRotationSpeed * 2;
            speed = 0;
        }

        var rotation = Quaternion.RotateTowards(transform.localRotation, playerDirection.ToRotation(), rotationSpeed * Time.deltaTime);

        transform.localRotation = rotation;
        transform.localPosition += rotation.ToDirection() * (speed * Time.deltaTime);
    }
}