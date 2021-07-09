using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SahilController : MonoBehaviour
{
    private Rigidbody sahilRb;
    private float jumpForce = 10.0f;
    private float gravityForceMult = 1.5f; // set to 1.5 instead of 1 to make the object drop a bit faster
    private bool isGrounded = true;
    public bool isGameOver;

    private Animator sahilAnim;
    // Start is called before the first frame update
    void Start()
    {
        sahilRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityForceMult;
        jumpForce = sahilRb.mass * 11.6777f; // to set jump force propotionally to the object's mass 

        sahilAnim = GetComponent<Animator>();
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded && (!isGameOver))
        {
            sahilRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            sahilAnim.SetTrigger("Jump_trig");
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game 0v3r!");
            isGameOver = true;
            sahilAnim.SetBool("Death_b", true);
            sahilAnim.SetInteger("DeathType_int", 2);
        }
    }
}
