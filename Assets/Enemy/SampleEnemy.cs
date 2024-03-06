using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SampleEnemy : Entity
{

    
    public Transform playerTransform; // Assign the player's transform in the Inspector

    private void Start()
    {
        moveSpeed = 3f;
    }
    private void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = playerTransform.position - transform.position;

        // Normalize the direction to get a direction vector with a length of 1
        direction.Normalize();

        // Move the enemy towards the player
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}