using UnityEngine;
public abstract class Weapon : MonoBehaviour
{
    public abstract void Attack();

    //protected void ShootBullet(GameObject bulletPrefab, Transform firePoint, float bulletSpreadDegrees, float bulletSpeed)
    //{
    //    float randomBulletSpreadDegree = Random.Range(-bulletSpreadDegrees, bulletSpreadDegrees);
    //    Vector3 randomShootingVector = Quaternion.AngleAxis(randomBulletSpreadDegree, Vector3.forward) * firePoint.right;

    //    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //    bullet.GetComponent<Rigidbody2D>().AddForce(randomShootingVector * bulletSpeed, ForceMode2D.Impulse);
    //}

    //protected void ShootBullet(GameObject bulletPrefab, Transform firePoint, float bulletSpreadDegrees, float bulletSpeed, int numberOfBullets)
    //{
    //    int numberOfBulletsOnOneSide = numberOfBullets / 2;
    //    float farLeftBulletAngleFromCenter = -bulletSpreadDegrees * numberOfBulletsOnOneSide;

    //    for (int i = 0; i < numberOfBullets; i++)
    //    {
    //        Vector3 randomShootingVector = Quaternion.AngleAxis(farLeftBulletAngleFromCenter, Vector3.forward) * firePoint.right;

    //        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //        bullet.GetComponent<Rigidbody2D>().AddForce(randomShootingVector * bulletSpeed, ForceMode2D.Impulse);

    //        farLeftBulletAngleFromCenter += bulletSpreadDegrees;
    //    }
    //}
}

