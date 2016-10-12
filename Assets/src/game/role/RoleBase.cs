using UnityEngine;
using System.Collections;


/// <summary>
/// 角色基类
/// 
/// Author Tiago
/// </summary>
public class RoleBase : MonoBehaviour
{
    /// <summary>
    /// 移动组件
    /// </summary>
    protected CorePlugMoveByDict movePlug;
    /// <summary>
    /// 移动速度
    /// </summary>
    [SerializeField, SetProperty("moveSpeed")]
    protected float _moveSpeed = 1.8f;
    /// <summary>
    /// 角色数据
    /// </summary>
    protected RoleData _roleData;


    /// <see cref="_moveSpeed"/>
    public float moveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; if (movePlug != null) movePlug.moveSpeed = _moveSpeed; }
    }

    /// <see cref="_roleData"/>
    public RoleData roleData
    {
        get { return _roleData; }
    }



}
