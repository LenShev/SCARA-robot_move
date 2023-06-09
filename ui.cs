using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ui : MonoBehaviour
{
    public TMP_InputField x_input;
    public TMP_InputField y_input;
    public TMP_InputField z_input;

    public GameObject target;
    
    public void TargetMove()
    {
        float x = float.Parse(x_input.text);
        float y = float.Parse(y_input.text);
        float z = float.Parse(z_input.text);

        float old_z = target.transform.position.z;

        bool high = true;
        bool outside = true;
        bool inside = true;

        if (y > 200)
        {
            high = false;
        }
        else if (y < 0)
        {
            high = false;
        }

        if ((Math.Pow(x, 2) + Math.Pow(z, 2)) > Math.Pow(750, 2))
        {
            outside = false;
        }
        else if ((Math.Pow((Math.Pow((x-150), 2) + Math.Pow((z/6), 2) - 400*x),2)) > (6* Math.Pow(400,2)* (Math.Pow(x, 2) + Math.Pow(z, 2))))
        {
            outside = false;
        }

        if ((Math.Pow(x, 2) + Math.Pow(z, 2) < Math.Pow(274, 2)))
        {
            inside = false;
        }
        if (x==0 && z==0)
        {
            inside = false;
        }

        if (high && outside && inside)
        {
            target.transform.position = new Vector3(x, y, z);
        }
    }
}
