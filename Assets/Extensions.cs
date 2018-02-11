using UnityEngine;
using System.Collections;

public static class ExtensionMethods {
    public static Quaternion ToRotation(this Vector3 vector) {
        vector = vector.normalized;
        var directionAngle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg - 90;
        return Quaternion.Euler(0, 0, directionAngle);
    }

    public static Vector3 ToDirection(this Quaternion rotation) {
        return (rotation * Vector3.up).normalized;
    }
}