using UnityEngine;

public class PlayerMovementConroller : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private Rigidbody2D _rb;

    [Header("Movement Config:")]
    [SerializeField] private float _playerSpeed = 1;

    void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        _rb.MovePosition(_rb.position + _gameInput.GetMovementValues * _playerSpeed * Time.fixedDeltaTime);
    }
}
