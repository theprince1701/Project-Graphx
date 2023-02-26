using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHari : MonoBehaviour
{
    private CharacterController characterController;
    public GameManager gameManager;

    public float speed = 5.0f;
    public float gravity = 2.0f;
    public float _groundRadius = 1.0f;

    public Transform groundCheck;

    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));

        characterController.Move((transform.forward *move.z * Time.deltaTime * speed) + (transform.right *move.x * Time.deltaTime * speed));

        if (!Physics.CheckSphere(groundCheck.position, _groundRadius, groundMask))
        {
            characterController.Move(-transform.up * Time.deltaTime * gravity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision with enemy, you have taken damage!");
            gameManager.Lose();
        }
    }
}
