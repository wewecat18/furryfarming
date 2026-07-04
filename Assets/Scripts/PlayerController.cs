using UnityEngine;

public class PlayerController : MonoBehaviour
{
        public float Pspeed;
    public Rigidbody2D rb;
    Vector2 move;

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
       
        if (Input.GetButton("Fire3"))
        {
             rb.MovePosition(rb.position + move.normalized * (Pspeed *2) * Time.deltaTime);
        }
        else
        {
             rb.MovePosition(rb.position + move.normalized * Pspeed * Time.deltaTime);
        }
    }
}
