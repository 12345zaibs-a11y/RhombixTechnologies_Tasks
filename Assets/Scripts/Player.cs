using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public bool isGrounded ;
    Rigidbody2D rb;
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void Update()
    {
            //Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
       {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // reset Y
        rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
       } 
    }
    // FixedUpdate is called every fixed framerate frame and is used for physics calculations
    void FixedUpdate()
    {
        //movements Left and Right
        float xmovement=Input.GetAxis("Horizontal"); 
       rb.linearVelocity = new Vector2(xmovement * speed, rb.linearVelocity.y);
       
    }
    // check if player is on the ground or not 
    // both will work with the different results
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
