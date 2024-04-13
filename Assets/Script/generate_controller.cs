using UnityEngine;

[DefaultExecutionOrder(0)]
public class generate_controller : MonoBehaviour
{
    public static generate_controller instance;

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

    private void Awake()
    {
        if (instance == null)
            instance = this;
        SD = GameObject.Find("�s�ɸ��").GetComponent<save_data>();
        generate();
    }

    //�ͦ�����A�ݭn�Ҽ{���ͫ᪫�󪺪��A
    public void generate()
    {
        GameObject rat_token = GameObject.Find("�ѹ��޲z");
        if (rat_token != null)
            Destroy(rat_token);

        GameObject bat_token = GameObject.Find("�����޲z");
        if (bat_token != null)
            Destroy(bat_token);

        GameObject failman_token = GameObject.Find("���ѤH�޲z");
        if (failman_token != null)
            Destroy(failman_token);

        GameObject ona_token = GameObject.Find("�ڮR�޲z");
        if (ona_token != null)
            Destroy(ona_token);

        if (SD.rat)
        {
            GameObject prefab = Instantiate(rat, Vector3.zero, Quaternion.identity);
            prefab.name = rat.name;
        }

        if (SD.bat)
        {
            GameObject prefab = Instantiate(bat, Vector3.zero, Quaternion.identity);
            prefab.name = bat.name;
        }

        if (SD.failman)
        {
            GameObject prefab = Instantiate(failman, Vector3.zero, Quaternion.identity);
            prefab.name = failman.name;
        }

        if (SD.ona)
        {
            GameObject prefab = Instantiate(ona, Vector3.zero, Quaternion.identity);
            prefab.name = ona.name;
        }

        eletricity.GetComponent<electrical_switch>().electricity = SD.eletricity;
        if (!SD.eletricity)
        {
            eletricity.GetComponent<SpriteRenderer>().sprite = eletricity.GetComponent<electrical_switch>().no_charge;
            eletricity.GetComponent<electrical_switch>().active = false;
        }
        else
            eletricity.GetComponent<SpriteRenderer>().sprite = eletricity.GetComponent<electrical_switch>().full_charge;

        eletricity_room_wall.SetActive(SD.eletricity_room_wall);

        damaged_bridge.SetActive(SD.damaged_bridge);

        boss_front_door.SetActive(SD.boss_front_door);

        boss_back_door.SetActive(SD.boss_back_door);
    }
}
