using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject ProjectileObject = null;
    public GameObject DetonationObject = null;

    public float detonationLifetime = 1.0f;
    float detonationTime = -1.0f;

    public virtual void Start()
    {
        ProjectileObject.SetActive(true);
        DetonationObject.SetActive(false);
    }
    public void Update()
    {
        if (detonationTime > 0.0f)
        {
            detonationTime -= Time.deltaTime;
            if (detonationLifetime < 0.0f)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            ProjectileObject.SetActive(false);
            DetonationObject.SetActive(true);
            detonationTime = detonationLifetime;
        }
    }

}
