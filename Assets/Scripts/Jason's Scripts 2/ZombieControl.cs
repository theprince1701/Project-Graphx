using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : MonoBehaviour {
    Rigidbody body;
    float moveSpeed = 3.0f;
    [SerializeField] GameObject target;
    [SerializeField] GameTracker manager;

    Vector3 targetDirection;
    bool calculatedThisFrame = false;

    void Awake(){
        body = this.GetComponent<Rigidbody>();

    }

    void FixedUpdate(){
        if(manager.CheckGameActive() == false){
            Die();
        }
        
        FindTargetDirection();
        Move();
    }
    void LateUpdate(){
        calculatedThisFrame = false;
    }

    void Move(){
        Vector3 movement = new Vector3(targetDirection.x, 0f, targetDirection.z).normalized;

        body.MovePosition(this.transform.position + (movement * moveSpeed) * Time.fixedDeltaTime);
    }

    public void Die(){
        Destroy(this.gameObject);
    }

    Vector3 FindTargetDirection(){
        if(!calculatedThisFrame){
            targetDirection = target.transform.position - this.transform.position;
            calculatedThisFrame = true;
        }

        return targetDirection;
    }

    void OnCollisionEnter(Collision thing){
        if(thing.gameObject.layer == LayerMask.NameToLayer("Tower")){
            manager.DamageTower();
            Die();
        } else if(thing.gameObject.layer == LayerMask.NameToLayer("Bullet")){
            Die();
        }
    }

    public void SetGameManager(GameTracker gT){
        manager = gT;
    }
    public void SetTarget(GameObject t){
        target = t;
    }
}