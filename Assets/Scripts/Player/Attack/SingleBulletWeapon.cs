using UnityEngine;

[RequireComponent(typeof(ShootingController))]
public class SingleBulletWeapon : Weapon
{
    [Header("Setup")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    [Header("Weapon Config:")]
    [SerializeField] private float _delayBetweenAttacking = 1.0f;
    [SerializeField] private float _bulletSpeed = 10.0f;
    [SerializeField] private float _bulletSpreadDegrees = 5.0f;

    private float _nextTimeToAttack = 0.0f;

    //Create and shoot bullet in random direction with specified max degree from center
    public override void Attack()
    {
        if (Time.time >= _nextTimeToAttack)
        {
            _nextTimeToAttack = Time.time + _delayBetweenAttacking;

            float randomBulletSpreadDegree = Random.Range(-_bulletSpreadDegrees, _bulletSpreadDegrees);
            Vector3 randomShootingVector = Quaternion.AngleAxis(randomBulletSpreadDegree, Vector3.forward) * _firePoint.right;

            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(randomShootingVector * _bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
