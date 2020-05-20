using UnityEngine;

[RequireComponent(typeof(ShootingController))]
public class MultipleBulletsWeapon : Weapon
{
    [Header("Setup")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    [Header("Weapon Config:")]
    [SerializeField] private float _delayBetweenAttacking = 1.0f;
    [SerializeField] private float _bulletSpeed = 8.0f;
    [SerializeField] private float _bulletSpreadDegrees = 10.0f; //in degrees
    [SerializeField] private int _numberOfBullets = 5; //always use odd number

    private float _nextTimeToAttack = 0.0f;

    //Create and shoot bullets in diffrient directions separated by specified spread degree
    public override void Attack()
    {
        int numberOfBulletsOnOneSide = _numberOfBullets / 2;
        float farLeftBulletAngleFromCenter = -_bulletSpreadDegrees * numberOfBulletsOnOneSide;

        if (Time.time >= _nextTimeToAttack)
        {
            _nextTimeToAttack = Time.time + _delayBetweenAttacking;

            for (int i = 0; i < _numberOfBullets; i++)
            {
                Vector3 nextShootingVector = Quaternion.AngleAxis(farLeftBulletAngleFromCenter, Vector3.forward) * _firePoint.right;

                GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(nextShootingVector * _bulletSpeed, ForceMode2D.Impulse);

                farLeftBulletAngleFromCenter += _bulletSpreadDegrees;
            }
        }
    }
}
