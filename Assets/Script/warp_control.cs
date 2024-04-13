using UnityEngine;
using System.Collections;

[DefaultExecutionOrder(0)]
public class warp_control : MonoBehaviour
{
    public static warp_control instance;

    private Camera cma;

    private int cnt = 60;

    private camera_control cma_ctrl;

    private teleport_anime tele_anime;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        cma = GameObject.Find("��v��").GetComponent<Camera>();
        cma_ctrl = GameObject.Find("��v�����׺����ϰ찻����").GetComponent<camera_control>();
        tele_anime = GameObject.Find("�L���ʵe").GetComponent<teleport_anime>();
    }

    private void Update()
    {
        if (cnt < 60)
        {
            cnt++;
        }

        if(cma_ctrl == null && GameObject.Find("��v�����׺����ϰ찻����"))
            cma_ctrl = GameObject.Find("��v�����׺����ϰ찻����").GetComponent<camera_control>();
    }

    public void warp(Vector3 pos, GameObject obj, bool anime)
    {
        StartCoroutine(teleport(pos, obj, anime));
    }

    IEnumerator teleport(Vector3 pos, GameObject obj, bool anime)
    {
        if(anime)
        {
            StartCoroutine(tele_anime.screen_anime());
            yield return new WaitForSeconds(0.5f);
        }
        obj.transform.position = pos;
        cma.transform.position = new Vector3(pos.x, pos.y, -8.0f);
        cma_ctrl.y_new = cma.transform.position.y;//�P�Bcamera_control�o�Ӹ}�����Ѽ�
        cnt = 0;
    }
}
