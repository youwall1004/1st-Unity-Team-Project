using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//슬라임의 수동 회전에 관한 코드.

public class SlimeSpin : MonoBehaviour
{
    private float slimeRotate = 0.9f;
    public float slimeRotationY;
    
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SlimeMove>().slimeSpeed == 0)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // 축, 각도, 기준 좌표계
                transform.Rotate(0, -slimeRotate, 0);
                slimeRotationY -= slimeRotate;
                //transform.Rotate(0, slimeRotationY, 0);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, slimeRotate, 0);
                slimeRotationY += slimeRotate;
                //transform.Rotate(0, slimeRotationY, 0);
            }
        }
        else if (GetComponent<SlimeMove>().slimeSpeed != 0)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("멈춰!");
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("멈춰!");
            }
        }
    }
}
