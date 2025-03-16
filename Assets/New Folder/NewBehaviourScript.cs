using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public float jumpForce = 10f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float moveInput = Input.GetAxis("Horizontal");
        Debug.Log("moveInput: " + moveInput);
        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }

    
}