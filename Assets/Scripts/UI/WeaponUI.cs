using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _baseballBatUI;
    [SerializeField] private GameObject _pistolUI;
    [SerializeField] private GameObject _tommyGunUI;
    [SerializeField] private GameObject _shotgunUI;
    [SerializeField] private GameObject _magnumUI;
    [SerializeField] private WeaponController _weaponController;

    private GameObject _currentWeaponUI;

    private void Awake()
    {
        _currentWeaponUI = _baseballBatUI;
    }

    void Update()
    {
        SelectWeaponUI();
    }

    private void SelectWeaponUI()
    {
        _currentWeaponUI.SetActive(false);

        switch (_weaponController.GetWeaponId)
        {
            case WeaponController.WeaponId.baseballBat:
                _baseballBatUI.SetActive(true);
                _currentWeaponUI = _baseballBatUI;
                break;
            case WeaponController.WeaponId.pistol:
                _pistolUI.SetActive(true);
                _currentWeaponUI = _pistolUI;
                break;
            case WeaponController.WeaponId.tommyGun:
                _tommyGunUI.SetActive(true);
                _currentWeaponUI = _tommyGunUI;
                break;
            case WeaponController.WeaponId.shotgun:
                _shotgunUI.SetActive(true);
                _currentWeaponUI = _shotgunUI;
                break;
            case WeaponController.WeaponId.magnum:
                _magnumUI.SetActive(true);
                _currentWeaponUI = _magnumUI;
                break;
            default:
                Debug.LogError("Selected weapon index out of range.");
                break;
        }
    }
}
