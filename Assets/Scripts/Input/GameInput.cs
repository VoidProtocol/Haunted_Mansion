using UnityEngine;

public class GameInput : MonoBehaviour, IGameInput
{
    [Header("Setup:")]
    [SerializeField] private GameInputMobile _gameInputMobile;
    [SerializeField] private GameInputPC _gameInputPC;
    [SerializeField] private GameObject _movementJoystick;
    [SerializeField] private GameObject _attackJoystick;
    [SerializeField] private GameObject _nextWeaponButton;
    [SerializeField] private GameObject _previousWeaponButton;

    [Header("Input Config:")]
    [SerializeField] private InputDevice _inputDevice = 0;

    private IGameInput _currentInputInstance;

    public Vector2 GetMovementValues { get { return _currentInputInstance.GetMovementValues; } }
    public Vector2 GetAimDirection { get { return _currentInputInstance.GetAimDirection; } }
    public float GetSwitchWeaponValue { get { return _currentInputInstance.GetSwitchWeaponValue; } }
    public bool GetFireButtonPressed { get { return _currentInputInstance.GetFireButtonPressed; } }

    void Awake()
    {
        switch (_inputDevice)
        {
            case InputDevice.Mobile:
                _currentInputInstance = _gameInputMobile;
                break;
            case InputDevice.PC:
                _currentInputInstance = _gameInputPC;
                _movementJoystick.SetActive(false);
                _attackJoystick.SetActive(false);
                _nextWeaponButton.SetActive(false);
                _previousWeaponButton.SetActive(false);
                break;
            default:
                Debug.LogError("Selected input index out of range.");
                break;
        }
    }

    private enum InputDevice
    {
        Mobile = 0,
        PC = 1
    }
}
