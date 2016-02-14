using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Slot : MonoBehaviour {


	public Sprite Icon;
	public int Weight;
	public void Update()
	{


	}
	public void SlotFunction(Sprite Icon, int Weight)
	{

		this.gameObject.GetComponent<Image>().overrideSprite = Icon;
		//Change
		GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().NextSlot += 1;
	}
}
