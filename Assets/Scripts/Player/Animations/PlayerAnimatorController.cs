using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Animator PlayerMovementAnimator;

    void Update()
    {
        SetAnimatorMovementValues();
    }

    private void SetAnimatorMovementValues()
    {
        if (gameInput.GetMovementValues != Vector2.zero)
        {
            PlayerMovementAnimator.SetFloat("Horizontal", gameInput.GetMovementValues.x);
            PlayerMovementAnimator.SetFloat("Vertical", gameInput.GetMovementValues.y);
        }

        PlayerMovementAnimator.SetFloat("Speed", gameInput.GetMovementValues.sqrMagnitude);
    }
}
