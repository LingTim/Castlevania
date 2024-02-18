using UnityEngine;
using System.Collections;

public class character_move : MonoBehaviour
{
    private bool facingRight = false;
    public bool jump = true;
    public bool is_ground = true;
    public bool can_attack = true;

    private float moving_speed = 5.0f;
    public float jumpForce = 150.0f;
    public float y_speed;

    public int max_hold_time = 10;
    public int hold_counter = 0;
    public int step = 0;
    public int atk = 10;
    public int life = 100;

    public Animator ani;

    private Collider2D attack_block;

    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        attack_block = transform.GetChild(2).GetComponent<Collider2D>();
    }

    void Update()
    {
        y_speed = GetComponent<Rigidbody2D>().velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && jump && step == 0 && is_ground)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce / Time.deltaTime / 100.0f));
            print("jump");
            ani.SetBool("铬臘计", true);
        }

        if (Input.GetKeyUp(KeyCode.Space) && !is_ground)
        {
            jump = false;
            hold_counter = 0;
        }
        else if(Input.GetKeyUp(KeyCode.Space) && is_ground)
        {
            jump = true;
            hold_counter = 0;
        }

        attack();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(h * Time.deltaTime * moving_speed, 0, 0);

        ani.SetFloat("簿笆计", Mathf.Abs(h));

        if (h < 0 && facingRight || h > 0 && !facingRight)
            Flip();

        if (Input.GetKey(KeyCode.Space) && jump && !is_ground)
        {
            hold_counter++;
            if (hold_counter >= max_hold_time)
            {
                jump = false;
            }

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce / Time.deltaTime / 100.0f));
            print("jump");
        }

        if (y_speed != 0)
            is_ground = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "villain")
        {
            life -= 10;
            ani.SetBool("端计", true);

            //端秈祑
            GameObject [] villains = GameObject.FindGameObjectsWithTag("villain");
            foreach(GameObject villain in villains)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), villain.GetComponent<Collider2D>());
            }
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
    }

    private void attack()
    {
        //炊ю
        if (Input.GetKeyDown(KeyCode.J) && can_attack && step == 0 && !ani.GetBool("铬臘计"))
        {
            //print("1");
            ani.SetInteger("ю阑计", 1);
            step++;
            can_attack = false;
        }
        else if (Input.GetKeyDown(KeyCode.J) && step == 1)
        {
            //print("2");
            ani.SetInteger("ю阑计", 2);
            step++;
        }
        else if (Input.GetKeyDown(KeyCode.J) && step == 2)
        {
            //print("3");
            ani.SetInteger("ю阑计", 3);
            step++;
        }

        //铬ю
        if (Input.GetKeyDown(KeyCode.J) && ani.GetBool("铬臘计") && can_attack)
        {
            can_attack = false;
            ani.SetInteger("ю阑计", 1);
        }
    }

    private void attack_begin()
    {
        attack_block.enabled = true;
    }

    private void attack_end(int num)
    {
        attack_block.enabled = false;

        if (step == num)
        {
            ani.SetInteger("ю阑计", 0);
            step = 0;
            StartCoroutine(attack_cooldown());
        }   
    }

    public void jump_attack_end()
    {
        attack_block.enabled = false;
        ani.SetInteger("ю阑计", 0);
        StartCoroutine(attack_cooldown());
    }

    private void damage_end()
    {
        ani.SetInteger("ю阑计", 0);
        ani.SetBool("铬臘计", false);
        step = 0;

        ani.SetBool("端计", false);

        //祑挡
        GameObject[] villains = GameObject.FindGameObjectsWithTag("villain");
        foreach (GameObject villain in villains)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), villain.GetComponent<Collider2D>(), false);
        }

        StartCoroutine(attack_cooldown());
    }

    private IEnumerator attack_cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        can_attack = true;
    }
}
