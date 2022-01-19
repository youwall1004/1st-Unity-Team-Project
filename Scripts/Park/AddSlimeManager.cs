using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AddSlimeManager : MonoBehaviour
{
    public static int greenItemCount = 0;
    public static int redItemCount = 0;
    public TextMeshProUGUI greenCountText;
    public TextMeshProUGUI redCountText;
    public int GreenCount//
    {
        set
        {
            greenItemCount = value;

            greenCountText.text = greenItemCount.ToString();
        }
        get
        {
            return greenItemCount;
        }
    }

    public int RedCount//
    {
        set
        {
            redItemCount = value;

            redCountText.text = redItemCount.ToString();
        }
        get
        {
            return redItemCount;
        }
    }

    public void Update()
    {
        greenCountText.text = greenItemCount.ToString();
        redCountText.text = redItemCount.ToString();
    }
    public void GreenUseItem()
    {
        if(greenItemCount > 0)//itemCount가 1이상일 때
        {
            greenItemCount--;
            greenCountText.text = greenItemCount.ToString();
            GetComponent<ItemAddSlime>().AddSlime();//ItemAddSlime스크립트의 addSlime실행
        }
    }

    public void RedUseItem()
    {
        if (redItemCount > 0)//itemCount가 1이상일 때
        {
            redItemCount--;
            redCountText.text = redItemCount.ToString();
            GetComponent<ItemAddSlime>().AddSlime();//ItemAddSlime스크립트의 addSlime실행
        }
    }
}
