using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Setup:")]
    public GameInput gameInput;
    public GameObject baseballBat;
    public GameObject pistol;
    public GameObject tommyGun;
    public GameObject shotgun;
    public GameObject magnum;
    public GameObject crosshair;

    [Header("Values:")]
    [SerializeField]
    WeaponId weaponId = 0;

    private int _numberOfWeapons = 5;
    private float _switchWeaponValue;
    private bool _fireButtonPressed;
    private GameObject _currentWeapon;

    private void Awake()
    {
        _currentWeapon = baseballBat;
    }

    private void Update()
    {
        _switchWeaponValue = gameInput.GetSwitchWeaponValue();
        _fireButtonPressed = gameInput.IsFireButtonPressed();
        SwitchWeapon();
        CrosshairAim();
    }

    private void FixedUpdate()
    {
        ShootWeapon();
    }

    private void ShootWeapon()
    {
        if (_fireButtonPressed)
        {
            _currentWeapon.GetComponent<ShootingController>().weapon.Attack();
        }
    }

    private void SelectWeapon()
    {
        _currentWeapon.SetActive(false);

        switch (weaponId)
        {
            case WeaponId.baseballBat:
                baseballBat.SetActive(true);
                _currentWeapon = baseballBat;
                break;
            case WeaponId.pistol:
                pistol.SetActive(true);
                _currentWeapon = pistol;
                break;
            case WeaponId.tommyGun:
                tommyGun.SetActive(true);
                _currentWeapon = tommyGun;
                break;
            case WeaponId.shotgun:
                shotgun.SetActive(true);
                _currentWeapon = shotgun;
                break;
            case WeaponId.magnum:
                magnum.SetActive(true);
                _currentWeapon = magnum;
                break;
            default:
                Debug.LogError("Selected weapon index out of range.");
                break;
        }
    }

    public void SwitchWeapon()
    {
        int previousWeapon = (int)weaponId;

        if (_switchWeaponValue > 0f)
        {
            if ((int)weaponId >= _numberOfWeapons - 1)
            {
                weaponId = 0;
            }
            else
            {
                weaponId++;
            }
        }

        if (_switchWeaponValue < 0f)
        {
            if (weaponId <= 0)
            {
                weaponId = (WeaponId)_numberOfWeapons - 1;
            }
            else
            {
                weaponId--;
            }
        }

        if (previousWeapon != (int)weaponId)
        {
            SelectWeapon();
        }
    }

    public void CrosshairAim()
    {
        if (_fireButtonPressed && weaponId != WeaponId.baseballBat)
        {
            crosshair.SetActive(true);
        }
        else
        {
            crosshair.SetActive(false);
        }
    }

    enum WeaponId
    {
        baseballBat = 0,
        pistol = 1,
        tommyGun = 2,
        shotgun = 3,
        magnum = 4
    }
}
