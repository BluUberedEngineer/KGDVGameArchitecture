using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun
{
    public GameObject gunObject;
    public GameObject bulletPrefab;

    public int damage;
    public float fireRate;

    public float reloadTime;
    public bool isReloading;

    public virtual void Reload()
    {

    }

    public virtual void Shoot()
    {
        //shoot bullet
        EventManager<Gun>.Invoke(EventType.GUN_SHOOT, this);
        GameObject bullet = GameObject.Instantiate(bulletPrefab, gunObject.transform.position, gunObject.transform.rotation);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //vervang dit ff met dedicated input manager
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
