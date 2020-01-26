using UnityEngine;

public class Pistol : Weapon
{
    [Header("Setup")]
    public GameObject bulletprefab;
    public Transform firePoint;

    [Space]
    [Header("Weapon Config:")]
    public float delayBetweenShooting;
    public float bulletSpeed;
    public float bulletSpreadDegrees;

    private float _nextTimeToAttack = 0f;

    public override void Attack()
    {
        if (Time.time >= _nextTimeToAttack)
        {
            _nextTimeToAttack = Time.time + delayBetweenShooting;

            float randomBulletSpreadDegree = Random.Range(-bulletSpreadDegrees, bulletSpreadDegrees);
            Vector3 randomShootingVector = Quaternion.AngleAxis(randomBulletSpreadDegree, Vector3.forward) * firePoint.right;

            GameObject bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(randomShootingVector * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
