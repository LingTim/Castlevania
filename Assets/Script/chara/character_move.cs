using UnityEngine;
using System.Collections;

public class character_move : MonoBehaviour
{
    private bool facingRight = false;
    public bool jump = true;
    public bool is_ground = true;
    public bool can_attack = true;
    public bool attacking = false;
    public bool is_beat_back = false;//琌タ砆阑癶

    private float moving_speed = 5.0f;
    public float jumpForce = 100.0f;
    private float y_speed;

    private int max_hold_time = 10;
    private int hold_counter = 0;
    public int life = 70;

    public Animator ani;

    private Collider2D attack_block;

    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        attack_block = transform.GetChild(1).GetComponent<Collider2D>();

    }

    void Update()
    {
        y_speed = GetComponent<Rigidbody2D>().velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && jump && is_ground && !is_beat_back)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce));
            is_ground = false;
            ani.SetBool("铬臘计", true);
            StartCoroutine(jump_end());
        }

        if (Input.GetKeyUp(KeyCode.Space) && !is_ground)
        {
            jump = false;
            hold_counter = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && is_ground)
        {
            jump = true;
            hold_counter = 0;
        }

        attack();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (!is_beat_back && !attacking)
            transform.Translate(h * Time.deltaTime * moving_speed, 0, 0);

        ani.SetFloat("簿笆计", Mathf.Abs(h));

        if ((h < 0 && facingRight || h > 0 && !facingRight) && !is_beat_back)
            Flip();

        if (Input.GetKey(KeyCode.Space) && jump && !is_ground)
        {
            hold_counter++;
            if (hold_counter >= max_hold_time)
            {
                jump = false;
            }

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce));
        }

        if (y_speed != 0)
            is_ground = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "villain" && !is_beat_back)
        {
            is_beat_back = true;
            injury();

            //阑癶
            if (life > 0)
            {
                beat_back(transform.position.x, collision.transform.position.x);
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

    public void injury()
    {
        life -= 10;
        bloodUI_control.instance.bloodUI_change(life);

        if (life <= 0)
        {
            ani.SetBool("计", true);
            StartCoroutine(death_end());
        }
        else
        {
            ani.SetBool("端计", true);
            StartCoroutine(damage_end());
        }
    }

    public void beat_back(float player_x, float collision_x)
    {
        Vector2 power = new Vector2(1.0f, 0.8f);

        if (player_x < collision_x)
            power.x *= -1;

        GetComponent<Rigidbody2D>().AddForce(power * 400.0f);
    }

    private void attack()
    {
        //炊ю
        if (Input.GetKeyDown(KeyCode.J) && can_attack && !ani.GetBool("铬臘计") && !is_beat_back)
        {
            ani.SetBool("ю阑计", true);
            StartCoroutine(attack_end(1, 0.333f));
            can_attack = false;
            attacking = true;
        }

        //铬ю
        if (Input.GetKeyDown(KeyCode.J) && ani.GetBool("铬臘计") && can_attack)
        {
            can_attack = false;
            ani.SetBool("ю阑计", true);
            StartCoroutine(jump_attack_end());
            attacking = true;
        }
    }

    private void attack_begin()
    {
        attack_block.enabled = true;
    }

    private IEnumerator attack_end(int num, float sec)
    {
        yield return new WaitForSeconds(sec);
        attack_block.enabled = false;
        ani.SetBool("ю阑计", false);
        attacking = false;
        StartCoroutine(attack_cooldown());
    }

    private IEnumerator jump_end()
    {
        yield return new WaitForSeconds(0.5f);
        ani.SetBool("铬臘计", false);
    }

    private IEnumerator jump_attack_end()
    {
        yield return new WaitForSeconds(0.208f);

        attack_block.enabled = false;
        ani.SetBool("ю阑计", false);
        attacking = false;
        StartCoroutine(attack_cooldown());
    }

    private IEnumerator damage_end()
    {
        yield return new WaitForSeconds(0.417f);
        ani.SetBool("ю阑计", false);
        ani.SetBool("铬臘计", false);
        ani.SetBool("端计", false);
        StartCoroutine(attack_cooldown());
        is_beat_back = false;
    }

    private IEnumerator death_end()
    {
        yield return new WaitForSeconds(1.25f);
        Destroy(gameObject);
    }

    private IEnumerator attack_cooldown()
    {
        yield return new WaitForSeconds(0.2f);
        can_attack = true;
    }
}
