using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public Vector2 moveSpeed = new Vector2(3f, 0);
    public Vector2 knockback = new Vector2(0, 0);
    private float timeToDestroy;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    private void FixedUpdate()
    {
        timeToDestroy += Time.deltaTime;

        if (timeToDestroy >= 5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            Vector2 deliverKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            damageable.Hit(damage, deliverKnockback);

            Destroy(gameObject);
        }
    }
}
