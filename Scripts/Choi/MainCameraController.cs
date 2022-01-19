using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public GameObject FocusCamera;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && FocusCamera.activeSelf == false) // ž�� ������ ���� ī�޶� �����ϱ� ���� ���
        {
            // ��Ŀ�� ī�޶� ��Ȱ��ȭ�϶��� ���� ����
            float mouseX = Input.GetAxis("Mouse X"); // ���� Mouse X�� ��ǥ���� ����
            float mouseY = Input.GetAxis("Mouse Y"); // ���� Mouse X�� ��ǥ���� ����

            transform.RotateAround(transform.position, Vector3.left, mouseY); // ������ �����Ҷ� ������ ������ �Ͼ�Ƿ�
            transform.RotateAround(transform.position, Vector3.up, mouseX);  // RotateAround �� �Ἥ ������Ʈ�� ������ �����ϸ�
        }                                                                    // ������ ���� �ذ�
    }
}
