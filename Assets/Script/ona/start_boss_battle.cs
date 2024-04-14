using UnityEngine;

public class start_boss_battle : MonoBehaviour
{
    public bool is_activate = false;

    public ona_move ona;

    public GameObject front_door;

    public AudioClip boss_bgm;

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

            GameObject.Find("�ڮR�Y���I��").GetComponent<CanvasGroup>().alpha = 1.0f;
            GameObject.Find("�ڮR���").GetComponent<CanvasGroup>().alpha = 1.0f;
            GameObject.Find("BGM").GetComponent<AudioSource>().clip = boss_bgm;
            GameObject.Find("BGM").GetComponent<AudioSource>().Play();

            bloodUI_control.instance.ona_bloodUI_change(190);
        }
    }
}
