using UnityEngine;
using System.Collections;

/**
 * 蜘蛛控制器
 */
public class SpiderControl : MonoBehaviour, IRoleControl
{
    public GameObject player;
    public int moveRange = 5;
    public float moveSpeed = 1.8f;
    public int patrol = 10;
    /// <summary>
    /// 动画对象
    /// </summary>
    private Animator animator;
    /// <summary>
    /// 数据
    /// </summary>
    private SpiderData data;
    /// <summary>
    /// 移动组件
    /// </summary>
    protected CorePlugMoveByDict movePlug;

    public RoleData roleData
    {
        get { return data; }
    }


    void Start ()
    {
        animator = GetComponent<Animator>();
        movePlug = new CorePlugMoveByDict(this, gameObject);
        movePlug.moveSpeed = moveSpeed;
        data = new SpiderData();
    }
	
	void Update ()
    {
        if (movePlug.moving == false && data.hp > 0)
        {
            if (patrol > 0 && Random.Range(1, 10000) <= patrol)
                movePlug.MoveInit(getMoveDict(), Random.Range(1f, 2f) );
        }
        movePlug.OnUpdate();

        if(Vector3.Distance(player.transform.position, transform.position) < 5 )
        {
            data.hp = 0;
            animator.SetBool("Die", true);
            movePlug.MoveEnd();
        }
        else
        {
            data.hp = 100;
            animator.SetBool("Die", false);
        }
    }

    /// <summary>
    /// 获取移动方向
    /// </summary>
    /// <returns></returns>
    protected Vector3 getMoveDict()
    {
        switch(Random.Range(1, 8))
        {
            case 1: return Vector3.forward;
            case 2: return Vector3.back;
            case 3: return Vector3.left;
            case 4: return Vector3.right;
            case 5: return Vector3.forward + Vector3.left;
            case 6: return Vector3.forward + Vector3.right;
            case 7: return Vector3.back + Vector3.left;
            case 8: return Vector3.back + Vector3.right;
        }
        return Vector3.forward;
    }

}
