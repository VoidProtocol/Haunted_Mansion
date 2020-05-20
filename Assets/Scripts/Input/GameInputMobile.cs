using UnityEngine;

public class GameInputMobile : MonoBehaviour, IGameInput
{
    [Header("Setup:")]
    [SerializeField] private Joystick _movementJoystick;
    [SerializeField] private Joystick _attackJoystick;

    private Vector2 _movementValues;
    private Vector2 _aimDirection;
    private float _switchWeaponValue;
    private bool _fireButtonPressed;
    private bool _nextButtonPressed = false;
    private bool _previousButtonPressed = false;

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
        _movementValues = new Vector2(_movementJoystick.Horizontal, _movementJoystick.Vertical);

        //Values are already normalised in Joystick class
    }

    private void SetAimDirection()
    {
        _aimDirection = _attackJoystick.Direction;
    }

    private void SetFireButtonPressed()
    {
        _fireButtonPressed = false;
        Vector2 aimValues = new Vector2(_attackJoystick.Horizontal, _attackJoystick.Vertical);

        if (aimValues != Vector2.zero)
        {
            _fireButtonPressed = true;
        }
    }

    private void SetSwitchWeaponValue()
    {
        _switchWeaponValue = 0.0f;

        if (_nextButtonPressed)
        {
            _nextButtonPressed = false;
            _switchWeaponValue = 1.0f;
        }

        if (_previousButtonPressed)
        {
            _previousButtonPressed = false;
            _switchWeaponValue = -1.0f;
        }
    }

    private void NextButtonPressed()
    {
        _nextButtonPressed = true;
    }

    private void PreviousButtonPressed()
    {
        _previousButtonPressed = true;
    }
}