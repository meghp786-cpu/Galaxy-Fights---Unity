using UnityEngine;
using UnityEngine.InputSystem;

//using UnityEngine.UIElements;
public class Movement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;
    [SerializeField] float rollingFactor = 10f;
    [SerializeField] float pitchFactor = 10f;
    [SerializeField] float rotationSpeed = 10f;

    Vector2 movement;

    private void Update()
    {
        ProcessTranslation();
        ProcessRolling();
    }

    private void ProcessTranslation()
    {
        // Calculate how much we WANT to move this frame
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;

        // Calculate the new potential positions
        float xRaw = transform.localPosition.x + xOffset;
        float yRaw = transform.localPosition.y + yOffset;

        // Clamp them so the rocket doesn't fly off-screen
        float xFinal = Mathf.Clamp(xRaw , -xRange , xRange);
        float yFinal = Mathf.Clamp(yRaw, -yRange, yRange);

        // Apply the position, keeping Z exactly where it started (or at 0)
        transform.localPosition = new Vector3(xFinal, yFinal, 0f);
    }

    private void ProcessRolling()
    {
        Quaternion targetRotation = Quaternion.Euler(-pitchFactor * movement.y, 0f, - rollingFactor * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation , targetRotation , rotationSpeed * Time.deltaTime);
    }

    private void OnMove (InputValue value)
    {
        //Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }
}
