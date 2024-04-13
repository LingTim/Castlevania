using UnityEngine;
using System.Collections;

public class character_move : MonoBehaviour
{
    private bool facingRight = false;
    private bool jumping = false;
    public bool can_attack = true;
    public bool attacking = false;
    public bool is_beat_back = false;//琌タ砆阑癶
    private bool is_invincible = false; 

    private float moving_speed = 6.0f;
    public float jump_force = 550.0f;
    public float jump_continued_force = 55.0f;
    private float y_speed;

    private int max_hold_time = 10;
    private int hold_counter = 0;
    public int life = 70;

    public Animator ani;
    private Rigidbody2D rig;

    private Collider2D attack_block;
    private Collider2D col;

    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        attack_block = transform.GetChild(0).GetComponent<Collider2D>();
        bloodUI_control.instance.bloodUI_change(life);
    }

    void Update()
    {
        y_speed = rig.velocity.y;

        jump();

        attack();
    }

    private void LateUpdate()
    {
        if (y_speed == 0 && ani.GetBool("铬臘计"))
            ani.SetBool("铬臘计", true);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (!is_beat_back && !attacking)
            transform.Translate(h * Time.deltaTime * moving_speed, 0, 0);

        ani.SetFloat("簿笆计", Mathf.Abs(h));

        if ((h < 0 && facingRight || h > 0 && !facingRight) && !is_beat_back)
            Flip();

        jump_continued();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "villain" && !is_invincible)
        {
            if(collision.transform.name == "禬(Clone)")
                injury(20);
            else
                injury(10);
            beat_back(transform.position.x, collision.transform.position.x);
        }
        else if(collision.transform.tag == "fall")
        {
            injury(10);
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && y_speed == 0 && !jumping)
        {
            ani.SetBool("铬臘计", true);
            StartCoroutine(jump_end());
            rig.AddForce(new Vector2(0.0f, jump_force));
            jumping = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            hold_counter = 0;
            jumping = false;
        }
    }

    private void jump_continued()
    {
        if (Input.GetKey(KeyCode.Space) && hold_counter < max_hold_time && jumping)
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

    public void injury(int damage)
    {
        life -= damage;
        bloodUI_control.instance.bloodUI_change(life);

        if (life <= 0)
        {
            ani.SetBool("计", true);
            StartCoroutine(death_end());
        }
        else
        {
            ani.SetBool("端计", true);
            StartCoroutine(invincible());
            StartCoroutine(damage_end());
            col.enabled = false;
        }
    }

    public void beat_back(float player_x, float collision_x)
    {
        is_beat_back = true;
        Vector2 power = new Vector2(0.6f, 0.6f);

        if (player_x < collision_x)
            power.x *= -1;

        rig.AddForce(power * 400.0f);
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
            ani.SetBool("ю阑计", true);
            StartCoroutine(jump_attack_end());
            can_attack = false;
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
        bloodUI_control.instance.death_canvas_appear();
        Destroy(gameObject);
    }

    private IEnumerator attack_cooldown()
    {
        yield return new WaitForSeconds(0.2f);
        can_attack = true;
    }

    private IEnumerator invincible()
    {
        is_invincible = true;
        gameObject.layer = LayerMask.NameToLayer("invincible");
        yield return new WaitForSeconds(2.0f);
        is_invincible = false;
        gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
