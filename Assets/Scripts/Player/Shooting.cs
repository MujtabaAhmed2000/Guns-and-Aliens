using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    AudioSource shootingSound;

    void Start()
    {
        shootingSound = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            shoot();
            shootingSound.Play();
        }
    }

    void shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
