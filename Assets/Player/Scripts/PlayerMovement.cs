using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Controls player movement speed (Multiplies velocity by 8).
    private float speed = 8f;  

    // The player
    [SerializeField] private Rigidbody2D rb;

    // Dash Variables
    private float activeMoveSpeed;
    public float dashSpeed = 60f;

    public float dashLength = .1f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    // End of Dash Variables

    void Start()
    {
        activeMoveSpeed = speed;
    }


    // Update is called once per frame
    void Update()
    { 
        // Vector responsible for player inpud (WASD), and converts that input into horizontal/vertical 3d vector with a nil value for the z-axis.
        // UnityEngine.Vector3 PlayerMovement = UnityEngine.Quaternion.AngleAxis(45, UnityEngine.Vector3.forward) * new UnityEngine.Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        UnityEngine.Vector3 PlayerMovement = new UnityEngine.Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        // Controls the velocity of the player.
        rb.velocity = PlayerMovement * activeMoveSpeed;

        // Dash Checks
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        // End of Dash Checks
    }

}
