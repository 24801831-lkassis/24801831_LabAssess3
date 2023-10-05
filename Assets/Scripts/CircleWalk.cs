using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3[] waypoints;
    public float speed = 0.1f;
    private Transform spriteTransform;

    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints defined. Please specify waypoints in the Inspector.");
            return;
        }

        Vector3 targetPosition = waypoints[currentWaypointIndex];
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        }
    }
}
