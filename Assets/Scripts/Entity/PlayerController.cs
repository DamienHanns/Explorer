using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent (typeof (Rigidbody2D), typeof (Input))]
[RequireComponent (typeof (CircleCollider2D), typeof (WeaponController))]
public class PlayerController : KillableEntity {

    [SerializeField] float moveSpeed = 100.0f;
    WeaponController weaponController;
    Rigidbody2D myrb;

	void Start ()
    {
        myrb = GetComponent<Rigidbody2D>();
        weaponController = GetComponent<WeaponController>();
	}


    public void Move(Vector2 movementDirection)
    {
        Vector2 velocity = (movementDirection * moveSpeed) * Time.fixedDeltaTime;
        myrb.velocity = velocity;
    }

    public void Turn(Vector3 positionToTurnTo)
    {
        float AngleRad = Mathf.Atan2(positionToTurnTo.y - transform.position.y, positionToTurnTo.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        myrb.rotation = (angle - 90.0f) ;
    }

    public void UseWeapon()
    {
        weaponController.UseWeapon();
    }
}
