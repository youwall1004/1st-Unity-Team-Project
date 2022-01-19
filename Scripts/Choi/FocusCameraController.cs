using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCameraController : MonoBehaviour
{

    bool isFirst = true;

    void Start()
    {

    }
    void Update()
    {
        GameObject.Find("MobileSpin").SetActive(true);

        if(isFirst)
        {
            FindObjectOfType<GameControll>().FocusCameras.Add(gameObject); // 각 슬라임들의 포커스 카메라를
            gameObject.SetActive(false);                                  // 포커스 카메라 리스트에 추가
            isFirst = false;
        }

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");

            transform.RotateAround(transform.position, Vector3.up, mouseX);
        }
    }
}