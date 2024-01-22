using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    public bool facingRight = true;
    public bool jump = true;
    public bool is_ground = true;

    private float moving_speed = 5.0f;
    public float jumpForce = 200.0f;
    public float max_hold_time = 0.5f;
    float current;

    private Animator ani;
    private string move = "²¾°Ê¼Æ­È";

    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jump)
        {
            current = Time.time;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce / Time.deltaTime / 100.0f));
        }

        if (Input.GetKeyUp(KeyCode.Space) && !is_ground)
        {
            jump = false;
        }
        else if(Input.GetKeyUp(KeyCode.Space) && is_ground)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(h * Time.deltaTime * moving_speed, 0, 0);

        ani.SetFloat(move, Mathf.Abs(h));

        if (h > 0 && facingRight || h < 0 && !facingRight)
            Flip();

        if (Input.GetKey(KeyCode.Space) && jump)
        {
            if (Time.time - current >= max_hold_time && !is_ground)
            {
                jump = false;
            }

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce / Time.deltaTime / 100.0f));
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
    }
}
