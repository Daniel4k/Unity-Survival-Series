using UnityEngine;
using System.Collections;

public class OffOnButton : MonoBehaviour {

	private int Trigger = 0;
	public void Update()
	{
	if(Input.GetKeyDown(KeyCode.Q))
	{
		
		if(Trigger == 0)
		{
	 	this.transform.position = new Vector3(this.transform.position.x * -1, this.transform.position.y ,this.transform.position.z );
		 Trigger = 1;
		}
		if(Trigger == 1)
		{
	 	this.transform.position = new Vector3(this.transform.position.x * 1, this.transform.position.y ,this.transform.position.z );
		 Trigger = 0;
		}
	}

}

}
