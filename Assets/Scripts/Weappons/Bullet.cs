using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] int damage = 1;
    Rigidbody2D rbody;

    // used onenable instead of start 
    void OnEnable()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Walls" || collider.gameObject.tag == "Floor"){
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }

        if(collider.gameObject.tag == "Enemy"){
            EnemyHealth enemy = collider.GetComponent<EnemyHealth>();

            enemy.takeDamage(damage);
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
