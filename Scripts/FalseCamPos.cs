using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseCamPos : MonoBehaviour
{
    public GameObject PlayerBlue;
    public GameObject PlayerRed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerBlue.transform.position.x, PlayerBlue.transform.position.y+10,PlayerBlue.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
