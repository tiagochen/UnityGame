using UnityEngine;
using System.Collections;

/// <summary>
/// 蜘蛛控制器
/// </summary>
public class SpiderControl : RoleBase
{
    public GameObject player;
    /// <summary>
    /// 移动概率
    /// </summary>
    public int rate = 10;
    /// <summary>
    /// 动画对象
    /// </summary>
    private Animator animator;
    /// <summary>
    /// 数据
    /// </summary>
    private SpiderData data;
    /// <summary>
    /// 玩家控制器
    /// </summary>
    private PlayerControl playerCtl;


    void Start ()
    {
        animator = GetComponent<Animator>();
        movePlug = new CorePlugMoveByDict(this, gameObject);
        movePlug.moveSpeed = _moveSpeed;
        _roleData = data = new SpiderData();
        playerCtl = player.GetComponent<PlayerControl>();
    }
	
	void Update ()
    {
        if (_roleData.dead)
        {
            animator.SetBool("Die", true);
            movePlug.MoveEnd();
            return;
        }
        UpdateMove();
        UpdateDie();
    }

    /// <summary>
    /// 更新移动
    /// </summary>
    private void UpdateMove()
    {
        if (movePlug.moving == false && data.dead == false )
        {
            if (rate > 0 && Random.Range(1, 10000) <= rate)
            {
                movePlug.turnAdd(Random.Range(0, 360));
                movePlug.MoveInit(transform.forward, Random.Range(1f, 2f));
            }
        }
        movePlug.OnUpdate();
    }

    /// <summary>
    /// 装死AI
    /// </summary>
    private void UpdateDie()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 5 )
        {
            animator.SetBool("Die", true);
            movePlug.MoveEnd();
        }
        else
        {
            animator.SetBool("Die", false);
        }
    }
}
