using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public Vector2 GetMovementValues()
    {
        Vector2 movementValues = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movementValues.magnitude > 1.0f)
        {
            movementValues.Normalize();
        }

        return movementValues;
    }

    public float GetSwitchWeaponValue()
    {
        float switchWeaponValue = Input.GetAxis("Mouse ScrollWheel");
        return switchWeaponValue;
    }

    public bool IsFireButtonPressed()
    {
        bool FireButtonPressed = Input.GetButton("Fire1");
        return FireButtonPressed;
    }


}
