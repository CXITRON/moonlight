using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprender;
    public float speed;
    Animator anim;

    public float maxSpeed;
    public float jumpPower;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.x > 0)
        {
            sprender.flipX = false;

        }
        else if (rigid.velocity.x < 0)
        {
            sprender.flipX = true;
        }

                

        if (rigid.velocity.normalized.x == 0) anim.SetBool("isWalking", false);
        else if (rigid.velocity.normalized.x != 0) anim.SetBool("isWalking", true);

        if (Input.GetButtonDown("Jump") && anim.GetBool("isJump") == false)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            anim.SetBool("isJump", false);
        }
    }
}
