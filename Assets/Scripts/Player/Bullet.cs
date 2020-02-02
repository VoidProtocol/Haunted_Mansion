using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Setup:")]
    public int sceneryLayerIntegerValue;

    [Header("Bullet Config:")]
    public float bulletDamage;
    public bool bulletPiercing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if (bulletPiercing)
        {
            if (collision.gameObject.layer == sceneryLayerIntegerValue)
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
