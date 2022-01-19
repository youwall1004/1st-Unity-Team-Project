using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSide : MonoBehaviour
{
    GameObject[] player1;
    GameObject[] player2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectsWithTag("1P");
        player2 = GameObject.FindGameObjectsWithTag("2P");
    }

    // Update is called once per frame
    void Update()
    {
        if(Trun.Player1_Trun==true)
        for (int i = 0; i < player1.Length; i++)
        {
            player1[i].GetComponent<BattleTest>().enabled = true;
        }
        for (int i = 0; i < player1.Length; i++)
        {
            player2[i].GetComponent<BattleTest>().enabled = true;
        }
    }
}
