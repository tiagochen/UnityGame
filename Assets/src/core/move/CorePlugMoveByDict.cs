﻿using UnityEngine;
using System.Collections;


/// <summary>
/// 移动组件：通过方向控制对象
/// 
/// Author: Tiago
/// </summary>
public class CorePlugMoveByDict
{
    /// <summary>
    /// 0坐标，用于优化计算
    /// </summary>
    private static readonly Vector3 ZERO = Vector3.zero;
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
    /// 角色控制器
    /// </summary>
    private CharacterController cc;
    /// <summary>
    /// 移动的步长,方向
    /// </summary>
    private Vector3 step, direction;
    /// <summary>
    /// 移动的限制时间
    /// </summary>
    private float timeLimit;

    
    /// <see cref="CorePlugMoveByDict"/>
    /// <param name="owner">所属对象</param>
    /// <param name="model">动画组件</param>
    public CorePlugMoveByDict(MonoBehaviour owner, GameObject model)
    {
        this.owner = owner;
        this.model = model ? model : owner.gameObject;
        this.animator = model.GetComponent<Animator>();
        cc = owner.GetComponent<CharacterController>();
        direction = ZERO;
        timeLimit = float.NaN;
    }

    /// <summary>
    /// 移动初始化
    /// </summary>
    /// <param name="dict">目标位置</param>
    /// <param name="moveTime">移动的限制时间</param>
    public void MoveInit(Vector3 dict, float moveTime = float.NaN)
    {
        if (dict == ZERO)
            return;
        direction = owner.transform.TransformDirection(dict);
        step = direction * moveSpeed;
        animator.SetBool("Walk", true);
        model.transform.LookAt(owner.transform.position + step);
        timeLimit = moveTime;
    }

    /// <summary>
    /// 触发update，继续移动
    /// </summary>
    public void OnUpdate()
    {
        if (direction == ZERO)
            return;
        float deltaTime = Time.deltaTime;

        if(timeLimit != float.NaN)
        {
            float temp = timeLimit - deltaTime;

            if ( Mathf.Max(0, temp)  == 0 )
            {
                deltaTime = timeLimit;
                timeLimit = 0;
            }
            else
            {
                timeLimit = temp;
            }
        }

        step.y = -300 * deltaTime;
        cc.Move(step * deltaTime);
        if (timeLimit == 0)
        {
            MoveEnd();
        }
    }


    /// <summary>
    /// 移动结束
    /// </summary>
    public void MoveEnd()
    {
        direction = ZERO;
        animator.SetBool("Walk", false);
    }

    /// <summary>
    /// 是否正在移动中
    /// </summary>
    public bool moving
    {
        get { return direction != ZERO; }
    }

}
