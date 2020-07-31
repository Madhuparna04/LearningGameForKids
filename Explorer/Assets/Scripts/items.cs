using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class items : MonoBehaviour
{
    // Start is called before the first frame update
    Text textbox;
	//GameObject[] gameObjects;
	GameObject[] its;
    // Start is called before the first frame update
    void Start()
    {

		
        //gameObjects = GameObject.FindGameObjectsWithTag("Ques");
		
        //textbox = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text> ();
		//Debug.Log(text.text);

		StartCoroutine(GetRequest("http://127.0.0.1:5000/item"));
    }
	void Update()
	{
		its = GameObject.FindGameObjectsWithTag("item");
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
				
				List<string> store = new List<string>(); 
				//string[] store;
				string curr = "";
				foreach(char c in webRequest.downloadHandler.text)
				{
					Debug.Log(c);
					if(c=='+')
					{
						store.Add(curr);
						curr="";
					}
					else{
						curr+=c;
					}
				}
				store.Add(curr);
				int counter=0;
				foreach(GameObject it in its)
				{
					Debug.Log("wefewf");
					Text txt = it.transform.GetChild(0).GetComponent<Text> ();
					txt.text = store[counter];
					counter++;
				}
				
				
				//textbox.text = "fygh"+ webRequest.downloadHandler.text;
            }
        }
    }
}
