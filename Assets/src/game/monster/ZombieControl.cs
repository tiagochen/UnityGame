using UnityEngine;
using System.Collections;


/// <summary>
/// 僵尸控制器
/// </summary>
public class ZombieControl : RoleBase
{
    public GameObject player;
    
    /// <summary>
    /// 动画对象
    /// </summary>
    private Animator animator;
    /// <summary>
    /// 数据
    /// </summary>
    private ZombieData data;
    /// <summary>
    /// 是否处于危险状态
    /// </summary>
    private bool inCrazy;
    /// <summary>
    /// 玩家控制器
    /// </summary>
    private PlayerControl playerCtl;

    void Start()
    {
        inCrazy = false;
        animator = GetComponent<Animator>();
        movePlug = new CorePlugMoveByDict(this, gameObject);
        movePlug.moveSpeed = _moveSpeed;
        _roleData = data = new ZombieData();
        playerCtl = player.GetComponent<PlayerControl>();
    }

    void Update ()
    {
        if (_roleData.dead)
        {
            animator.SetBool("Die", true);
            animator.Stop();
            movePlug.MoveEnd();
            return;
        }
        UpdateCrazyState();
        UpdateMove();
        if (Vector3.Distance(player.transform.position, transform.position) < 4)
        {
            playerCtl.roleData.hp -= 1;
        }
    }

    /// <summary>
    /// 更新移动
    /// </summary>
    private void UpdateMove()
    {
        if (movePlug.moving == false && data.dead == false)
        {
            if (inCrazy)
            {
                transform.LookAt(player.transform);
            }
            else
            {
                movePlug.turnAdd(Random.Range(0, 360));
            }
            movePlug.MoveInit(transform.forward, Random.Range(1f, 2f));
        }
        movePlug.OnUpdate();
    }


    /// <summary>
    /// 更新疯狂状态
    /// </summary>
    private void UpdateCrazyState( )
    {
        bool value = Vector3.Distance(player.transform.position, transform.position) < 15;
        if (playerCtl.roleData.dead)
            value = false;

        if (value == inCrazy)
        {
            return;
        }
        inCrazy = value;
        if(inCrazy)
        {
            animator.speed = 5;
            movePlug.moveSpeed = moveSpeed * 6;
            return;
        }

        animator.speed = 1;
        movePlug.moveSpeed = moveSpeed * 1;
    }

}
