using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� ���� ȸ���� ���� �ڵ�.

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
                // ��, ����, ���� ��ǥ��
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
                Debug.Log("����!");
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("����!");
            }
        }
    }
}
