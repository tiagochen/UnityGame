using UnityEngine;
using System.Collections;
using System.Text;


/// <summary>
/// 快速打印日志的工具
/// </summary>
public class CLog
{

    public static void L(params System.Object[] argList)
    {
        StringBuilder sb = new StringBuilder();
        foreach (System.Object obj in argList)
        {
            if (obj == null)
            {
                sb.Append("[null]");
            }
            else
            {
                sb.Append(obj.ToString());
            }
            sb.Append("   ");
        }
        Debug.Log(sb.ToString());
    }

    public static void L(params float[] argList)
    {
        StringBuilder sb = new StringBuilder();
        foreach (float obj in argList)
        {
            sb.Append(obj.ToString());
            sb.Append("   ");
        }
        Debug.Log(sb.ToString());
    }


}
