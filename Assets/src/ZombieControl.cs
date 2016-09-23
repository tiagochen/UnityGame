using UnityEngine;
using System.Collections;


/// <summary>
/// 僵尸控制器
/// </summary>
public class ZombieControl : SpiderControl
{
    
	
	// Update is called once per frame
	void Update ()
    {
        //if(movePlug.moving == false)
        //       movePlug.MoveInit(getMovePos());
        //   movePlug.OnUpdate();

        if (movePlug.moving == false)
        {
                movePlug.MoveInit(getMoveDict(), Random.Range(1f, 2f));
        }
        movePlug.OnUpdate();
    }
}
