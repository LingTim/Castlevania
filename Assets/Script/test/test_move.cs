using UnityEngine;
using System.Collections;

public class test_move : MonoBehaviour
{
    private bool facingRight = false;
    private bool jumping = false;

    private float moving_speed = 5.0f;
    public float y_speed;
    public float jump_force = 500.0f;
    public float jump_continued_force = 50.0f;

    public int max_hold_time = 10;
    public int hold_counter = 0;

    private Animator ani;

    private Rigidbody2D rig;

    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        y_speed = rig.velocity.y;
        jump();
    }

    private void LateUpdate()
    {
        if (y_speed == 0 && ani.GetBool("铬臘计"))
            ani.SetBool("铬臘计", true);
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(h * Time.deltaTime * moving_speed, 0, 0);

        ani.SetFloat("簿笆计", Mathf.Abs(h));

        if ((h < 0 && facingRight || h > 0 && !facingRight))
            Flip();

        jump_continued();
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && y_speed == 0 && !jumping)
        {
            ani.SetBool("铬臘计", true);
            StartCoroutine(jump_end());
            rig.AddForce(new Vector2(0.0f, jump_force));
            jumping = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            hold_counter = 0;
            jumping = false;
        }
    }

    private void jump_continued()
    {
        if(Input.GetKey(KeyCode.Space) && hold_counter < max_hold_time && jumping)
        {
            hold_counter++;
            rig.AddForce(new Vector2(0.0f, jump_continued_force));
            //if (hold_counter == 10)
                //print("y_speed:" + y_speed + ", y:" + gameObject.transform.position.y);
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
    }

    private IEnumerator jump_end()
    {
        yield return new WaitForSeconds(0.5f);
        ani.SetBool("铬臘计", false);
    }
}
