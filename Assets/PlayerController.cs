using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Controls:")]
    [SerializeField]
    float playerSpeed = 1;

    void Update()
    {
        PlayerMovement(playerSpeed);
    }

    private void PlayerMovement(float playerSpeed)
    {
        Vector3 horizontalMovement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        Vector3 verticalMovement = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);

        transform.position = transform.position + horizontalMovement * playerSpeed * Time.deltaTime;
        transform.position = transform.position + verticalMovement * playerSpeed *Time.deltaTime;
    }

}
