using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public enum RotationMode { Positive, Negative }
    public RotationMode rotationMode;

    private float rotationDuration = 1f;
    private float nextRotationTime;

    private float initialDelay = 2f;

    private void Start()
    {
        nextRotationTime = Time.time + initialDelay;
    }

    private void Update()
    {
        if (Time.time >= nextRotationTime)
        {
            RotateByRandomAngle();
            nextRotationTime = Time.time + rotationDuration;
        }
    }

    private void RotateByRandomAngle()
    {
        float randomAngle = Random.Range(40f, 180f);
        if (rotationMode == RotationMode.Negative)
        {
            randomAngle *= -1;
        }

        Vector3 currentEulerAngles = transform.eulerAngles;
        currentEulerAngles.z += randomAngle;
        transform.eulerAngles = currentEulerAngles;
    }
}
