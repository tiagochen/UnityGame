using UnityEngine;
using System.Collections;


/// <summary>
/// 玩家数据
/// </summary>
public class PlayerData : RoleData
{
    public PlayerData()
    {
        nick = "我是谁";
        hp = hpMax = 10000;
        mp = mpMax = 100;
    }
}
