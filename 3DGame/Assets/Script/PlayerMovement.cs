using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
   [SerializeField] private int JumpHight = 3;
   [SerializeField] private float PlayerSpeed = 5;
   [SerializeField] private Transform GroundCheck;
   [SerializeField] private LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(horizontalInput * PlayerSpeed,rb.velocity.y, verticalInput * PlayerSpeed);

        if (Input.GetButtonDown("Jump")&&IsGrounded())
        {
            Jump();
        }
       
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, JumpHight, rb.velocity.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
    private bool IsGrounded()
    {
      return  Physics.CheckSphere(GroundCheck.position, .1f, ground);
    }
}
