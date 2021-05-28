using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChaserScript : MonoBehaviour
{
    ChaserMovement movement;
    EnemyInfo info;
    [SerializeField] bool goldInSight = false;
    [SerializeField] bool carryingGold = false;
    GameObject gold;
    public float speed = 200f;
    float jumpCooldown = 1f;
    float jumpDelay = 0.5f;
    int goldLocationLevel;

    // public float speed = 200f;

    // ASTAR STUFF
    float nextWaypointDist = 3f;
    Path path;
    int currentWaypoint = 1;
    bool readhedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        movement = gameObject.GetComponent<ChaserMovement>();
        info = gameObject.GetComponent<EnemyInfo>();
        seeker = gameObject.GetComponent<Seeker>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        jumpCooldown -= Time.fixedDeltaTime;

        // Only find a new gold location when the currently pursued gold dissapears
        if(!goldInSight && !carryingGold){
            // getGoldLocation();
            Invoke("getGoldLocation", 3f);
        }
        // if carrying gold or gold is null(gameobject destroyed)), set goldinsight to false
        carryingGold = info.getCarryingGold();
        if(carryingGold || gold == null){
            goldInSight = false;
        }


        // if gold in sight, move towards the gold, otherwise follow normal path
        if(goldInSight){
            // seeker.StartPath(transform.position, getGoldTransform().position, OnPathComplete);
            if(path == null){
                return;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

            if(direction.x > 0){
                // Debug.Log("MOVE RIGHT");
                movement.moveRight();
            }
            if(direction.x < 0){
                // Debug.Log("MOVE LEFT");
                movement.moveLeft();
            }
            if(direction.y > 0.5){
                if(jumpCooldown <= 0.0f){
                    // Task.Delay(1000).ContinueWith(t=> movement.jump());
                    Invoke("jump", 0.3f);
                    // movement.jump();
                    resetJumpCooldown();
                }
            }
            
            Vector2 force = direction * speed * Time.deltaTime;

            // rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);


            if(distance < nextWaypointDist){
                if(currentWaypoint + 1 == path.vectorPath.Count){
                    currentWaypoint = currentWaypoint;
                }
                else{
                    currentWaypoint++;
                }
            }

            // if(direction.y > 0){
            //     movement.moveRight();
            // }
            // if(direction.y < 0){
            //     movement.moveLeft();
            // }

        }
        else{
            movement.move();
        }
    }

    void jump(){
        movement.jump();
    }

    void resetJumpCooldown(){
        jumpCooldown = 1f;
    }

    void getGoldLocation(){
        gold = GameObject.FindGameObjectWithTag("Gold");
        if(gold == null){
            goldInSight = false;
        }
        else{
            goldInSight = true;

            // Transform t = getGoldTransform();
            // Vector3 pos = t.position;
            
            // if(pos.y == 8){
            //     goldLocationLevel = 5;
            // }
            // else if(pos.y == 6){
            //     goldLocationLevel = 4;
            // }
            // else if(pos.y == 6){
            //     goldLocationLevel = 3;
            // }
            // else if(pos.y == 6){
            //     goldLocationLevel = 2;
            // }
            // else if(pos.y == 2){
            //     goldLocationLevel = 1;
            // }
            // else if(pos.y == 0){
            //     goldLocationLevel = 0;
            // }

            InvokeRepeating("updatePath", 0f, 1.5f);
            // seeker.StartPath(transform.position, t.position, OnPathComplete);
        }
    }

    void updatePath(){
        Transform t = getGoldTransform();
        seeker.StartPath(transform.position, t.position, OnPathComplete);
    }

    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 1; 
        }
    }

    Transform getGoldTransform(){
        return gold.GetComponent<Transform>();
    }

    float getGoldTransformX(){
        Transform transform = gold.GetComponent<Transform>();
        return transform.position.x;
    }

    float getGoldTransformY(){
        Transform transform = gold.GetComponent<Transform>();
        return transform.position.y;
    }

}
