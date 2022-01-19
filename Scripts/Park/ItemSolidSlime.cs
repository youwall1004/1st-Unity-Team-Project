using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSolidSlime : MonoBehaviour
{
    public void SolidSlime()
    {
        if(Trun.Player1_Trun)
        {
            Debug.Log("·¹µå ¸ØÃç!");
            for (int i = 0; i < FindObjectOfType<GameControll>().redSlimes.Count; i++)
                FindObjectOfType<GameControll>().redSlimes[i].GetComponent<Rigidbody>().isKinematic = true;
        }else if(Trun.Player2_Trun)
        {
            Debug.Log("±×¸° ¸ØÃç!");
            for (int i = 0; i < FindObjectOfType<GameControll>().greenSlimes.Count; i++)
                FindObjectOfType<GameControll>().greenSlimes[i].GetComponent<Rigidbody>().isKinematic = true;
        }

        StartCoroutine(EffectRemove());
    }

    IEnumerator EffectRemove()
    {
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i < FindObjectOfType<GameControll>().greenSlimes.Count; i++)
            FindObjectOfType<GameControll>().greenSlimes[i].GetComponent<Rigidbody>().isKinematic = false;

        for (int i = 0; i < FindObjectOfType<GameControll>().redSlimes.Count; i++)
            FindObjectOfType<GameControll>().redSlimes[i].GetComponent<Rigidbody>().isKinematic = false;

        Debug.Log("È¿°ú Á¦°ÅµÊ");
    }
}
