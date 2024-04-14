using UnityEngine;

public class bat_move : MonoBehaviour
{
    public Vector2 dir = new Vector2(1.0f, 0.0f);

    private int life = 10;
    private int fly_counter = 0;

    private float v_force = 15f;

    public bool dive = false;
    private bool reverse = false;

    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        Destroy(gameObject, 20.0f);
        if (gameObject.transform.parent.transform.localScale.x < 0)
        {
            dir *= -1;
            reverse = true;
        }
    }

    private void FixedUpdate()
    {
        if(!reverse)
            transform.Translate(dir / 6.0f);
        else
            transform.Translate(dir / 6.0f * -1);

        if (dive)
        {
            fly_counter++;
            if (fly_counter <= 50)
            {
                transform.Translate(Vector2.down / 100.0f * v_force);
                //逐漸減少垂直方向的力
                v_force -= fly_counter * fly_counter / 1000.0f;
                if (v_force < 0)
                    v_force = 0;
            }
            else
            {
                dive = false;
            }
        }
    }

    public void be_damaged()
    {
        life -= 10;
        if(life <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            ani.SetBool("死亡數值", true);
        }
    }

    private void death_end()
    {
        Destroy(gameObject);
    }
}
