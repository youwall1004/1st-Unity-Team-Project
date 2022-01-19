using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeManager : MonoBehaviour
{
    public AudioSource CrashSound;
    public GameObject FocusCamera;

    public GameObject PlayerSelf;

    public GameObject CrashEffect;

    private void Start()
    {
        CrashSound = this.gameObject.GetComponent<AudioSource>();
        if (tag == "Blue")
            FindObjectOfType<GameControll>().greenSlimes.Add(gameObject);
        else if (tag == "Red")
            FindObjectOfType<GameControll>().redSlimes.Add(gameObject);

    }

    private void Update()
    {
        if (FocusCamera.activeSelf)
        {
            transform.Find("DrawHandler").GetComponent<BoxCollider>().size = new Vector3(1, 3, 6);
            GetComponent<SlimeSpin>().enabled = true;
        }
        else
        {
            transform.Find("DrawHandler").GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
            GetComponent<SlimeSpin>().enabled = false;
        }


    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Stage")
        {
            CrashSound.enabled = true;
            this.CrashSound.Play();
        }

    }

    private void OnMouseDown() // 슬라임 오브젝트에 마우스 클릭 이벤트가 발생할경우
    {
        for (int i = 0; i < GameObject.FindObjectOfType<GameControll>().FocusCameras.Count; i++) // 자기 자신 이외의 슬라임은
        {                                                                                    // 포커스 카메라를 비활성화
            if (GameObject.FindObjectOfType<GameControll>().FocusCameras[i] == true)
            {
                GameObject.FindObjectOfType<GameControll>().FocusCameras[i].SetActive(false);
            }
        }

        if (PlayerSelf.GetComponent<BattleTest>().enabled == true)
        {
            FocusCamera.SetActive(true); // 자기 자신의 포커스 카메라 상태를 활성화 시켜준다.
            FindObjectOfType<GameControll>().selectedCamera = FocusCamera.GetComponent<Camera>();
        }
    }
}
