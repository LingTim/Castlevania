using UnityEngine;

[DefaultExecutionOrder(0)]
public class warp_control : MonoBehaviour
{
    public static warp_control instance;

    private Camera cma;

    private int cnt = 60;

    private camera_control cma_ctrl;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        cma = GameObject.Find("��v��").GetComponent<Camera>();
        cma_ctrl = GameObject.Find("��v�����׺����ϰ찻����").GetComponent<camera_control>();
    }

    private void Update()
    {
        if (cnt < 60)
        {
            cnt++;
        }
    }

    public void warp(Vector3 pos, GameObject obj)
    {   
        obj.transform.position = pos;
        cma.transform.position = new Vector3(pos.x, pos.y, -8.0f);
        cma_ctrl.y_new = cma.transform.position.y;//�P�Bcamera_control�o�Ӹ}�����Ѽ�
        cnt = 0;
    }
}
