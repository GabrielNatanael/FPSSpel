using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponState
{
    Unarmed,
    Hitscan,
    Projectile,
    Total
}
public class PlayerMovement : MonoBehaviour
{
    public List<Weapon> allHeldWeapons = new List<Weapon>();

    public Weapon currentWeapon = null;

    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.82f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] float jumpForce = 3f;
    [SerializeField] float scrollWeaponSwapBreakpoint = 1f;

    [SerializeField] CharacterController controller;

    private Vector3 velocity;
    private bool isGrounded;
    private float mouseAxisDelta = 0f;
    private WeaponState currentWeaponPointer = WeaponState.Unarmed;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);

        if( isGrounded && velocity.y < 0 )
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        mouseAxisDelta += Input.mouseScrollDelta.y;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Mathf.Abs(mouseAxisDelta) > scrollWeaponSwapBreakpoint)
        {
            
        }
        if(currentWeaponPointer == WeaponState.Unarmed)
        {

        }
    }

    public void FireHeldWeapon()
    {
        if(currentWeapon != null)
        {
            currentWeapon.Fire();
        }
    }
}
