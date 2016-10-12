using UnityEngine;
using System.Collections;


/// <summary>
/// 爆炸效果的粒子控制器
/// 由于网络下载的是旧的粒子效果，所以这里就先用旧的控制方法
/// </summary>
public class Explosion : MonoBehaviour
{
    /// <summary>
    /// 经过时间，正常情况不应该这样用
    /// </summary>
    private float passTime;


    void Start()
    {
        passTime = 0;
    }


    void Update()
    {
        passTime += Time.deltaTime;
        if( passTime >= 0.5)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform child = transform.GetChild(i);
                if (child.GetComponent<ParticleEmitter>())
                {
                    child.GetComponent<ParticleEmitter>().emit = false;
                    child.GetComponent<ParticleAnimator>().autodestruct = true;
                }
            }
            Destroy(gameObject);
        }
    }
    
    
}
