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

    private Renderer _renderer;

    void Awake(){
        body = this.GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
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

    //    body.MovePosition(this.transform.position + (movement * moveSpeed) * Time.fixedDeltaTime);
    }

    public void OnLook()
    {
        _renderer.material.SetFloat("_Outline", 1);
    }

    public void StopLook()
    {
        _renderer.material.SetFloat("_Outline", 0);
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
        Debug.Log(thing.gameObject.layer);
        if(thing.gameObject.layer == LayerMask.NameToLayer("Tower")){
            manager.DamageTower();
            Die();
        } else if(thing.gameObject.layer == LayerMask.NameToLayer("Bullet")){
            Die();
        }
    }
}