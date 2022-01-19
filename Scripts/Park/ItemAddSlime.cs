using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddSlime : MonoBehaviour
{
    public GameObject greenSlime;
    public GameObject redSlime;
    public void AddSlime()
    {
        if (Trun.Player1_Trun)
        {
            Instantiate(greenSlime, new Vector3(Random.Range(-6, 10), 0, -3), Quaternion.identity);
            Trun.Player1_Slime++;
        }
        else if (Trun.Player2_Trun)
        {
            Instantiate(redSlime, new Vector3(Random.Range(-6, 10), 0, 13), Quaternion.identity);
            Trun.Player2_Slime++;
        }
            
    }
}
