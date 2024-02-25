using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : Entity
{

    // The player
    [SerializeField] private Rigidbody2D rb;

    // Dash Variables
    private float activeMoveSpeed;
    public float dashSpeed = 60f;

    public float dashLength = .1f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private float iFramesCurrent;
    private float invincibilityDuration = .1f;

    // Might be redundant to have enums..
    DashState isDashing;

    // End of Dash Variables

    void Start()
    {
        // Dash
        activeMoveSpeed = moveSpeed;
        iFramesCurrent = 0;
        isDashing = DashState.Ready;
    }


    // Update is called once per frame
    void Update()
    { 
        moveCheck();
        dashCheck();
    }

    private void moveCheck() {
        // Vector responsible for player inpud (WASD), and converts that input into horizontal/vertical 3d vector with a nil value for the z-axis.
        // UnityEngine.Vector3 PlayerMovement = UnityEngine.Quaternion.AngleAxis(45, UnityEngine.Vector3.forward) * new UnityEngine.Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        UnityEngine.Vector3 PlayerMovement = new UnityEngine.Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        // Controls the velocity of the player.
        rb.velocity = PlayerMovement * activeMoveSpeed;
    }

    // Dash Function
    private void dashCheck() {
        // Dash Checks
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                isDashing = DashState.Dashing;
                iFramesCurrent = invincibilityDuration;
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                isDashing = DashState.Cooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            isDashing = DashState.Ready;
        }

        if(iFramesCurrent > 0)
        {
            iFramesCurrent -= Time.deltaTime;
        }
        // End of Dash Checks
    }

}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}