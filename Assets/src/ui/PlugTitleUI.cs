using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 角色头顶UI的控制组件
/// </summary>
public class PlugTitleUI : MonoBehaviour
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    private RoleBase roleCtrl;
    /// <summary>
    /// ui对象
    /// </summary>
    private GameObject ui;
    /// <summary>
    /// 昵称文本
    /// </summary>
    private Text nick;
    /// <summary>
    /// 血量和魔法文本
    /// </summary>
    private Slider hp, mp;
    /// <summary>
    /// 血量和魔法的值
    /// </summary>
    private Text hpValue, mpValue;
    /// <summary>
    /// 缓存当前的值，正常可以通过绑定触发
    /// </summary>
    private int hpCache, mpCache;
    /// <summary>
    /// 初始化
    /// </summary>
    void Start()
    {
        ui = transform.Find("UI").gameObject;
        nick = ui.transform.Find("Name").GetComponent<Text>();
        hp = ui.transform.Find("Hp").GetComponent<Slider>();
        mp = ui.transform.Find("Mp").GetComponent<Slider>();
        hpValue = hp.transform.Find("Value").GetComponent<Text>();
        mpValue = mp.transform.Find("Value").GetComponent<Text>();
        roleCtrl = GetComponent<RoleBase>();
    }
    
    /// <summary>
    /// 1、保证对象一致朝向摄像机
    /// 2、这里在update中更新ui，实际上是不合理的，只是demo环境，暂时就略过了
    /// </summary>
	void Update ()
    {
        ui.transform.rotation = Camera.main.transform.rotation;
        nick.text = roleCtrl.roleData.nick;
        OnChnageHp();
        OnChnageMp();
    }

    private void OnChnageHp()
    {
        if (hpCache == roleCtrl.roleData.hpPercent)
            return;
        hpValue.text = roleCtrl.roleData.hpPercent + "%";
        hpCache = roleCtrl.roleData.hpPercent;
        DOTween.To(() => hp.value, x => hp.value = x, (float)(hpCache * 0.01), 0.8f);
    }

    private void OnChnageMp()
    {
        if (mpCache == roleCtrl.roleData.mpPercent)
            return;
        mpValue.text = roleCtrl.roleData.mpPercent + "%";
        mpCache = roleCtrl.roleData.mpPercent;
        DOTween.To(() => mp.value, x => mp.value = x, (float)(mpCache * 0.01), 0.8f);
    }

}
