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

    // Update is called once per frame
    void Update()
    { 
        // Vector responsible for player inpud (WASD), and converts that input into horizontal/vertical 3d vector with a nil value for the z-axis.
        UnityEngine.Vector3 PlayerMovement = UnityEngine.Quaternion.AngleAxis(45, UnityEngine.Vector3.forward) * new UnityEngine.Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        // Controls the velocity of the player.
        rb.velocity = PlayerMovement * speed;
    }

}
