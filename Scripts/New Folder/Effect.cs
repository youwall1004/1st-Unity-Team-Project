using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public GameObject colEffect;
    Transform myTrans;
    void Start()
    {
        myTrans = GetComponent<Transform>();  
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Red")
        {
            Instantiate(colEffect, myTrans.position, Quaternion.identity);
            Destroy(colEffect.gameObject);
        }
    }
}

