using UnityEngine;
using System.Collections;


/// <summary>
/// 火焰发射控制器
/// </summary>
public class PlugFire
{
    /// <summary>
    /// 所属者
    /// </summary>
    private PlayerControl owner;
    /// <summary>
    /// 对象模型
    /// </summary>
    private GameObject model;
    /// <summary>
    /// 火焰粒子发射对象
    /// </summary>
    public GameObject rocket;
    /// <summary>
    /// 模型
    /// </summary>
    private Animator animator;
    /// <summary>
    /// 发射时间
    /// </summary>
    private float fireTime;

    /// <summary>
    /// 构造 
    /// </summary>
    public PlugFire(PlayerControl owner, GameObject model, GameObject rocket)
    {
        this.owner = owner;
        this.model = model;
        this.rocket = rocket;
        animator = model.GetComponent<Animator>();
        fireTime = float.PositiveInfinity;
    }

    /// <summary>
    ///  触发更新
    /// </summary>
    public void OnUpdate()
    {
        if (owner.roleData.dead)
            return;
        DoFire();
        if (Input.GetButtonUp("Fire1") && rocket != null)
        {
            model.GetComponent<Animator>().SetBool("Fire", true);
            fireTime = 1f;
            return;
        }
        // Fire播放完成后会自动退出，所以这里要保证条件还原
        model.GetComponent<Animator>().SetBool("Fire", false);
    }

    /// <summary>
    /// 发射火焰
    /// </summary>
    private void DoFire()
    {
        if (fireTime == float.PositiveInfinity)
            return;
        fireTime -= Time.deltaTime;
        if (fireTime > 0)
            return;
        fireTime = float.PositiveInfinity;
        Transform tf = model.transform;
        Object.Instantiate(
            rocket,
            tf.position + new Vector3(0, 1f, 0) + tf.forward.normalized * 1 + tf.right,
            tf.rotation
       );
    }

}
