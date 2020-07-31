using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    // Start is called before the first frame update

	string myString;
	Text text;
	GameObject  ChildGameObject1;
	GameObject bt;
    void Start()
    {
		ChildGameObject1 = this.gameObject.transform.GetChild (1).GetChild(0).GetChild(0).gameObject;
		//Debug.Log(ChildGameObject1.name);
        //text = GameObject.Find ("Text").GetComponent<Text> ();
		bt = this.gameObject.transform.GetChild (1).GetChild(0).gameObject;
		bt.GetComponent<Image>().color = Color.clear;
		text = bt.transform.GetChild(0).GetComponent<Text> ();
		text.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			//Debug.Log(hit.transform.gameObject);
			if(hit.transform.gameObject ==  gameObject && (hit.transform.name == "Box" || hit.transform.name == "Box(Clone)"))
			{
				//text.text = myString;
				bt.GetComponent<Image>().color = Color.green;
				//Debug.Log("yay"+text.color);
				text.color = Color.white;
				
			}
			else{
					text.color = Color.clear;
					bt.GetComponent<Image>().color = Color.clear;
				}

		}
		else{
				text.color = Color.clear;
			}
    }
}
