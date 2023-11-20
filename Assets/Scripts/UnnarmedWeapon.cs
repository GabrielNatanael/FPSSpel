using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnnarmedWeapon : Weapon
{
    public override bool Fire()
    {
        //if (!base.Fire())
        //{
        //    return false;
        //}
        return true;
    }
}
