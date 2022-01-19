using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public GameObject FocusCamera;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && FocusCamera.activeSelf == false) // 탑뷰 시점의 메인 카메라를 조정하기 위한 기능
        {
            // 포커스 카메라가 비활성화일때만 조정 가능
            float mouseX = Input.GetAxis("Mouse X"); // 현재 Mouse X의 좌표값을 저장
            float mouseY = Input.GetAxis("Mouse Y"); // 현재 Mouse X의 좌표값을 저장

            transform.RotateAround(transform.position, Vector3.left, mouseY); // 시점을 변경할때 짐벌리 현상이 일어나므로
            transform.RotateAround(transform.position, Vector3.up, mouseX);  // RotateAround 를 써서 오브젝트에 시점을 고정하면
        }                                                                    // 짐벌리 현상 해결
    }
}
