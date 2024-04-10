using UnityEngine;

public class start_boss_battle : MonoBehaviour
{
    private bool is_activate = false;

    private ona_move ona;

    public GameObject door;

    private void Start()
    {
        ona = GameObject.Find("¼Ú®R").GetComponent<ona_move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!is_activate)
        {
            ona.ona_activate();
            is_activate = true;
            door.SetActive(true);
        }
    }
}
