using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//슬라임 클릭을 통한 개별 제어를 위한 코드

public class SlimeClick : MonoBehaviour
{
    public GameObject bodyObj;
    public GameObject camObj;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray click;

            if(camObj.activeSelf == false)
                click = Camera.main.ScreenPointToRay(Input.mousePosition);
            else
                click = camObj.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //click이 main 카메라인지, sub 카메라인지 구분 해야 함
           
            //클릭시 오브젝트가 있다면
            if (Physics.Raycast(click, out hit))
            {
                //활성화된 알을 재클릭이 아닌, 드래그 시(2회 연속 공격 시, 클릭 & 드래그) 불편함.
                if (hit.transform.gameObject == gameObject && gameObject.GetComponent<SlimeDraw>().enabled == false)
                {
                    gameObject.GetComponent<SlimeDraw>().enabled = true;
                    //bodyObj.GetComponent<SlimeSpin>().enabled = true;
                    camObj.SetActive(true);
                    camObj.GetComponent<FocusCameraController>().enabled = false;
                }/*
                else if (hit.transform.gameObject == gameObject && gameObject.GetComponent<SlimeDraw>().enabled == true)
                {
                    gameObject.GetComponent<SlimeDraw>().enabled = false;
                    bodyObj.GetComponent<SlimeSpin>().enabled = false;
                }*/                
                else if (hit.transform.gameObject != gameObject && gameObject.GetComponent<SlimeDraw>().enabled == true)
                {
                    gameObject.GetComponent<SlimeDraw>().enabled = false;
                    //gameObject.GetComponent<SlimeDraw>().fucking_Bug_Activate = true;
                    //bodyObj.GetComponent<SlimeSpin>().enabled = false;
                    camObj.GetComponent<FocusCameraController>().enabled = true;
                    //camObj.SetActive(false);
                }
                
                //고쳐야 할 오류
                //드로우 동작후에 멈춰야 함
            }
        }
    }
}
