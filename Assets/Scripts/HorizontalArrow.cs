using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalArrow : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletFab;

    public float bulletForce = 11f;

    public float Firerate = 3;

    private float coolFire;

    // Update is called once per frame
    void Update()
    {

        if(Time.time > coolFire)
        {
            coolFire = Time.time + Firerate;

            Instantiate(bulletFab, firePoint.position, Quaternion.identity);
        }
    }
}