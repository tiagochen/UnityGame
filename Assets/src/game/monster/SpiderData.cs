using UnityEngine;
using System.Collections;


/// <summary>
/// 蜘蛛数据
/// </summary>
public class SpiderData : RoleData
{
    public SpiderData()
    {
        nick = "黑寡妇";
        hpMax = 200;
        hp = Random.Range(10, hpMax);
        mp = mpMax = 100;
    }

}
