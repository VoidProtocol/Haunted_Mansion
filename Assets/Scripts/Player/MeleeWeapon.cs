using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ShootingController))]
public class MeleeWeapon : Weapon
{
    [Header("Setup")]
    public Collider2D circleCollider;
    public Collider2D polygonCollider;
    public ContactFilter2D contactFilter;
    public Animator baseballSwingAnimation;
    public Animator slashAnimation;

    [Space]
    [Header("Weapon Config:")]
    public float delayBetweenAttacking = 1.0f;
    public float damage = 10.0f;

    private float _nextTimeToAttack = 0.0f;

    public override void Attack()
    {
        if (Time.time >= _nextTimeToAttack)
        {
            _nextTimeToAttack = Time.time + delayBetweenAttacking;

            baseballSwingAnimation.SetTrigger("Attack");
            slashAnimation.SetTrigger("Attack");

            List<Collider2D> elementsInCircleCollider = new List<Collider2D>();
            List<Collider2D> elementsInPolygonCollider = new List<Collider2D>();

            int numberOfElementsInCircleCollider = Physics2D.OverlapCollider(circleCollider, contactFilter, elementsInCircleCollider);
            int numberOfElementsInPolygonCollider = Physics2D.OverlapCollider(polygonCollider, contactFilter, elementsInPolygonCollider);

            if (numberOfElementsInCircleCollider > 0 && numberOfElementsInPolygonCollider > 0)
            {
                var ElementsInBothLists = elementsInCircleCollider.Intersect(elementsInPolygonCollider);

                foreach (var coll in ElementsInBothLists)
                {
                    Debug.Log(coll.name);
                    Debug.Log(damage);
                }
            }
        }
    }
}
