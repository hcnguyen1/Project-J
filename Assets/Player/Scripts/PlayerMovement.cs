using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 8f;   

    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    { 
        Vector3 PlayerMovement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        rb.velocity = PlayerMovement * speed;
    }

}
