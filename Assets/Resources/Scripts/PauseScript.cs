using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
  private bool isPaused;

  public GameObject pausePapel;
  public GameObject level;
  public string sceneMenu;
  public AudioSource paused;

  // Start is called before the first frame update
  void Start()
  {
    Time.timeScale = 1f;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      PauseMenu();
    }
  }

  public void BackToMenu()
  {
    SceneManager.LoadScene(sceneMenu);
  }

  void PauseMenu()
  {
    if (isPaused)
    {
      isPaused = false;
      Time.timeScale = 1f;
      pausePapel.SetActive(false);
      level.GetComponent<AudioSource>().Play();

    }
    else
    {
      isPaused = true;
      Time.timeScale = 0f;
      pausePapel.SetActive(true);
      level.GetComponent<AudioSource>().Pause();
      paused.Play();

    }
  }
}
