using UnityEngine;

public class WeaponChangingController : MonoBehaviour
{
    [Header("Values:")]
    [SerializeField]
    WeaponId weaponId = 0;

    private void Update()
    {
        CheckIfPlayerPressingChangeWeaponButton();
    }

    private void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weaponTransform in transform)
        {
            if (i == (int)weaponId)
            {
                weaponTransform.gameObject.SetActive(true);
            }
            else
            {
                weaponTransform.gameObject.SetActive(false);
            }

            i++;
        }
    }

    public void CheckIfPlayerPressingChangeWeaponButton()
    {
        WeaponId previousWeapon = weaponId;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if ((int)weaponId >= transform.childCount - 1)
            {
                weaponId = 0;
            }
            else
            {
                weaponId++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if ((int)weaponId <= 0)
            {
                weaponId = (WeaponId)transform.childCount - 1;
            }
            else
            {
                weaponId--;
            }
        }

        if (previousWeapon != weaponId)
        {
            SelectWeapon();
        }
    }

    public enum WeaponId
    {
        pistol = 0,
        shotgun = 1
    }
}
