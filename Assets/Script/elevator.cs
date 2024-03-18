using UnityEngine;

public class elevator : MonoBehaviour
{
    public bool electricity = false;
    private bool can_use = false;

    public Vector3 teleport_position;

    private GameObject teleport_obj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && electricity && can_use)
        {
            warp_control.instance.warp(teleport_position, teleport_obj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && electricity)
        {
            can_use = true;
            teleport_obj = collision.gameObject;
            interact_text_control.instance.text_on();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && electricity)
        {
            can_use = false;
            interact_text_control.instance.text_down();
        }
    }
}
