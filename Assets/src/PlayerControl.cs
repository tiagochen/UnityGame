using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Camera myCamera;
    public GameObject model;
    public float moveSpeed = 1.8f;

    /// <summary>
    /// 移动组件
    /// </summary>
    private CorePlugMoveByDict movePlug;
    /// <summary>
    /// 移动方向换成
    /// </summary>
    private Vector3 moveKeyCache;


    void Start()
    {
        movePlug = new CorePlugMoveByDict(this, model);
        movePlug.moveSpeed = 1.8f;
        moveKeyCache = Vector3.zero;
    }


    void Update()
    {
        DoMove();
    }


    /// <summary>
    /// 处理移动
    /// </summary>
    private void DoMove()
    {
        moveKeyCache = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical")
        );

        if (moveKeyCache == Vector3.zero)
        {
            movePlug.MoveEnd();
            return;
        }

        movePlug.MoveInit(moveKeyCache);
        movePlug.OnUpdate();
        myCamera.transform.LookAt(model.transform.position);
    }

}
