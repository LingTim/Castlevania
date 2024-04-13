using UnityEngine;

public class start_boss_battle : MonoBehaviour
{
    public bool is_activate = false;

    public ona_move ona;

    public GameObject front_door;

    private void Start()
    {
        front_door = GameObject.Find("BOSS�Ԥɰ_����");
        front_door.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!is_activate)
        {
            ona = GameObject.Find("�ڮR").GetComponent<ona_move>();
            ona.ona_activate();
            ona.chara = GameObject.Find("�D��").GetComponent<character_move>();
            ona.door = GameObject.Find("BOSS�Ե������U����");
            is_activate = true;
            front_door.SetActive(true);
        }
    }
}
