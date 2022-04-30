using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
  public string sceneNewGame;
  public string sceneMenu;

  public GameObject creditsPanel;
  public GameObject menuPanel;

  public bool isMuted;
  // Start is called before the first frame update
  void Start()
  {
    isMuted = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void NewGame()
  {
    SceneManager.LoadScene(sceneNewGame);
  }
  public void ShowCredits()
  {
    creditsPanel.SetActive(true);
    menuPanel.SetActive(false);
  }

  public void BackMenu()
  {
    creditsPanel.SetActive(false);
    menuPanel.SetActive(true);
  }

  public void Sound()
  {
    isMuted = !isMuted;
    AudioListener.pause = isMuted;
  }

  public void Exit()
  {
    // Editor Unity
    // UnityEditor.EditorApplication.isPlaying = false;
    // Jogo compilado
    Application.Quit();
  }
}
