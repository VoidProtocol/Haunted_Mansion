using UnityEngine;

[RequireComponent(typeof(ShootingController))]
public class SingleBulletWeapon : Weapon
{
    [Header("Setup")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Space]
    [Header("Weapon Config:")]
    public float delayBetweenAttacking = 1.0f;
    public float bulletSpeed = 10.0f;
    public float bulletSpreadDegrees = 5.0f;

    private float _nextTimeToAttack = 0.0f;

    public override void Attack()
    {
        if (Time.time >= _nextTimeToAttack)
        {
            _nextTimeToAttack = Time.time + delayBetweenAttacking;

            float randomBulletSpreadDegree = Random.Range(-bulletSpreadDegrees, bulletSpreadDegrees);
            Vector3 randomShootingVector = Quaternion.AngleAxis(randomBulletSpreadDegree, Vector3.forward) * firePoint.right;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(randomShootingVector * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
