using UnityEngine;

public class start_boss_battle : MonoBehaviour
{
    public bool is_activate = false;

    public ona_move ona;

    public GameObject front_door;

    private void Start()
    {
        front_door = GameObject.Find("BOSS戰升起的門");
        front_door.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!is_activate)
        {
            ona = GameObject.Find("歐娜").GetComponent<ona_move>();
            ona.ona_activate();
            ona.chara = GameObject.Find("主角").GetComponent<character_move>();
            ona.door = GameObject.Find("BOSS戰結束降下的門");
            is_activate = true;
            front_door.SetActive(true);
        }
    }
}
