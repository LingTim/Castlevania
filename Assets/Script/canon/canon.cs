using UnityEngine;
using System.Collections;

public class canon : MonoBehaviour
{
    private bool attacking = false;
    private bool can_attack = false;

    private int attack_cd = 0;

    public GameObject canon_bullet;
    private GameObject shooting_pos;

    private Animator ani;

    private void Start()
    {
        shooting_pos = gameObject.transform.GetChild(0).gameObject;
        ani = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(can_attack)
            attack_cd++;

        if(attack_cd >= 200 && !attacking)
        {
            StartCoroutine(shooting());
            attack_cd = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            can_attack = true;
            attack_cd = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            can_attack = false;
    }

    IEnumerator shooting()
    {
        attacking = true;
        ani.SetBool("§ðÀ»¼Æ­È", true);

        yield return new WaitForSeconds(0.126f * 6);
        GameObject token = Instantiate(canon_bullet, shooting_pos.transform.position, Quaternion.identity);
        if (gameObject.transform.localScale.x < 0)
        {
            token.transform.localScale = new Vector3(token.transform.localScale.x * -1,
                                                     token.transform.localScale.y,
                                                     token.transform.localScale.z);
            token.GetComponent<canon_bullet>().dir *= -1;
        }

        attacking = false;
        ani.SetBool("§ðÀ»¼Æ­È", false);
    }
}
