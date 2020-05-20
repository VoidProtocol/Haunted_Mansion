using UnityEngine;

public interface IGameInput
{
    Vector2 GetMovementValues { get; }
    Vector2 GetAimDirection { get; }
    float GetSwitchWeaponValue { get; }
    bool GetFireButtonPressed { get; }
}
