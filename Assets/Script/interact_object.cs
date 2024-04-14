using UnityEngine;

public class interact_object : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "教學牌")
        {
            interact_text_control.instance.text_on("目標：逃離這裡");
        }
        else if(gameObject.name == "電梯旁開關" && GameObject.Find("電力開關").GetComponent<electrical_switch>().electricity == false)
        {
            interact_text_control.instance.text_on("需要電源");
        }
        else if (gameObject.name == "大門")
        {
            interact_text_control.instance.text_on("按F結束遊戲");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interact_text_control.instance.text_down();
    }
}
