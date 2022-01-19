using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//슬라임의 이동(돌진)에 관한 코드

public class SlimeMove : MonoBehaviour
{
    int tempCount;
    public float slimeSpeed;
    //private float distance = 10;

    // Start is called before the first frame update
    void Start()
    {
        slimeSpeed = 0.0f;
    }

    public void ImpulsePower()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * slimeSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().AddForce(transform.forward * slimeSpeed, ForceMode.Impulse);
        //GetComponent<Rigidbody>().AddForce(Vector3.forward * slimeSpeed);
        //GetComponent<Rigidbody>().AddForce(0,0,slimeSpeed);

        
        if (slimeSpeed <= 0)
        {
            slimeSpeed = 0;
            //멈추고 다시 세우기(추후 좀 더 자연스럽게 새울 방법을 궁리해 볼것.), rotation은 x, z만 0으로 할 것.
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

            // 방법1. 로테이션 set을 1회만 동작한다.
            // 방법2. 조건문을 이용한다
            if (transform.rotation.x != 0 || transform.rotation.z != 0)
            {
                // y값이 0이 아님에도 0으로 맞춰지는 이유는?
                // x,z값이 0임에도 약간의 딜레이가 주어지고 나서 spin이 동작함
                //transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
                transform.rotation = Quaternion.Euler(0, GetComponent<SlimeSpin>().slimeRotationY, 0);
            }
        }
        else
        {
            //아마 연산 많이 먹겠지........?
            slimeSpeed -= 0.0025f;
        }
    }
}