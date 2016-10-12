using System;
using UnityEngine;

/// <summary>
/// 玩家控制器
/// </summary>
public class PlayerControl : RoleBase
{
    /// <summary>
    /// 火焰粒子发射对象
    /// </summary>
    public GameObject rocket;
    /// <summary>
    /// 对象数据
    /// </summary>
    private PlayerData data;
    /// <summary>
    /// 主摄像机
    /// </summary>
    private Camera myCamera;
    /// <summary>
    /// 对象模型
    /// </summary>
    private GameObject model;
    /// <summary>
    /// 移动方向缓存
    /// </summary>
    private Vector3 moveKeyCache;
    /// <summary>
    /// 摄像机组件
    /// </summary>
    private CorePlugCamera cameraPlug;
    /// <summary>
    /// 攻击组件
    /// </summary>
    private PlugFire firePlug;
    /// <summary>
    /// 动画控制器
    /// </summary>
    private Animator animator;
    /// <summary>
    /// 初始化
    /// </summary>
    protected void Start()
    {
        model = transform.FindChild("Model").gameObject;
        myCamera = Camera.main;
        movePlug = new CorePlugMoveByDict(this, model);
        movePlug.moveSpeed = moveSpeed;
        cameraPlug = new CorePlugCamera(this, myCamera);
        firePlug = new PlugFire(this, model, rocket);
        _roleData = data = new PlayerData();
        animator = model.GetComponent<Animator>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    protected void Update()
    {
        UpdateMove();
        cameraPlug.OnUpdate();
        firePlug.OnUpdate();
    }
    
    /// <summary>
    /// 处理移动
    /// </summary>
    private void UpdateMove()
    {
        if(_roleData.dead)
        {
            animator.SetBool("Die", true);
            movePlug.MoveEnd();
            return;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            movePlug.turnAdd(Input.GetAxisRaw("Horizontal"));
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            movePlug.MoveInit(transform.forward * ( Input.GetAxisRaw("Vertical") > 0? 1 : -1 ));
        }
        else
        {
            movePlug.MoveEnd();
        }

        movePlug.OnUpdate();
    }
}
