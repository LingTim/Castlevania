using UnityEngine;

public class elevator : MonoBehaviour
{
    public bool can_use = false;

    public Vector3 teleport_position;

    private electrical_switch ES;
    private GameObject teleport_obj;

    private void Start()
    {
        ES = GameObject.Find("電力開關").GetComponent<electrical_switch>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && ES.electricity && can_use)
        {
            warp_control.instance.warp(teleport_position, teleport_obj, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ES.electricity)
        {
            can_use = true;
            teleport_obj = collision.gameObject;
            interact_text_control.instance.text_on("按下F進入");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ES.electricity)
        {
            can_use = false;
            interact_text_control.instance.text_down();
        }
    }
}
