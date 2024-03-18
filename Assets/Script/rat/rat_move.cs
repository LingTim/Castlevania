using UnityEngine;
using System.Collections;

public class rat_move : MonoBehaviour
{
    public Vector2 dir = new Vector2(1.0f, 0.0f);

    public int life = 20;
    public int atk = 10;
    private int change_counter = 0;

    public bool can_attack = true;//�o�ʧ���
    public bool attacking = false;//�����������|����
    public bool jump = false;//�P�_���a

    public Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();

        if (transform.localScale.x < 0)
            dir.x *= -1;
    }

    private void FixedUpdate()
    {
        if(!attacking)
        {
            transform.Translate(dir * Time.deltaTime * 3.0f);
            change_counter++;
        }
            
        if (change_counter == 150)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���D���a���ਭ
        if(collision.transform.tag == "ground" && jump)
        {
            jump = false;
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
            ani.SetBool("���˼ƭ�", true);
        }
        else
        {
            ani.SetBool("���`�ƭ�", true);
        }
    }

    public void damage_end()
    {
        if (ani.GetBool("���`�ƭ�"))
            Destroy(gameObject);

        ani.SetBool("���˼ƭ�", false);
    }

    public IEnumerator attack()
    {
        yield return new WaitForSeconds(0.5f);

        Vector2 rat_force = new Vector2(dir.x, 0.4f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(rat_force * 500.0f);
        attacking = false;
        jump = true;

        yield return new WaitForSeconds(3.0f);
        can_attack = true;
    }
}
