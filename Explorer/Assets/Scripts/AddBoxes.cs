using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBoxes : MonoBehaviour
{
	public GameObject Box;
   // public GameObject textbox;
	//public Text textPrefab;
    // Start is called before the first frame update
    void Start()
    {


		for (int i = 0; i < 10; i++) {
            Vector3 position = new Vector3(Random.Range(-30.0f, 30.0f), 1.5f, Random.Range(-30.0f, 30.0f));
			Instantiate(Box, position, Quaternion.identity);
			
         }

    }

}
