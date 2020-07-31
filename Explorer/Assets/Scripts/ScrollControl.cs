using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollControl : MonoBehaviour
{
    // Start is called before the first frame update
	GameObject[] gameObjects;
	int move;
    void Start()
    {
		move=0;
        gameObjects = GameObject.FindGameObjectsWithTag("Button");
    }

    
    public void moveNext()
	{
		Vector3 moveDir = new Vector3(-150,0,0);
		if(move <= gameObjects.Length - 4)
		{
			move++;
			foreach (GameObject button in gameObjects)
			{
				button.transform.position += moveDir; 
			}
		}
			
	}
	public void movePrev()
	{
		Vector3 moveDir = new Vector3(+150,0,0);
		if(move >= -1)
		{
			move--;
			foreach (GameObject button in gameObjects)
			{
				button.transform.position += moveDir;
			}
		}
	}
}
