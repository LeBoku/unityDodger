using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speed;
    public Vector3 direction;

    void Start() {
        var directionAngle = transform.position.ToRotation().eulerAngles.z + 180 + Random.Range(-15, 15);
        direction = Quaternion.AngleAxis(directionAngle, Vector3.forward).ToDirection();

        speed = speed != 0 ? speed : Random.Range(1, 3);
    }

    void Update() {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnBecameInvisible(){
        this.enabled = false;
        Destroy(gameObject);
    }
}
