using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
public class Player : MonoBehaviour
{

    private Animator playerAnim;
    private Rigidbody2D rigi;
    public float speed;
    private SpriteRenderer sr;
    public float jumpForce;
    public bool inFloor = true;
    public int papel;
    
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void MovePlayer()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMovement);
        transform.position += new Vector3(horizontalMovement * Time.deltaTime * speed, 0, 0);

        if (horizontalMovement > 0)
        {
            playerAnim.SetBool("Walk", true);
            sr.flipX = true;
        }

        else if (horizontalMovement < 0)
        {
            playerAnim.SetBool("Walk", true);
            sr.flipX = false;
        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && inFloor)
        {
            playerAnim.SetBool("Jump", true);
            rigi.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            inFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            playerAnim.SetBool("Jump", false);
            inFloor = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "papel")
        {
            Destroy(collision.gameObject);
            papel++;
        }
    }
}