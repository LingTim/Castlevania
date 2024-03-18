using UnityEngine;

public class camera_control : MonoBehaviour
{
    private GameObject character;

    private Camera cma;

    private bool bind = false;

    public float y_binding;
    public float y_new;

    private void Start()
    {
        character = GameObject.Find("�D��");
        cma = GameObject.Find("��v��").GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if(!bind)
            y_binding = transform.position.y;

        if (cma.transform.position.y < y_binding)//�H������v�������p�A�԰���v��
        {
            if (transform.parent.GetComponent<Rigidbody2D>().velocity.y > 20.0f || transform.position.y > cma.transform.position.y + 10.0f)
                y_new = cma.transform.position.y + 1f;
            else if (transform.parent.GetComponent<Rigidbody2D>().velocity.y > 10.0f || transform.position.y > cma.transform.position.y + 5.0f)
                y_new = cma.transform.position.y + 0.3f;
            else
                y_new = cma.transform.position.y + 0.1f;
            if (y_new > y_binding)
                y_new = y_binding;
        }
        else if(cma.transform.position.y > y_binding)//�H�C����v�������p�A�ԧC��v��
        {
            if(transform.parent.GetComponent<Rigidbody2D>().velocity.y < -20.0f || transform.position.y < cma.transform.position.y - 10.0f)
                y_new = cma.transform.position.y - 1f;
            else if (transform.parent.GetComponent<Rigidbody2D>().velocity.y < -10.0f || transform.position.y < cma.transform.position.y - 5.0f)
                y_new = cma.transform.position.y - 0.3f;
            else
                y_new = cma.transform.position.y - 0.1f;
            if (y_new < y_binding)
                y_new = y_binding;
        }

        cma.transform.position = new Vector3(transform.position.x, y_new, cma.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MainCamera")
        {
            y_binding = collision.transform.position.y;
            bind = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            bind = false;
        }
    }
}
