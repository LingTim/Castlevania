using UnityEngine;

public class chara_reborn : MonoBehaviour
{
    private Camera cma;

    public GameObject chara_prefab;

    private save_data SD;

    private camera_control cma_ctrl;

    public GameObject death_canvas;

    public AudioClip normal_bgm;

    void Start()
    {
        SD = GameObject.Find("存檔資料").GetComponent<save_data>();
    }

    public void born_chara()
    {
        GameObject token = Instantiate(chara_prefab, SD.reborn_point, Quaternion.identity);
        token.name = chara_prefab.name;

        cma = GameObject.Find("攝影機").GetComponent<Camera>();
        cma_ctrl = GameObject.Find("攝影機高度維持區域偵測器").GetComponent<camera_control>();
        cma.transform.position = new Vector3(SD.reborn_point.x, SD.reborn_point.y, -8.0f);
        cma_ctrl.y_new = cma.transform.position.y;//同步camera_control這個腳本的參數

        generate_controller.instance.generate();
        death_canvas.SetActive(false);

        GameObject.Find("歐娜頭像背景").GetComponent<CanvasGroup>().alpha = 0.0f;
        GameObject.Find("歐娜血條").GetComponent<CanvasGroup>().alpha = 0.0f;

        GameObject.Find("BGM").GetComponent<AudioSource>().clip = normal_bgm;
        GameObject.Find("BGM").GetComponent<AudioSource>().Play();
    }
}
