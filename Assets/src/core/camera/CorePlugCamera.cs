using UnityEngine;
using System.Collections;


/// <summary>
/// 摄像头控制器
/// </summary>
public class CorePlugCamera
{
    public static readonly Vector3 ZERO = Vector3.zero;

    public float speed = 30f;
    public int vecAngleMin = 5;
    public int VecAngleMax = 35;
    public int mouseKey = 1;
    // 所属对象
    private MonoBehaviour owner;
    /// <summary>
    /// 摄像头对象
    /// </summary>
    private Camera camera;
    /// <summary>
    /// 鼠标按下的地址，用于控制摄像头旋转
    /// </summary>
    private Vector3 mouseDownPos;
    /// <summary>
    /// 旋转方向
    /// </summary>
    private int vecDict = 0;
    /// <summary>
    /// 目标角度
    /// </summary>
    private float endVecAngle = 0;


    /// <see cref="CorePlugCamera"/>
    public CorePlugCamera(MonoBehaviour owner, Camera camera)
    {
        this.camera = camera;
        this.owner = owner;
        mouseDownPos = ZERO;
    }
    
    /// <summary>
    /// 触发更新
    /// </summary>
    /// <returns>如果发生涉嫌头移动，那么返回屏幕坐标的距离差</returns>
    public Vector3 OnUpdate()
    {
        if (Input.GetMouseButtonDown(mouseKey))
        {
            mouseDownPos = Input.mousePosition;
            return ZERO;
        }

        if (Input.GetMouseButtonUp(mouseKey))
        {
            mouseDownPos = ZERO;
            return ZERO;
        }

        if (Input.GetMouseButton(mouseKey))
        {
            Vector3 diffPos = mouseDownPos - Input.mousePosition;
            endVecAngle = camera.transform.eulerAngles.x + diffPos.y;
            endVecAngle = Mathf.Clamp(endVecAngle, vecAngleMin, VecAngleMax);
            vecDict = endVecAngle > camera.transform.eulerAngles.x ? 1 : -1;
            mouseDownPos = Input.mousePosition;

            camera.transform.RotateAround(owner.transform.position, Vector3.up, -diffPos.x);
            DoTurn();
            return diffPos;
        }
        return ZERO;
    }

    /// <summary>
    /// 设置旋转
    /// </summary>
    private void DoTurn()
    {
        if (mouseDownPos == ZERO || speed == 0f)
        {
            return;
        }
        float step = vecDict * speed * Time.deltaTime;

        if( (vecDict > 0 && camera.transform.eulerAngles.x + step > endVecAngle ) ||
            (vecDict < 0 && camera.transform.eulerAngles.x + step < endVecAngle ) )
        {
            // 如果重新设置step会发生抖动
            //step = endVecAngle - (myCamera.transform.eulerAngles.x + step);
            return;
        }
        camera.transform.Rotate(step, 0, 0);
    }

}








