using UnityEngine;

public class MovementAndRotationController : MonoBehaviour
{
    [Header("Setup:")]
    public Rigidbody2D rb;
    public Animator animator;
    //public Camera cam;

    [Header("Values:")]
    public Vector2 movementValues;
    //public Vector2 mousePosition;
    //public Vector2 lookDirection;

    [Header("Movement Config:")]
    public float playerSpeed;

    void Update()
    {
        GetMovementValues();
        SetAnimatorValues();
        //mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        PlayerMovement(playerSpeed);
        //PlayerRotationAndAim();
    }

    private void GetMovementValues()
    {
        movementValues = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movementValues.magnitude > 1.0f)
        {
            movementValues.Normalize();
        }
    }

    private void PlayerMovement(float playerSpeed)
    {
        rb.MovePosition(rb.position + movementValues * playerSpeed * Time.fixedDeltaTime);
    }

    private void SetAnimatorValues()
    {
        animator.SetFloat("Horizontal", movementValues.x);
        animator.SetFloat("Vertical", movementValues.y);
        animator.SetFloat("Magnitude", movementValues.magnitude);
    }

    //private void PlayerRotationAndAim()
    //{
    //    lookDirection = mousePosition - rb.position;
    //    float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
    //    rb.rotation = angle;
    //}
}
