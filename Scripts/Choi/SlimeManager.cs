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

    private void OnMouseDown() // ������ ������Ʈ�� ���콺 Ŭ�� �̺�Ʈ�� �߻��Ұ��
    {
        for (int i = 0; i < GameObject.FindObjectOfType<GameControll>().FocusCameras.Count; i++) // �ڱ� �ڽ� �̿��� ��������
        {                                                                                    // ��Ŀ�� ī�޶� ��Ȱ��ȭ
            if (GameObject.FindObjectOfType<GameControll>().FocusCameras[i] == true)
            {
                GameObject.FindObjectOfType<GameControll>().FocusCameras[i].SetActive(false);
            }
        }

        if (PlayerSelf.GetComponent<BattleTest>().enabled == true)
        {
            FocusCamera.SetActive(true); // �ڱ� �ڽ��� ��Ŀ�� ī�޶� ���¸� Ȱ��ȭ �����ش�.
            FindObjectOfType<GameControll>().selectedCamera = FocusCamera.GetComponent<Camera>();
        }
    }
}
