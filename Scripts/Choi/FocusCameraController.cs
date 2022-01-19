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
            FindObjectOfType<GameControll>().FocusCameras.Add(gameObject); // �� �����ӵ��� ��Ŀ�� ī�޶�
            gameObject.SetActive(false);                                  // ��Ŀ�� ī�޶� ����Ʈ�� �߰�
            isFirst = false;
        }

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");

            transform.RotateAround(transform.position, Vector3.up, mouseX);
        }
    }
}