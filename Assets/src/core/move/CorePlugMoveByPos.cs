using UnityEngine;
using System.Collections;

/// <summary>
/// 移动组件
/// </summary>
public class CorePlugMove
{
    /// <summary>
    /// 0坐标，用于优化计算
    /// </summary>
    private static Vector3 zero = Vector3.zero;
    /// <summary>
    /// 移动速度
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// 目标哦游戏对象
    /// </summary>
    private MonoBehaviour owner;
    /// <summary>
    /// 模型组件
    /// </summary>
    private GameObject model;
    /// <summary>
    /// 动画组件
    /// </summary>
    private Animator animator;
    /// <summary>
    /// 移动的目标位置和开始位置
    /// </summary>
    private Vector3 targetPos, startPos;
    /// <summary>
    /// 移动开始时间、移动距离
    /// </summary>
    private float startTime, moveDist;
    /// <summary>
    /// 地形对象
    /// </summary>
    private Terrain terrain;

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="owner">所属对象</param>
    /// <param name="model">动画组件</param>
    public CorePlugMove(MonoBehaviour owner, GameObject model = null)
    {
        this.owner = owner;
        this.model = model? model : owner.gameObject;
        this.animator = model.GetComponent<Animator>();
        targetPos = zero;
    }

    /// <summary>
    /// 移动初始化
    /// </summary>
    /// <param name="targetPos">目标位置</param>
    public void MoveInit( Vector3 targetPos )
    {
        this.targetPos = targetPos;
        startPos = owner.transform.position;
        startTime = Time.time;
        moveDist = Vector3.Distance(startPos, targetPos);
        animator.SetBool("Walk", true);
        model.transform.LookAt(targetPos);
    }

    /// <summary>
    /// 触发update，继续移动
    /// </summary>
    public void OnUpdate()
    {
        if (targetPos == zero)
            return;

        float distCovered = (Time.time - startTime) * moveSpeed;
        float fracJourney = System.Math.Min(1, distCovered / moveDist);

        owner.transform.position = Vector3.Lerp(startPos, targetPos, fracJourney);
        if (owner.transform.position == targetPos)
        {
            MoveEnd();
        }
    }

    /// <summary>
    /// 移动结束
    /// </summary>
    public void MoveEnd()
    {
        targetPos = zero;
        animator.SetBool("Walk", false);
    }

    /// <summary>
    /// 是否正在移动中
    /// </summary>
    public bool moving
    {
        get { return targetPos != zero; }
    }


    /// <summary>
    /// 获取鼠标点击位置
    /// </summary>
    //private Vector3 GetClickPos()
    //{
    //    Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit) == true)
    //    {
    //        Vector3 pos = hit.point;
    //        pos.y = 0;
    //        return pos;
    //    }
    //    return transform.position;
    //}
}
