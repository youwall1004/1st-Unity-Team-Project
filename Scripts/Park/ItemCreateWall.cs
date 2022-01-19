using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreateWall : MonoBehaviour
{
    public GameObject Wall;
    public float time;


    public void CreateWall()
    {
        Wall.SetActive(true);
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3.0f);
        Wall.SetActive(false);
    }
}
