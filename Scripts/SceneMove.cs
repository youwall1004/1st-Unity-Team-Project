using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{

    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void TitleScene()
    {
        SceneManager.LoadScene("Title");
    }
    public void AppQuit()
    {
        Application.Quit();
    }
    public void TMIScene()
    {
        SceneManager.LoadScene("TMIScene");
    }
}
