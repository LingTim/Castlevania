using UnityEngine;
using System.Collections;

public class failman_move : MonoBehaviour
{
    public Vector2 dir = new Vector2(1.0f, 0.0f);

    public int life = 70;
    public int atk = 10;
    private int change_counter = 0;

    public bool can_attack = true;//發動攻擊
    public bool attacking = false;//攻擊期間不會走動

    public GameObject beam_prefab;

    public Collider2D attack_block;

    public Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        attack_block = transform.GetChild(2).gameObject.GetComponent<Collider2D>();

        if (transform.localScale.x < 0)
            dir.x *= -1;
    }

    private void FixedUpdate()
    {
        if (!attacking)
        {
            transform.Translate(dir * Time.deltaTime * 1.5f);
            change_counter++;
        }

        if (change_counter == 150)
        {
            Flip();
        }
    }

    public void Flip()
    {
        dir.x *= -1;
        change_counter = 0;
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
    }

    public void be_damaged()
    {
        life -= 10;
        if(life > 0)
        {
            StartCoroutine(damage_effect());
        }
        else
        {
            ani.SetBool("死亡數值", true);
            StartCoroutine(death_end());
        }
    }

    public IEnumerator beam_attack()
    {
        can_attack = false;
        attacking = true;
        ani.SetBool("遠程數值", true);
        yield return new WaitForSeconds(0.667f);

        Vector3 shooting_position = transform.position;
        if (transform.localScale.x > 0)
            shooting_position.x += 1.8f;
        else
            shooting_position.x -= 1.8f;
        shooting_position.y -= 0.36f;

        GameObject beam = Instantiate(beam_prefab, shooting_position, Quaternion.identity);
        if (transform.localScale.x < 0)
            beam.GetComponent<beam>().dir.x *= -1;

        yield return new WaitForSeconds(0.667f);
        ani.SetBool("遠程數值", false);
        attacking = false;

        yield return new WaitForSeconds(1.666f);
        can_attack = true;
    }

    public IEnumerator melee_attack()
    {
        can_attack = false;
        attacking = true;
        ani.SetBool("近戰數值", true);

        yield return new WaitForSeconds(0.5f);//進戰動畫第3幀時開始攻擊判定
        attack_block.enabled = true;

        yield return new WaitForSeconds(1.0f);
        attack_block.enabled = false;
        ani.SetBool("近戰數值", false);
        attacking = false;

        yield return new WaitForSeconds(1.5f);
        can_attack = true;
    }

    private IEnumerator damage_effect()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            SR.color = new Color(SR.color.r - 0.1f, SR.color.g - 0.1f, SR.color.b - 0.1f);
        }
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            SR.color = new Color(SR.color.r + 0.1f, SR.color.g + 0.1f, SR.color.b + 0.1f);
        }
    }

    private IEnumerator death_end()
    {
        yield return new WaitForSeconds(1.262f);
        Destroy(gameObject);
    }
}
