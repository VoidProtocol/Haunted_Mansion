using UnityEngine;
public class GameInputPC : MonoBehaviour, IGameInput
{
    [Header("Setup:")]
    [SerializeField] private Transform _weaponPosition;
    [SerializeField] private Camera _camera;

    private Vector2 _movementValues;
    private Vector2 _aimDirection;
    private float _switchWeaponValue;
    private bool _fireButtonPressed;

    public Vector2 GetMovementValues { get { return _movementValues; } }
    public Vector2 GetAimDirection { get { return _aimDirection; } }
    public float GetSwitchWeaponValue { get { return _switchWeaponValue; } }
    public bool GetFireButtonPressed { get { return _fireButtonPressed; } }

    void Update()
    {
        SetMovementValues();
        SetAimDirection();
        SetSwitchWeaponValue();
        SetFireButtonPressed();
    }

    private void SetMovementValues()
    {
        _movementValues = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_movementValues.magnitude > 1.0f)
        {
            _movementValues.Normalize();
        }
    }

    private void SetAimDirection()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _aimDirection = new Vector3(mousePosition.x, mousePosition.y) - _weaponPosition.position;
    }

    private void SetSwitchWeaponValue()
    {
        _switchWeaponValue = Input.GetAxis("Mouse ScrollWheel");
    }

    private void SetFireButtonPressed()
    {
        _fireButtonPressed = Input.GetButton("Fire1");
    }
}