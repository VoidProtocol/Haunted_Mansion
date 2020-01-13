using System.Collections;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Header("Setup:")]
    public Weapon weapon;

    void Update()
    {
        CheckIfPlayerPressingShootingButton();
    }

    private void CheckIfPlayerPressingShootingButton()
    {
        if (Input.GetButton("Fire1"))
        {
            weapon.Attack();
        }
    }
}
