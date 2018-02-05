using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public double moveSpeed = 0.2;

    private Vector3 topLeft;
    private Vector3 bottomRight;

    void Start() {
        topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update() {
        var direction = new Vector3();
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (direction.magnitude > 0) {
            direction.Normalize();

            var directionAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.localRotation = Quaternion.Euler(0, 0, directionAngle);

            var newPosition = transform.position + direction * (float)moveSpeed;

            newPosition.x = Mathf.Clamp(newPosition.x, topLeft.x, bottomRight.x);
            newPosition.y = Mathf.Clamp(newPosition.y, topLeft.y, bottomRight.y);

            transform.position = newPosition;
        }
    }
}
