using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject shopmenuui;
    Player player;
    public string scene;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            ActivateMenu();
        }
   
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }
   public void Deactivatemenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
      
    }
    public void openshop()
    {
        pauseMenuUI.SetActive(false);
        shopmenuui.SetActive(true);
    }
    public void backtopause()
    {
        shopmenuui.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(scene);
    }
    public void upgradehealth()
    {
        player.AlterMaxhealth();
    }
    public void upgradespeed()
    {
        player.ChangespeedPlayer();
    }
    public void heal()
    {
        player.Heal();
    }
}
