using UnityEngine;

public class PlayerMovementConroller : MonoBehaviour
{
    [Header("Setup:")]
    public GameInput gameInput;
    public Rigidbody2D rb;

    [Header("Values:")]
    public Vector2 movementValues;

    [Header("Movement Config:")]
    public float playerSpeed = 1;

    void Update()
    {
        movementValues = gameInput.GetMovementValues();
    }

    void FixedUpdate()
    {
        PlayerMovement(playerSpeed);
    }

    private void PlayerMovement(float playerSpeed)
    {
        rb.MovePosition(rb.position + movementValues * playerSpeed * Time.fixedDeltaTime);
    }
}
