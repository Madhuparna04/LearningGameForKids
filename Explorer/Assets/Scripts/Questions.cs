using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Questions : MonoBehaviour
{
    // Start is called before the first frame update
    Text textbox;
	GameObject[] gameObjects;
	GameObject[] items;
    // Start is called before the first frame update
    void Start()
    {

		
        gameObjects = GameObject.FindGameObjectsWithTag("Ques");
		items = GameObject.FindGameObjectsWithTag("item");
        //textbox = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text> ();
		//Debug.Log(text.text);

		StartCoroutine(GetRequest("http://127.0.0.1:5000/"));
    }

       // Update is called once per frame
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
			//Debug.Log(test);
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
			
            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
				
				Text txt = gameObjects[0].transform.GetChild(0).GetComponent<Text> ();
				txt.text = webRequest.downloadHandler.text;
				
				
				//textbox.text = "fygh"+ webRequest.downloadHandler.text;
            }
        }
    }
}
