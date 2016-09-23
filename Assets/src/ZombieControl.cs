using UnityEngine;
using System.Collections;


/// <summary>
/// 僵尸控制器
/// </summary>
public class ZombieControl : MonoBehaviour, IRoleControl
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
    private ZombieData data;
    /// <summary>
    /// 移动组件
    /// </summary>
    protected CorePlugMoveByDict movePlug;


    public RoleData roleData
    {
        get { return data; }
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        movePlug = new CorePlugMoveByDict(this, gameObject);
        movePlug.moveSpeed = moveSpeed;
        data = new ZombieData();
    }

    // Update is called once per frame
    void Update ()
    {
        if (movePlug.moving == false)
        {
            movePlug.MoveInit(getMoveDict(), Random.Range(1f, 2f));
        }
        movePlug.OnUpdate();
    }

    /// <summary>
    /// 获取移动方向
    /// </summary>
    /// <returns></returns>
    protected Vector3 getMoveDict()
    {
        switch (Random.Range(1, 8))
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
