using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject Bullet;
	public GameObject BulletPlace;
	public void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	public void Shoot()
	{
		Instantiate(Bullet, BulletPlace.transform.position, BulletPlace.transform.rotation);
	}	
}
