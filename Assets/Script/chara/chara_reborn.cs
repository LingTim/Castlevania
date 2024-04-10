using UnityEngine;

public class chara_reborn : MonoBehaviour
{
    public GameObject chara_prefab;

    private save_data SD;

    public Canvas death_canvas;

    void Start()
    {
        SD = GameObject.Find("¶s¿…∏ÍÆ∆").GetComponent<save_data>();
    }

    public void born_chara()
    {
        Instantiate(chara_prefab, SD.reborn_point, Quaternion.identity);
        death_canvas.enabled = false;
    }
}
