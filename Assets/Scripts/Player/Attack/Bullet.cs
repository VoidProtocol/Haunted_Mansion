using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private int _sceneryLayerIntegerValue;

    [Header("Bullet Config:")]
    [SerializeField] private float _bulletDamage = 1;
    [SerializeField] private bool _bulletPiercing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Debug.Log(_bulletDamage);

        if (_bulletPiercing)
        {
            if (collision.gameObject.layer == _sceneryLayerIntegerValue)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
