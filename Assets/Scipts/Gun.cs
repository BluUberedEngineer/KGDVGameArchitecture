using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    public GameObject bulletPrefab;

    public int damage;
    public float fireRate;
    private float shootPower = 6;

    public float reloadTime;
    public bool isReloading;

    public virtual void Reload()
    {
        //do reloading stuff
    }

    public virtual void Shoot(GameObject gunObject)
    {
        //shoot bullet
        GameObject bullet = GameObject.Instantiate(Resources.Load("BulletPrefab") as GameObject, gunObject.transform.position, gunObject.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shootPower, ForceMode.Impulse);
        Debug.Log("gun shot");
    }

    // Start is called before the first frame update
    void Awake()
    {
        //bulletPrefab = Resources.Load("Assets/Resources/BulletPrefab") as GameObject;
        //EventManager.Subscribe(EventType.GUN_SHOOT, Shoot);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
