using UnityEngine;
using System.Collections;


/// <summary>
/// 僵尸数据
/// </summary>
public class ZombieData : RoleData
{
    public ZombieData()
    {
        nick = "丧尸";
        hpMax = 200;
        hp = Random.Range(10, hpMax);
        mp = mpMax = 200;
    }
}
