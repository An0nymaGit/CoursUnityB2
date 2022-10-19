using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private float speed = 1f;
    public float horizontalInput;
    public float verticalInput; 

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        Debug.DrawRay(transform.position, -transform.forward, Color.green);
        Debug.DrawRay(transform.position, transform.right, Color.red); 
        Debug.DrawRay(transform.position, -transform.right, Color.red);
        
        rb.AddForce((transform.forward * verticalInput + transform.right * horizontalInput) * speed, ForceMode.Impulse); //pas besoin d'un deltatime si forcemode instantanée
    }
}




























