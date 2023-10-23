using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int ammunition;
    public virtual void Fire()
    {
        if (ammunition < 1)
        {

        }
    }
}
