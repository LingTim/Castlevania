using UnityEngine;

public class save_point : MonoBehaviour
{
    private bool is_save = false;

    private Animator ani;

    private save_data SD;

    private void Start()
    {
        ani = GetComponent<Animator>();
        SD = GameObject.Find("�s�ɸ��").GetComponent<save_data>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !is_save)
        {
            is_save = true;
            ani.enabled = true;
            ani.SetBool("Ĳ�I�ƭ�", true);
            save();
            collision.GetComponent<character_move>().life = 70;
            bloodUI_control.instance.bloodUI_change(collision.GetComponent<character_move>().life);
            interact_text_control.instance.text_on("�w�s��");
        }
    }

    private void save()
    {
        SD.reborn_point = new Vector3(transform.position.x, transform.position.y - 3.235f, transform.position.z);
        SD.rat = false;
        SD.bat = false;
        if (gameObject.name == "�����e�s���I")
        {
            SD.failman = false;
            SD.eletricity = true;
            SD.eletricity_room_wall = true;
            SD.damaged_bridge = false;
        }
            
    }
}
