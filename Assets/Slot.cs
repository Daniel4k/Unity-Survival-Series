using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Slot : MonoBehaviour {


	public Sprite Icon;
	public Sprite Origanal;
	public int Number;
	public int Weight;
	public bool isAvailable = true;
	public bool isSelected;
	//public Sprite SlectedSprite;



	public void SlotSelected()
	{
		if(isSelected == true)
		{
			this.GetComponent<Image>().color = Color.white;
			isSelected = false;
		}else
		{
				this.GetComponent<Image>().color = Color.black;
				isSelected = true;
		}
	}

	public void UseItem()
	{
		GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items[Number].gameObject.SetActive(true);
		GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items[Number].gameObject.GetComponent<Item>().Use();
		Slot[] slots = FindObjectsOfType(typeof(Slot)) as Slot[];
		foreach(Slot slot in slots)
		{
			if(slot.Number != 0)
			{
				slot.Number -= 1;
			}
		}
			this.gameObject.GetComponent<Image>().overrideSprite = Origanal;
			GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items.RemoveAt(Number);
			isAvailable = true;
		}
	
	public void Update()
	{
		if(isSelected == true)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				isSelected = false;
				this.GetComponent<Image>().color = Color.white;
				RemoveItem();
			}
			if(Input.GetKeyDown(KeyCode.U))
			{
				isSelected = false;
				this.GetComponent<Image>().color = Color.white;
				UseItem();

			}
		}
		if(isAvailable == true)
		{
			this.GetComponent<Button>().enabled = false;
		}
		if(isAvailable == false)
		{
			this.GetComponent<Button>().enabled = true;
		}

	}
	public void SlotFunction(Sprite Icon, int Weight)
	{
		Number = GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items.Count - 1;
		this.gameObject.GetComponent<Image>().overrideSprite = Icon;
		//Change
		GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().NextSlot += 1;
		isAvailable = false;
	}
	public void RemoveItem()
	{
		GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items[Number].transform.parent = null;
		GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items[Number].transform.position =  new Vector3(GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items[Number].transform.position.x * 2, GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items[Number].transform.position.y,GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items[Number].transform.position.z);
		GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items[Number].gameObject.SetActive(true);
		Slot[] slots = FindObjectsOfType(typeof(Slot)) as Slot[];
		foreach(Slot slot in slots)
		{
			if(slot.Number != 0)
			{
				slot.Number -= 1;
			}
		}
			this.gameObject.GetComponent<Image>().overrideSprite = Origanal;
			GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items.RemoveAt(Number);
			isAvailable = true;
		}

}
