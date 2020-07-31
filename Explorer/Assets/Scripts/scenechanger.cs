using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void myfunc(string scenename)
    {
         SceneManager.LoadScene(scenename);
    }
}
