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
            transform.localRotation = direction.ToRotation();

            var newPosition = transform.localPosition + (direction * (float)moveSpeed) * Time.deltaTime;

            newPosition.x = Mathf.Clamp(newPosition.x, topLeft.x, bottomRight.x);
            newPosition.y = Mathf.Clamp(newPosition.y, topLeft.y, bottomRight.y);

            transform.localPosition = newPosition;
        }
    }
}
