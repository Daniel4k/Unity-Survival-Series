using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour {
	public int NextSlot = 1;
	public List<GameObject> Items = new List<GameObject>();
	public void Update()
	{

		if(Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100))
			{
				if(hit.transform.gameObject.tag == "Item")
				{
					Items.Add(hit.transform.gameObject);
					GameObject.Find("Slot" + NextSlot).gameObject.GetComponent<Slot>().SlotFunction(hit.transform.gameObject.GetComponent<Item>().Image, hit.transform.gameObject.GetComponent<Item>().Weight);
					hit.transform.parent = this.transform;
					hit.transform.position = this.transform.position;
					hit.transform.gameObject.SetActive(false);
				}
			}



		}
	}
}
