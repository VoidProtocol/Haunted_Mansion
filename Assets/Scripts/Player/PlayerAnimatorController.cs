using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [Header("Setup:")]
    public GameInput gameInput;
    public Animator animator;

    private Vector2 _movementValues;

    void Update()
    {
        _movementValues = gameInput.GetMovementValues();
        SetAnimatorValues();
    }

    private void SetAnimatorValues()
    {
        if (_movementValues != Vector2.zero)
        {
            animator.SetFloat("Horizontal", _movementValues.x);
            animator.SetFloat("Vertical", _movementValues.y);
        }

        animator.SetFloat("Speed", _movementValues.sqrMagnitude);
    }
}
