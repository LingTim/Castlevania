using UnityEngine;

public class interact_object : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "�оǵP")
        {
            interact_text_control.instance.text_on("�ؼСG�k���o��");
        }
        else if(gameObject.name == "�q��Ƕ}��" && GameObject.Find("�q�O�}��").GetComponent<electrical_switch>().electricity == false)
        {
            interact_text_control.instance.text_on("�ݭn�q��");
        }
        else if (gameObject.name == "�j��")
        {
            interact_text_control.instance.text_on("��F�����C��");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interact_text_control.instance.text_down();
    }
}
