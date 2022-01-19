using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//왜 있는지 모를 코드

//캡틴의 움직임이 좆될것 같다면, freeze rotation의 z축을 잠궈보세요
//z축 풀어놓으니 캡틴이 주님 곁으로 날아간다

public class GameManager : MonoBehaviour
{
    //public TextMeshProUGUI cursorText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //클릭된 마우스 좌표값 구하기
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Debug.Log(point.ToString());
            cursorText.text = "[Click]\n" + point.x + "/\n" + point.y + "/\n" + point.z;
        }
        */
    }
}
