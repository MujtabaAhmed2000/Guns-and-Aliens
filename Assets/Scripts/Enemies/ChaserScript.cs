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
    Vector3 chaserOffsetPosition;
    float offset = 0.5f;
    GameObject gold;
    Transform goldTransform;
    float jumpCooldown = 1f;

    // ASTAR STUFF
    float nextWaypointDist = 0.1f;
    Path path;
    int currentWaypoint = 0;
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
            Invoke("getGoldLocation", 3f);
        }
        // if carrying gold or gold is null(gameobject destroyed)), set goldinsight to false
        carryingGold = info.getCarryingGold();
        if(carryingGold || gold == null){
            goldInSight = false;
        }

        // if gold in sight, move towards the gold, otherwise follow normal path
        if(goldInSight){
            if(path == null){
                return;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint + 1] - (Vector2)path.vectorPath[currentWaypoint]).normalized;

            if(direction.x > 0){
                movement.moveRight();
            }
            if(direction.x < 0){
                movement.moveLeft();
            }
            if(direction.y > 0.5){
                if(jumpCooldown <= 0.0f){
                    Invoke("jump", 0.3f);
                    resetJumpCooldown();
                }
            }

            float distance = Vector2.Distance((Vector2)getChaserOffsetPosition(), path.vectorPath[currentWaypoint]);

            if(distance < nextWaypointDist){
                if(!(currentWaypoint + 1 == path.vectorPath.Count)){
                    currentWaypoint++;
                }
            }
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
            goldTransform = gold.GetComponent<Transform>();
            InvokeRepeating("updatePath", 0f, 2f);
        }
    }

    void updatePath(){
        if(gold != null){
            seeker.StartPath(getChaserOffsetPosition(), goldTransform.position, OnPathComplete);
        }
    }

    Vector3 getChaserOffsetPosition(){
        chaserOffsetPosition = transform.position;
        chaserOffsetPosition.y += offset;
        return chaserOffsetPosition;
    }

    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0; 
        }
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
