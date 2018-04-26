using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (PlayerController))]
public class PlayerInput : MonoBehaviour {

    PlayerController playerController;
    
	void Start () {
        playerController = GetComponent<PlayerController>();
	}
    
    void Update()
    {
        //Direction Input
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        playerController.Move(moveDir);

        //turning input
        float camDis = Camera.main.transform.position.y - transform.position.y;             //TODO test is camDis does anything.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        playerController.Turn(mousePos);

        //check for firing input
        if (Input.GetButton("Fire1")) { playerController.UseWeapon(); }
    }
}
