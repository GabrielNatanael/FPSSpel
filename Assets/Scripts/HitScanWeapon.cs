using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanWeapon : Weapon
{
    [SerializeField] LayerMask layersToIgnore = new LayerMask();

    private void Start()
    {
        
    }
    public override void Fire()
    {
        if(!base.Fire())
        {
            return false;
        }
        base.Fire();

        return true;
    }
}
