using UnityEngine;
using System.Collections;

public class ona_move : MonoBehaviour
{
    private bool facingRight = false;
    private bool attacking = false;

    private int attack_cd = 0;
    public int life = 200;
    private int last_tech = 0;

    private Vector3 chara_pos;
    private Vector3 my_pos;
    //����������m
    private Vector3 left_wall = new Vector3(-70, 104.065f, 0);
    private Vector3 right_wall = new Vector3(-20, 104.065f, 0);

    //�l����3�صo�g��V
    public Vector2[] shell_direction;

    public Animator ani;

    private character_move chara;

    private Rigidbody2D rig;

    private Collider2D col;

    public GameObject tech1_bullet;
    public GameObject tech2_bullet;
    public GameObject tech3_bullet;
    public GameObject tech4_bullet;
    //���������o�g��m
    public GameObject[] horizontal_bullets;
    //�l�����o�g��m
    public GameObject[] shell_bullets;
    //�s��u���o�g��m
    public GameObject[] sequence_bullets;
    //�����o�g��m
    public GameObject giant_bullet;
    //BOSS�Ե�����}�Ҫ���
    public GameObject door;

    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        rig = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        chara = GameObject.Find("�D��").GetComponent<character_move>();
    }

    private void FixedUpdate()
    {
        if (ani.GetBool("�԰��ƭ�") && chara != null)
        {
            attack();
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;

        GameObject temp = sequence_bullets[0];
        sequence_bullets[0] = sequence_bullets[3];
        sequence_bullets[3] = temp;

        temp = sequence_bullets[1];
        sequence_bullets[1] = sequence_bullets[2];
        sequence_bullets[2] = temp;
    }

    private void tracing()
    {
        //�l�ܪ��a����m

        if (my_pos.x > chara_pos.x)
        {
            rig.velocity = new Vector2(-2.0f, rig.velocity.y);
            if (facingRight)
                Flip();
        }
        else
        {
            rig.velocity = new Vector2(2.0f, rig.velocity.y);
            if (!facingRight)
                Flip();
        }

        if (my_pos.y > chara_pos.y + 1.0f)
            rig.velocity = new Vector2(rig.velocity.x, -2.0f);
        else if (my_pos.y < chara_pos.y - 1.0f)
            rig.velocity = new Vector2(rig.velocity.x, 2.0f);
    }

    public void ona_activate()
    {
        ani.SetBool("�ഫ�ƭ�", true);
        StartCoroutine(battle_start());
    }

    IEnumerator battle_start()
    {
        yield return new WaitForSeconds(2.27f);
        ani.SetBool("�԰��ƭ�", true);
        InvokeRepeating("tracing", 0, 0.3f);
    }

    private void attack()
    {
        //��s�D���P�ڮR����m
        if (chara != null)
            chara_pos = chara.transform.position;
        my_pos = gameObject.transform.position;

        if (!attacking)
            attack_cd++;

        //�C�������ܤֵ���4��
        if (attack_cd >= 200)
        {
            //�ڮR���פj��D���A�B�P�D����������m�۪�|�o�ʰl����
            if (chara_pos.y < my_pos.y && chara_pos.x - 4.0f < my_pos.x && my_pos.x < chara_pos.x + 4.0f && last_tech != 1)
            {
                StartCoroutine(shell());
                last_tech = 1;
                attack_cd = 0;
                print("1");
            }
            //���誺������m�ݬ۪�|�o�_��������
            else if (chara_pos.y - 1.0f < my_pos.y && my_pos.y < chara_pos.y + 1.0f && last_tech != 2)
            {
                StartCoroutine(horizontal_attack());
                last_tech = 2;
                attack_cd = 0;
                print("2");
            }
            //������x�~�|�o�ʳs��u��
            else if (my_pos.y > 104.265f && last_tech != 3)
            {
                StartCoroutine(sequence_shooting());
                last_tech = 3;
                attack_cd = 0;
                print("3");
            }
            else if (life < 80 && last_tech != 4)
            {
                StartCoroutine(giant_blast());
                last_tech = 4;
                attack_cd = 0;
                print("4");
            }
        }
    }

    IEnumerator horizontal_attack()
    {
        //�o�ʧ����ɤ�����
        CancelInvoke("tracing");
        rig.velocity = new Vector2(0, 0);
        attacking = true;

        ani.SetBool("�ۦ�1", true);

        //�b�ʵe��4�i�P��6�i�ɲ��ͤl�u
        yield return new WaitForSeconds(0.126f * 4);
        Instantiate(tech1_bullet, horizontal_bullets[0].transform.position, Quaternion.identity);


        yield return new WaitForSeconds(0.126f * 2);
        Instantiate(tech1_bullet, horizontal_bullets[1].transform.position, Quaternion.identity);

        //�����ʵe�ɭ��mcd�A�ö}�l����
        yield return new WaitForSeconds(0.126f * 4);
        ani.SetBool("�ۦ�1", false);
        attacking = false;
        InvokeRepeating("tracing", 0, 0.5f);
    }

    IEnumerator shell()
    {
        //�o�ʧ����ɤ�����
        CancelInvoke("tracing");
        rig.velocity = new Vector2(0, 0);
        col.enabled = false;
        attacking = true;

        //���W��
        while (gameObject.transform.position.y < 107)
        {
            transform.Translate(0, 0.4f, 0);
            yield return new WaitForSeconds(0.05f);
        }

        ani.SetBool("�ۦ�2", true);


        //�b�ʵe��6�i�ɲ��ͤl�u
        yield return new WaitForSeconds(0.126f * 6);

        //�|�Ӥl�u�o�g�I�o�graycast�A�p��P�a�����Z���A�M��ͦ��l�u
        for (int i = 0; i < 4; i++)
        {
            Vector2 origin = shell_bullets[i].transform.position;

            //�l�u��V�q���U����15�סB���U�M���U���k15�פ��H����@��
            System.Random random = new System.Random();
            int ran = random.Next(3);
            Vector2 direction = shell_direction[ran];

            float max_distance = 20.0f;

            RaycastHit2D hit = Physics2D.Raycast(origin, direction, max_distance);

            float distance;

            //�p��ͦ��I
            if (hit.collider != null)
            {
                distance = hit.distance;
            }
            else
                distance = max_distance;

            Vector3 born_position = new Vector3(shell_bullets[i].transform.position.x + shell_direction[ran].x * distance / 2,
                                                shell_bullets[i].transform.position.y + shell_direction[ran].y * distance / 2,
                                                shell_bullets[i].transform.position.z);

            float angle;
            if (ran == 0)
                angle = -15;
            else if (ran == 1)
                angle = 0;
            else
                angle = 15;

            GameObject token = Instantiate(tech2_bullet, born_position, Quaternion.Euler(0, 0, angle));
            token.transform.localScale = new Vector3(token.transform.localScale.x,
                                                     token.transform.localScale.y * distance * 3,
                                                     token.transform.localScale.z);

            Destroy(token, 0.126f * 5);

            //���������������٦����X
            if (i == 1)
                yield return new WaitForSeconds(0.126f);
        }

        //�����ʵe�ɭ��mcd�A�ö}�l����
        yield return new WaitForSeconds(0.126f * 5);
        ani.SetBool("�ۦ�2", false);
        attacking = false;
        col.enabled = true;
        InvokeRepeating("tracing", 0, 0.5f);
    }

    IEnumerator sequence_shooting()
    {
        //�o�ʧ����ɤ�����
        CancelInvoke("tracing");
        rig.velocity = new Vector2(0, 0);
        attacking = true;
        col.enabled = false;

        ani.SetBool("�ۦ�3", true);

        //�b��6���10�i�ʵe�������ͤl�u
        yield return new WaitForSeconds(0.126f * 5);

        //�Ĥ@�������A16��V�l�u
        float angle = 0;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(tech3_bullet, sequence_bullets[0].transform.position, Quaternion.Euler(0, 0, (90 - angle) % 360));
            Instantiate(tech3_bullet, sequence_bullets[1].transform.position, Quaternion.Euler(0, 0, (90 + angle) % 360));
            Instantiate(tech3_bullet, sequence_bullets[2].transform.position, Quaternion.Euler(0, 0, (270 - angle) % 360));
            Instantiate(tech3_bullet, sequence_bullets[3].transform.position, Quaternion.Euler(0, 0, (270 + angle) % 360));
            angle += 30;
        }

        yield return new WaitForSeconds(0.126f * 5);

        //�ĤG�������A9��V�l�u
        angle = 0;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(tech3_bullet, sequence_bullets[0].transform.position, Quaternion.Euler(0, 0, (90 - angle) % 360));
            Instantiate(tech3_bullet, sequence_bullets[1].transform.position, Quaternion.Euler(0, 0, (90 + angle) % 360));
            Instantiate(tech3_bullet, sequence_bullets[2].transform.position, Quaternion.Euler(0, 0, (270 - angle) % 360));
            Instantiate(tech3_bullet, sequence_bullets[3].transform.position, Quaternion.Euler(0, 0, (270 + angle) % 360));
            angle += 45;
        }

        //�����ʵe�ɭ��mcd�A�ö}�l����
        yield return new WaitForSeconds(0.126f * 5);
        ani.SetBool("�ۦ�3", false);
        col.enabled = true;
        attacking = false;
        InvokeRepeating("tracing", 0, 0.5f);
    }

    IEnumerator giant_blast()
    {
        //�ھڰ��סA���ʨ���x�W�ΤU���S�w��m
        float y;

        if (my_pos.y > 104.265f)
            y = 104.265f;
        else
            y = 101.265f;

        col.enabled = false;
        while(gameObject.transform.position.y > y)
        {
            transform.Translate(0, -0.4f, 0);
            yield return new WaitForSeconds(0.05f);
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, y, gameObject.transform.position.z);
        col.enabled = true;

        //�o�ʧ����ɤ�����
        CancelInvoke("tracing");
        rig.velocity = new Vector2(0, 0);
        attacking = true;

        ani.SetBool("�j��", true);

        //�b��15���21�i�ʵe�������ͤl�u
        yield return new WaitForSeconds(0.126f * 15);

        //�p��l�u���ͦ���m
        Vector3 born_pos;
        Vector3 hit_place;
        float distance;

        if (gameObject.transform.localScale.x < 0)
            hit_place = left_wall;
        else
            hit_place = right_wall;

        born_pos = new Vector3((giant_bullet.transform.position.x + hit_place.x) / 2,
                                giant_bullet.transform.position.y,
                                giant_bullet.transform.position.z);
        distance = Mathf.Abs(giant_bullet.transform.position.x - hit_place.x);

        //�ͦ��íp��scale
        GameObject token = Instantiate(tech4_bullet, born_pos, Quaternion.Euler(0, 0, 90));

        token.transform.localScale = new Vector3(token.transform.localScale.x,
                                                     token.transform.localScale.y * distance * 0.9f,
                                                     token.transform.localScale.z);

        //�����D������ͦ����ɭ�active�Ofalse�A�ҥH�N�[�W�F�o��
        //token.SetActive(true);

        Destroy(token, 0.126f * 6);

        //�����ʵe�ɭ��mcd�A�ö}�l����
        yield return new WaitForSeconds(0.126f * 11);
        ani.SetBool("�j��", false);
        attacking = false;
        InvokeRepeating("tracing", 0, 0.5f);
    }

    public void be_damaged()
    {
        life -= 10;
        if (life > 0)
        {
            StartCoroutine(damage_effect());
        }
        else
        {
            ani.SetBool("�Ա�", true);
            ani.SetBool("�԰��ƭ�", false);
            CancelInvoke("tracing");
            rig.velocity = new Vector2(0, 0);
            StopAllCoroutines();
            col.enabled = false;
            door.SetActive(false);
        }
    }

    private IEnumerator damage_effect()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 10; i++)
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
}
