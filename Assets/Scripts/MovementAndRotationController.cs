using UnityEngine;

public class MovementAndRotationController : MonoBehaviour
{
    [Header("Setup:")]
    public Rigidbody2D rb;
    public Camera cam;

    [Space]
    [Header("Values:")]
    public Vector2 keyboardValues;
    public Vector2 mousePosition;
    public Vector2 lookDirection;

    [Space]
    [Header("Movement Config:")]
    public float playerSpeed = 1;

    void Update()
    {
        CheckIfPlayerPressingMovementButtons();
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        PlayerMovement(playerSpeed);
        PlayerRotationAndAim();
    }

    private void CheckIfPlayerPressingMovementButtons()
    {
        keyboardValues.x = Input.GetAxisRaw("Horizontal");
        keyboardValues.y = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMovement(float playerSpeed)
    {
        rb.MovePosition(rb.position + keyboardValues * playerSpeed * Time.fixedDeltaTime);
    }

    private void PlayerRotationAndAim()
    {
        lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
