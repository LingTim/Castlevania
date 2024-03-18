using UnityEngine;

public class active_control : MonoBehaviour
{
    private bool summon = false;

    private int child_count;

    private GameObject[] child;

    private void Start()
    {
        child_count = transform.childCount;

        child = new GameObject[child_count];

        for (int i = 0; i < child_count; i++)
        {
            child[i] = transform.GetChild(i).gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !summon)
        {
            for(int i = 0;i < child_count;i++)
            {
                child[i].SetActive(true);
            }
            summon = true;
        }
    }
}
