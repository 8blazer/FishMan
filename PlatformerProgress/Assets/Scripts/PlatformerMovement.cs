using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public GameObject fish;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    public bool canMove = true;
    void Start()
    {

    }
    void Update()
    {
        if (canMove)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x = moveX * moveSpeed;
            GetComponent<Rigidbody2D>().velocity = velocity;
            if (moveX > 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));
                GetComponent<SpriteRenderer>().flipX = false;
                fish.GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Animator>().SetInteger("x", 1);
            }
            if (moveX < 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0));
                GetComponent<SpriteRenderer>().flipX = true;
                fish.GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Animator>().SetInteger("x", -1);
            }
            if (moveX == 0)
            {
                GetComponent<Animator>().SetInteger("x", 0);
            }
            if (Input.GetButtonDown("Jump") && grounded)
            {
                NotGrounded();
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
                GetComponent<Animator>().SetInteger("y", 1);
                GetComponent<Animator>().SetInteger("x", 0);
            }
            if (velocity.y > 0)
            {
                GetComponent<Animator>().SetInteger("y", 1);
            }
            else if (velocity.y < 0)
            {
                GetComponent<Animator>().SetInteger("y", -1);
            }
            else
            {
                GetComponent<Animator>().SetInteger("y", 0);
            }
        }
        /*if (inWater == false)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                oxygen--;
                if (oxygen == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                timer = 0;
            }
        }
        if (inWater && oxygen < 30)
        {
            oxygen++;
        }
        oxygenText.text = oxygen.ToString();*/
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Grounded();
        GetComponent<Animator>().SetBool("grounded", grounded);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Grounded();
        GetComponent<Animator>().SetBool("grounded", grounded);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        NotGrounded();
        GetComponent<Animator>().SetBool("grounded", grounded);
    }
    public void Grounded()
    {
        GetComponent<Animator>().SetBool("grounded", grounded);
        grounded = true;
    }

    public void NotGrounded()
    {
        GetComponent<Animator>().SetBool("grounded", grounded);
        grounded = false;
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            inWater = true;
            timer = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            inWater = false;
        }
    }*/
}



