using UnityEngine;

[RequireComponent(typeof(ShootingController))]
public class MultipleBulletsWeapon : Weapon
{
    [Header("Setup")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Space]
    [Header("Weapon Config:")]
    public float delayBetweenAttacking = 1.0f;
    public float bulletSpeed = 8.0f;
    public float bulletSpreadDegrees = 10.0f; //in degrees
    public int numberOfBullets = 5; //always use odd number

    private float _nextTimeToAttack = 0.0f;

    public override void Attack()
    {
        int numberOfBulletsOnOneSide = numberOfBullets / 2;
        float farLeftBulletAngleFromCenter = -bulletSpreadDegrees * numberOfBulletsOnOneSide;

        if (Time.time >= _nextTimeToAttack)
        {
            _nextTimeToAttack = Time.time + delayBetweenAttacking;

            for (int i = 0; i < numberOfBullets; i++)
            {
                Vector3 randomShootingVector = Quaternion.AngleAxis(farLeftBulletAngleFromCenter, Vector3.forward) * firePoint.right;

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(randomShootingVector * bulletSpeed, ForceMode2D.Impulse);

                farLeftBulletAngleFromCenter += bulletSpreadDegrees;
            }
        }
    }
}
