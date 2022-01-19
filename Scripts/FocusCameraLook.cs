using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCameraLook : MonoBehaviour
{
    public GameObject focusCam;
    public GameObject mainCam;

    // Start is called before the first frame update
    void Start()
    {
        //ó�� �����Ҷ��� mainCam�� �ֽ��Ѵ�
        
    }


    // Update is called once per frame
    void Update()
    {
        //focusCam�� ������Ʈ�� Ȱ��ȭ���¸�
        if (focusCam.activeSelf == true)
        {
            transform.LookAt(focusCam.transform);
        }
        //focusCam�� ������Ʈ�� ��Ȱ��ȭ ���¸�
        else if (focusCam.activeSelf == false)
        {
            if (FindObjectOfType<GameControll>().selectedCamera != null)
            {
                transform.LookAt(FindObjectOfType<GameControll>().selectedCamera.transform);

             //   FindObjectOfType<GameControll>().selectedCamera = null;
            }
            else
            {
                //����ī�޶��� ȸ���� ���� �����Ӱ�ü�� ���� ȸ��
                transform.rotation = mainCam.transform.rotation;
                //transform.LookAt(mainCam.transform);
                //Quaternion rotation = Quaternion.LookRotation(mainCam.transform.position, Vector3.up);
            }
        }
    }
}
