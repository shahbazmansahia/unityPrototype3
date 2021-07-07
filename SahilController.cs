using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SahilController : MonoBehaviour
{
    private Rigidbody sahilRb;
    private float jumpForce = 10.0f;
    private float gravityForceMult = 1;
    private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        sahilRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityForceMult;
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            sahilRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        isGrounded = true;
    }
}
