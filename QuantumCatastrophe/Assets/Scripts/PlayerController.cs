using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        float MovVertical = Input.GetAxis("Vertical")* MovementSpeed * Time.fixedDeltaTime;
        float MovHorizontal = Input.GetAxis("Horizontal")* MovementSpeed * Time.fixedDeltaTime;
        Vector3 Movement = new Vector3(MovHorizontal,0,MovVertical);
        Movement = transform.rotation * Movement;
        rb.velocity = new Vector3(Movement.x,rb.velocity.y,Movement.z);
    }

}
