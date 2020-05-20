using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ShootingController))]
public class MeleeWeapon : Weapon
{
    [Header("Setup")]
    [SerializeField] private Collider2D _circleCollider;
    [SerializeField] private Collider2D _polygonCollider;
    [SerializeField] private Animator _baseballAnimation;
    [SerializeField] private Animator _swingAnimation;
    [SerializeField] private ContactFilter2D _contactFilter;

    [Header("Weapon Config:")]
    [SerializeField] private float _delayBetweenAttacking = 1.0f;
    [SerializeField] private float _damage = 2.0f;

    private float _nextTimeToAttack = 0.0f;

    //Check for enemies in both polygon and circle collider to create pie slice area of range
    public override void Attack()
    {
        if (Time.time >= _nextTimeToAttack)
        {
            _nextTimeToAttack = Time.time + _delayBetweenAttacking;

            //Temp animation resolution
            _baseballAnimation.SetTrigger("Attack");
            _swingAnimation.SetTrigger("Attack");

            List<Collider2D> elementsInCircleCollider = new List<Collider2D>();
            List<Collider2D> elementsInPolygonCollider = new List<Collider2D>();

            int numberOfElementsInCircleCollider = Physics2D.OverlapCollider(_circleCollider, _contactFilter, elementsInCircleCollider);
            int numberOfElementsInPolygonCollider = Physics2D.OverlapCollider(_polygonCollider, _contactFilter, elementsInPolygonCollider);

            if (numberOfElementsInCircleCollider > 0 && numberOfElementsInPolygonCollider > 0)
            {
                var ElementsInBothLists = elementsInCircleCollider.Intersect(elementsInPolygonCollider);

                foreach (var coll in ElementsInBothLists)
                {
                    Debug.Log(coll.name);
                    Debug.Log(_damage);
                }
            }
        }
    }
}
