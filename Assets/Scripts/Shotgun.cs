using UnityEngine;

public class Shotgun : Weapon
{
    [Header("Setup")]
    public GameObject bulletprefab;
    public Transform firePoint;

    [Space]
    [Header("Weapon Config:")]
    public float delayBetweenShooting;
    public float bulletSpeed;
    public float bulletSpreadDegrees; //in degrees
    public int numberOfBullets; //always use odd number

    private float _nextTimeToAttack = 0f;

    public override void Attack()
    {
        int numberOfBulletsOnOneSide = numberOfBullets / 2;
        float farLeftBulletAngleFromCenter = -bulletSpreadDegrees * numberOfBulletsOnOneSide;

        if (Time.time >= _nextTimeToAttack)
        {
            _nextTimeToAttack = Time.time + delayBetweenShooting;

            for (int i = 0; i < numberOfBullets; i++)
            {
                Vector3 randomShootingVector = Quaternion.AngleAxis(farLeftBulletAngleFromCenter, Vector3.forward) * firePoint.right;

                GameObject bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(randomShootingVector * bulletSpeed, ForceMode2D.Impulse);

                farLeftBulletAngleFromCenter += bulletSpreadDegrees;
            }
        }
    }
}
