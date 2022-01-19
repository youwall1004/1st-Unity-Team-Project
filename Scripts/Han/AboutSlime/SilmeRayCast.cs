using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 개발자를 위한 레이캐스트 코드와 알의 낙사 시 오브젝트 삭제를 위한 코드

public class SilmeRayCast : MonoBehaviour
{
    public GameObject MainCamera;

    RaycastHit hit;
    float MaxDistance = 70.0f;  //ray의 길이
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.black);
        if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
        {
            //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;      //ray에 접촉한 오브젝트 색 변경
        }

        if (transform.position.y < -15)
        {
            //Debug.Log("낙하~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!");
            //gameObject.GetComponents<Rigidbody>()
            MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f);

            if (gameObject.tag == "Blue")
            {
                Trun.Player1_Slime--;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Red")
            {
                Trun.Player2_Slime--;
                Destroy(gameObject);
            }
        }
    }
}
