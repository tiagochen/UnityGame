using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IRoleControl
{
    public Camera myCamera;
    public GameObject model;
    public float moveSpeed = 1.8f;

    private PlayerData data;
    /// <summary>
    /// 移动组件
    /// </summary>
    private CorePlugMoveByDict movePlug;
    /// <summary>
    /// 移动方向换成
    /// </summary>
    private Vector3 moveKeyCache;
    /// <summary>
    /// 鼠标按下的地址，用于控制摄像头旋转
    /// </summary>
    private Vector3 mouseDownPos;

    public RoleData roleData
    {
        get { return data; }
    }

    void Start()
    {
        movePlug = new CorePlugMoveByDict(this, model);
        movePlug.moveSpeed = 1.8f;
        moveKeyCache = Vector3.zero;
        data = new PlayerData();
    }


    void Update()
    {
        DoMove();
        CameraRotate();
    }

    /// <summary>
    /// 控制摄像头旋转
    /// </summary>
    void CameraRotate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouseDownPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            myCamera.transform.RotateAround(transform.position, Vector3.up, (Input.mousePosition - mouseDownPos).x);
            mouseDownPos = Input.mousePosition;
        }
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
        //myCamera.transform.LookAt(model.transform.position);
    }

}
