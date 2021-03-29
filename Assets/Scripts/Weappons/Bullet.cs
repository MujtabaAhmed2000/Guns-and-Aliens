using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 7f;
    public int damage = 1;
    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Walls" || collider.gameObject.tag == "Floor"){
            Destroy(gameObject);
        }

        // Debug.Log(collider.gameObject.name);

        if(collider.gameObject.tag == "Enemy"){
            EnemyHealth enemy = collider.GetComponent<EnemyHealth>();
            
            // if(smallGrunt != null){
            //     smallGrunt.takeDamage(2);
            // }
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
