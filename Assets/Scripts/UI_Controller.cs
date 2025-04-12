using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Controller : MonoBehaviour
{
    //[SerializeField] private GameObject LosePn;

    public GameObject PausePn;
    public GameObject losepn;
    public bool a;
    public void Pause()
    {
        a = true;
        PausePn.SetActive(true);
        Time.timeScale = 0f;
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;*/
    }
    public void Continue()
    {
        a = true;
        PausePn.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Restart()
    {
        a = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
    public void Replay()
    {
        a= true;
        losepn.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
    public void ReplayPau()
    {
        a = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MenuLv");
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1.0f;
    }
    public void LoadLv1()
    {
        SceneManager.LoadScene("Lv1");
        Time.timeScale = 1.0f;
    }
    public void LoadLv2()
    {
        SceneManager.LoadScene("Lv2");
        Time.timeScale = 1.0f;
    }
    public void LoadLv3()
    {
        SceneManager.LoadScene("Lv3");
        Time.timeScale = 1.0f;
    }
    public void LoadLv4()
    {
        SceneManager.LoadScene("Lv4");
        Time.timeScale = 1.0f;
    }
    public void LoadLv5()
    {
        SceneManager.LoadScene("Lv5");
        Time.timeScale = 1.0f;
    }
    public void LoadLv6()
    {
        SceneManager.LoadScene("Lv6");
        Time.timeScale = 1.0f;
    }
    public void LoadLv7()
    {
        SceneManager.LoadScene("Lv7");
        Time.timeScale = 1.0f;
    }
    public void LoadLv8()
    {
        SceneManager.LoadScene("Lv8");
        Time.timeScale = 1.0f;
    }
    public void LoadLv9()
    {
        SceneManager.LoadScene("Lv9");
        Time.timeScale = 1.0f;
    }
    public void LoadLv10()
    {
        SceneManager.LoadScene("Lv10");
        Time.timeScale = 1.0f;
    }
    public void LoadLv11()
    {
        SceneManager.LoadScene("Lv11");
        Time.timeScale = 1.0f;
    }
    public void LoadLv12()
    {
        SceneManager.LoadScene("Lv12");
        Time.timeScale = 1.0f;
    }
    public void Next_Level()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }
}
