using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandling : MonoBehaviour
{
	public string myString;
	public Text text;
	public float fadeTime;
	public bool isDisplay;
   
    void Start()
    {
        text = GameObject.Find ("Text").GetComponent<Text> ();
		text.color = Color.clear;
	
    }

    // Update is called once per frame
    void Update()
    {
        FadeText();
    }

	void onMouseOver()
	{
		isDisplay = true;
	}
	void onMouseExit()
	{
		isDisplay = false;
	}
	void FadeText()
	{
		if(isDisplay)
		{
			text.text = myString;
			text.color = Color.Lerp(text.color, Color.red, fadeTime * Time.deltaTime );
		}

		else{
			text.text = myString;
			text.color = Color.Lerp(text.color, Color.clear, fadeTime * Time.deltaTime );
		}
	}

}
