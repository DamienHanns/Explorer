using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Vector2 forwardDirection;
    float projectileSpeed = 10.0f;
    [SerializeField] int damage;

    Rigidbody2D myrb;
    [SerializeField ] float selfDestructTime;

    private void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", selfDestructTime);
    }


    void FixedUpdate () {
        myrb.velocity = (forwardDirection * (projectileSpeed * Time.fixedDeltaTime ));
	}

    public void SetForwardVecocity(Vector2 forwardDir, float moveSpeed)
    {
        forwardDirection = forwardDir;
        projectileSpeed = moveSpeed;
    }

    public void SetDamge(int projectileDamage)
    {
        damage = projectileDamage;
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Idamageable killableObject = other.transform.GetComponent<Idamageable>();

        if (killableObject != null)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                killableObject.TakeDamage(damage);
                DestroySelf();
            }
        }
        else
        {
            DestroySelf();
        }
    }


}
