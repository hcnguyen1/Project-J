using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Entity stats
    [SerializeField] public float HP;
    [SerializeField] public float HPCapacity;
    [SerializeField] public float shield;
    [SerializeField] public float shieldCapacity;
    [SerializeField] public float attackPoints;
    [SerializeField] public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // add getter setter if necessary (such as public turning into private)
}
