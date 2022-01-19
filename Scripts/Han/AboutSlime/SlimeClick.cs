using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ Ŭ���� ���� ���� ��� ���� �ڵ�

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

            //click�� main ī�޶�����, sub ī�޶����� ���� �ؾ� ��
           
            //Ŭ���� ������Ʈ�� �ִٸ�
            if (Physics.Raycast(click, out hit))
            {
                //Ȱ��ȭ�� ���� ��Ŭ���� �ƴ�, �巡�� ��(2ȸ ���� ���� ��, Ŭ�� & �巡��) ������.
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
                
                //���ľ� �� ����
                //��ο� �����Ŀ� ����� ��
            }
        }
    }
}
