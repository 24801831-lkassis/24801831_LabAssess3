using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 lastInput;
    private Vector2 currentInput;
    private Vector3 targetPosition;
    private bool isLerping = false;
    private float lerpTime = 0f;

    void Update()
    {
        GatherPlayerInput();

        if (!isLerping)
        {
            if (lastInput != Vector2.zero)
            {
                currentInput = lastInput;
                StartLerping(currentInput);
            }
            else
            {
                StartLerping(currentInput);
            }
        }
        else
        {
            LerpMovement();
        }
    }

    private void GatherPlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
            lastInput = Vector2.up;
        else if (Input.GetKey(KeyCode.A))
            lastInput = Vector2.left;
        else if (Input.GetKey(KeyCode.S))
            lastInput = Vector2.down;
        else if (Input.GetKey(KeyCode.D))
            lastInput = Vector2.right;
    }

    private void StartLerping(Vector2 direction)
    {
        targetPosition = (Vector2)transform.position + direction;
        isLerping = true;
        lerpTime = 0f;
    }

    private void LerpMovement()
    {
        lerpTime += Time.deltaTime * speed;

        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpTime);

        if ((Vector2)transform.position == (Vector2)targetPosition)
        {
            isLerping = false;
        }
    }
}
