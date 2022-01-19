using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� �̵�(����)�� ���� �ڵ�

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
            //���߰� �ٽ� �����(���� �� �� �ڿ������� ���� ����� �ø��� ����.), rotation�� x, z�� 0���� �� ��.
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

            // ���1. �����̼� set�� 1ȸ�� �����Ѵ�.
            // ���2. ���ǹ��� �̿��Ѵ�
            if (transform.rotation.x != 0 || transform.rotation.z != 0)
            {
                // y���� 0�� �ƴԿ��� 0���� �������� ������?
                // x,z���� 0�ӿ��� �ణ�� �����̰� �־����� ���� spin�� ������
                //transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
                transform.rotation = Quaternion.Euler(0, GetComponent<SlimeSpin>().slimeRotationY, 0);
            }
        }
        else
        {
            //�Ƹ� ���� ���� �԰���........?
            slimeSpeed -= 0.0025f;
        }
    }
}