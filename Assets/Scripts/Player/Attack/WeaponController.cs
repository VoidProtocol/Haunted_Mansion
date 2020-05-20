using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private GameObject _baseballBat;
    [SerializeField] private GameObject _pistol;
    [SerializeField] private GameObject _tommyGun;
    [SerializeField] private GameObject _shotgun;
    [SerializeField] private GameObject _magnum;
    [SerializeField] private GameObject _crosshair;

    [Header("Values:")]
    [SerializeField] private WeaponId _weaponId = 0;

    private int _numberOfWeapons = System.Enum.GetNames(typeof(WeaponId)).Length;
    private GameObject _currentWeapon;

    public WeaponId GetWeaponId { get { return _weaponId; } }

    private void Awake()
    {
        _currentWeapon = _baseballBat;
        SelectWeapon();
    }

    private void Update()
    {
        SwitchWeapon();
        AimWeapon();
        EnableCrosshair();
    }

    private void FixedUpdate()
    {
        ShootWeapon();
    }

    private void ShootWeapon()
    {
        if (_gameInput.GetFireButtonPressed)
        {
            _currentWeapon.GetComponent<ShootingController>().weapon.Attack();
        }
    }

    private void SelectWeapon()
    {
        _currentWeapon.SetActive(false);

        switch (_weaponId)
        {
            case WeaponId.baseballBat:
                _baseballBat.SetActive(true);
                _currentWeapon = _baseballBat;
                break;
            case WeaponId.pistol:
                _pistol.SetActive(true);
                _currentWeapon = _pistol;
                break;
            case WeaponId.tommyGun:
                _tommyGun.SetActive(true);
                _currentWeapon = _tommyGun;
                break;
            case WeaponId.shotgun:
                _shotgun.SetActive(true);
                _currentWeapon = _shotgun;
                break;
            case WeaponId.magnum:
                _magnum.SetActive(true);
                _currentWeapon = _magnum;
                break;
            default:
                Debug.LogError("Selected weapon index out of range.");
                break;
        }
    }

    private void SwitchWeapon()
    {
        int previousWeapon = (int)_weaponId;

        if (_gameInput.GetSwitchWeaponValue > 0f)
        {
            if ((int)_weaponId >= _numberOfWeapons - 1)
            {
                _weaponId = 0;
            }
            else
            {
                _weaponId++;
            }
        }

        if (_gameInput.GetSwitchWeaponValue < 0f)
        {
            if (_weaponId <= 0)
            {
                _weaponId = (WeaponId)_numberOfWeapons - 1;
            }
            else
            {
                _weaponId--;
            }
        }

        if (previousWeapon != (int)_weaponId)
        {
            SelectWeapon();
        }
    }

    private void AimWeapon()
    {
        //Without this if statement weapon will always turn 90 degrees
        if (_gameInput.GetAimDirection != Vector2.zero)
        {
            float weaponRotationAngle = Mathf.Atan2(_gameInput.GetAimDirection.y, _gameInput.GetAimDirection.x) * Mathf.Rad2Deg + 90.0f;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, weaponRotationAngle);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void EnableCrosshair()
    {
        if (_weaponId != WeaponId.baseballBat && _gameInput.GetFireButtonPressed)
        {
            _crosshair.SetActive(true);
        }
        else
        {
            _crosshair.SetActive(false);
        }
    }

    public enum WeaponId
    {
        baseballBat = 0,
        pistol = 1,
        tommyGun = 2,
        shotgun = 3,
        magnum = 4
    }
}
