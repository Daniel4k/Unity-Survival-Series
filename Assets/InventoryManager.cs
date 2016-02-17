using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour {
	public int NextSlot = 0;
	public GameObject FullText;
	public List<GameObject> Items = new List<GameObject>();
	public void Update()
	{
					if(GameObject.Find("Slot" + "0").gameObject.GetComponent<Slot>().isAvailable == true)
						{
							FullText.SetActive(false);
						}	
		if(NextSlot == 12)
			{
					NextSlot = 0;
			}
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 10))
			{
				if(hit.transform.gameObject.tag == "Item")
				{
					if(GameObject.Find("Slot" + "11").gameObject.GetComponent<Slot>().isAvailable == false && GameObject.Find("Slot" + "1").gameObject.GetComponent<Slot>().isAvailable == false)
						{
							FullText.SetActive(true);
						}else
						{
					if(GameObject.Find("Slot" + NextSlot).gameObject.GetComponent<Slot>().isAvailable)
					{
						Items.Add(hit.transform.gameObject);
						GameObject.Find("Slot" + NextSlot).gameObject.GetComponent<Slot>().SlotFunction(hit.transform.gameObject.GetComponent<Item>().Image, hit.transform.gameObject.GetComponent<Item>().Weight);
						hit.transform.parent = this.transform;
						hit.transform.position = this.transform.position;
						hit.transform.gameObject.SetActive(false);
					}
					else
					{
						NextSlot += 1;
					}
				}
				}
			}
		}
	}
}
