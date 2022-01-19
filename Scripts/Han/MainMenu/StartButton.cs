using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ¾Æ ¸ô¶ó ½ËÆÈ

public class StartButton : MonoBehaviour
{
    //public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(0))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    /*
    void OnMouseDown()
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 1);
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector3(1, 1, 1);

        SceneManager.LoadScene("Alkagi");
    }
    */
}
