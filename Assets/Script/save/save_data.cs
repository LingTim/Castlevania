using UnityEngine;

public class save_data : MonoBehaviour
{
    /*
    1.重生位置
    2.老鼠
    3.蝙蝠
    4.失敗人
    5.歐娜
    6.電力
    7.賭塞電力室的牆
    8.破碎的橋
    9.BOSS前門
    10.BOSS後門
    */

    public Vector3 reborn_point = new Vector3(38.5f, -0.735f, 0);
    public bool rat = true;
    public bool bat = true;
    public bool failman = true;
    public bool ona = true;
    public bool eletricity = false;
    public bool eletricity_room_wall = false;
    public bool damaged_bridge = true;
    public bool boss_front_door = true;
    public bool boss_back_door = true;
}
