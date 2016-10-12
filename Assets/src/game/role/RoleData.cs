using UnityEngine;
using System.Collections;

/// <summary>
/// 角色数据
/// </summary>
public class RoleData
{
    /// <summary>
    /// 唯一id
    /// </summary>
    public int id;

    /// <summary>
    /// 名称
    /// </summary>
    public string nick;

    private int _hp;
    /// <summary>
    /// 剩余血量
    /// </summary>
    public int hp
    {
        get { return _hp; }
        set { _hp = Mathf.Clamp(value, 0, _hpMax); }
    }

    private int _hpMax;
    /// <summary>
    /// 血量最大值
    /// </summary>
    public int hpMax
    {
        get { return _hpMax; }
        set { _hpMax = value; }
    }
    
    /// <summary>
    /// 血量百分比
    /// </summary>
    public int hpPercent
    {
        get { return Mathf.RoundToInt(100 * _hp / _hpMax); }
    }

    private int _mp;
    /// <summary>
    /// 剩余魔法
    /// </summary>
    public int mp
    {
        get { return _mp; }
        set { _mp = Mathf.Clamp(value, 0, _mpMax); }
    }

    private int _mpMax;
    /// <summary>
    /// 血量最大值
    /// </summary>
    public int mpMax
    {
        get { return _mpMax; }
        set { _mpMax = value; }
    }

    /// <summary>
    /// 魔法百分比
    /// </summary>
    public int mpPercent
    {
        get { return Mathf.RoundToInt(100 * _mp / _mpMax); }
    }

    /// <summary>
    /// 是否已经死亡
    /// </summary>
    public bool dead
    {
        get { return _hp == 0; }
    }


}
