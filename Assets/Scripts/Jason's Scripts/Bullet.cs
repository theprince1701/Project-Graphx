using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody body;

    void Awake(){
        body = this.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision thing){
        Destroy(this.gameObject);
    }
}
