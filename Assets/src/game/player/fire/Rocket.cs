using UnityEngine;
using System.Collections;

/// <summary>
/// 火焰发射控制器
/// 由于网络下载的是旧的粒子效果，所以这里就先用旧的控制方法
/// </summary>
public class Rocket : MonoBehaviour
{
    public float speed = 60f;
    public GameObject explosion;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.forward, out hit, speed * Time.deltaTime))
        {
            GameObject target = hit.collider.gameObject;
            RoleBase role = target.GetComponent<RoleBase>();

            if(role == null)
            {
                DetachEmitters();
                boom(hit);
                return;
            }

            if (role != null && role.roleData.dead == false)
            {
                DetachEmitters();
                boom(hit);
                role.roleData.hp = 0;
                return;
            }
        }
    }

    private void boom( RaycastHit hit )
    {
        if (explosion)
        {
            Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }


    /// <summary>
    /// 销毁发射器
    /// </summary>
    private void DetachEmitters()
    {
        for( int i = 0; i < transform.childCount; ++i )
        {
            Transform child = transform.GetChild(i);
            if(child.GetComponent<ParticleEmitter>())
            {
                child.parent = null;
                child.GetComponent< ParticleEmitter > ().emit = false;
                child.GetComponent< ParticleAnimator>().autodestruct = true;
            }
        }
        Destroy(gameObject);
    }

}
