using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harrow : MonoBehaviour
{
    private Rigidbody2D rb; 
    public float bulletForce = 11f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
