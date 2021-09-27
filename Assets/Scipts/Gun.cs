using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    public GameObject bulletPrefab;

    public int damage;
    public float fireRate;
    private float shootPower = 6;

    private int magSize = 6;
    private int Ammo;
    public float reloadTime = 1f;
    public bool isReloading;

    public virtual IEnumerator Reload()
    {
        //do reloading stuff
        yield return new WaitForSeconds(reloadTime);
        Ammo = magSize;
    }

    public virtual void Shoot(GameObject gunObject)
    {
        if(Ammo > 0)
        {
            //shoot bullet
            GameObject bullet = GameObject.Instantiate(bulletPrefab, gunObject.transform.position, gunObject.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shootPower, ForceMode.Impulse);
            Debug.Log("gun shot");
            Ammo--;
        }

    }

    // Start is called before the first frame update
    void Awake()
    {
        Ammo = magSize;
        bulletPrefab = Resources.Load("BulletPrefab") as GameObject;
        //EventManager.Subscribe(EventType.GUN_SHOOT, Shoot);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
