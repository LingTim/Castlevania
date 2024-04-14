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
        SD = GameObject.Find("�s�ɸ��").GetComponent<save_data>();
    }

    public void born_chara()
    {
        GameObject token = Instantiate(chara_prefab, SD.reborn_point, Quaternion.identity);
        token.name = chara_prefab.name;

        cma = GameObject.Find("��v��").GetComponent<Camera>();
        cma_ctrl = GameObject.Find("��v�����׺����ϰ찻����").GetComponent<camera_control>();
        cma.transform.position = new Vector3(SD.reborn_point.x, SD.reborn_point.y, -8.0f);
        cma_ctrl.y_new = cma.transform.position.y;//�P�Bcamera_control�o�Ӹ}�����Ѽ�

        generate_controller.instance.generate();
        death_canvas.SetActive(false);

        GameObject.Find("�ڮR�Y���I��").GetComponent<CanvasGroup>().alpha = 0.0f;
        GameObject.Find("�ڮR���").GetComponent<CanvasGroup>().alpha = 0.0f;

        GameObject.Find("BGM").GetComponent<AudioSource>().clip = normal_bgm;
        GameObject.Find("BGM").GetComponent<AudioSource>().Play();
    }
}
