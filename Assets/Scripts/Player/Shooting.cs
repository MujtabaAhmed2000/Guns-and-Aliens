using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float delay = .2f;
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
        if(Input.GetButton("Fire1")){
            if(delay < 0){
                shoot();
                shootingSound.Play();
                resetDelay();
            }
        }
    }

    void FixedUpdate(){
        delay -= Time.fixedDeltaTime;
    }

    public void shoot(){
        // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Bullet"); 
        if (bullet != null) {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
        }
    }

    void resetDelay(){
        delay = .2f;
    }
}
