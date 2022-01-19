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
        //처음 시작할때는 mainCam을 주시한다
        
    }


    // Update is called once per frame
    void Update()
    {
        //focusCam의 오브젝트가 활성화상태면
        if (focusCam.activeSelf == true)
        {
            transform.LookAt(focusCam.transform);
        }
        //focusCam의 오브젝트가 비활성화 상태면
        else if (focusCam.activeSelf == false)
        {
            if (FindObjectOfType<GameControll>().selectedCamera != null)
            {
                transform.LookAt(FindObjectOfType<GameControll>().selectedCamera.transform);

             //   FindObjectOfType<GameControll>().selectedCamera = null;
            }
            else
            {
                //메인카메라의 회전에 따라 슬라임객체도 같이 회전
                transform.rotation = mainCam.transform.rotation;
                //transform.LookAt(mainCam.transform);
                //Quaternion rotation = Quaternion.LookRotation(mainCam.transform.position, Vector3.up);
            }
        }
    }
}
