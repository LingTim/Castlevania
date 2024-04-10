using UnityEngine;

public class generate_controller : MonoBehaviour
{
    public GameObject rat;
    public GameObject bat;
    public GameObject failman;
    public GameObject ona;
    public GameObject eletricity;
    public GameObject eletricity_room_wall;
    public GameObject damaged_bridge;
    public GameObject boss_front_door;
    public GameObject boss_back_door;

    private save_data SD;

    private void Start()
    {
        SD = GameObject.Find("�s�ɸ��").GetComponent<save_data>();
        generate();
    }

    //�ͦ�����A�ݭn�Ҽ{���ͫ᪫�󪺪��A
    public void generate()
    {
        if(SD.rat)
        {
            GameObject token = GameObject.Find("�ѹ��޲z");
            if (token != null)
                Destroy(token);
            Instantiate(rat, Vector3.zero, Quaternion.identity);
        }

        if (SD.bat)
        {
            GameObject token = GameObject.Find("�����޲z");
            if (token != null)
                Destroy(token);
            Instantiate(bat, Vector3.zero, Quaternion.identity);
        }

        if (SD.failman)
        {
            GameObject token = GameObject.Find("���ѤH�޲z");
            if (token != null)
                Destroy(token);
            Instantiate(failman, Vector3.zero, Quaternion.identity);
        }

        if (SD.ona)
        {
            GameObject token = GameObject.Find("�ڮR�޲z");
            if (token != null)
                Destroy(token);
            Instantiate(ona, Vector3.zero, Quaternion.identity);
        }

        eletricity.GetComponent<electrical_switch>().electricity = SD.eletricity;

        eletricity_room_wall.SetActive(SD.eletricity_room_wall);

        damaged_bridge.SetActive(SD.damaged_bridge);

        boss_front_door.SetActive(SD.boss_front_door);

        boss_back_door.SetActive(SD.boss_back_door);
    }
}
