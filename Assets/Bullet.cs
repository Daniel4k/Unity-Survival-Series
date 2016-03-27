using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	
	public void Awake()
	{
		StartCoroutine("Destroy");
	}
	// Use this for initialization
	void Update()
	{
		this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 360);

	}
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(4);
		Destroy(this.gameObject);
	}

}
