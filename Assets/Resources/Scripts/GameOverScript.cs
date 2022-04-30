using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
  public GameObject gameOverPanel;
  public GameObject level;
  public string sceneMenu;
  public AudioSource songGameOver;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    CheckGameOver();
  }

  public void BackToMenu()
  {
    SceneManager.LoadScene(sceneMenu);
  }
  void CheckGameOver()
  {


  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.CompareTag("Enemy"))
    {
      Time.timeScale = 0f;
      gameOverPanel.SetActive(true);
      level.GetComponent<AudioSource>().Pause();
      songGameOver.Play();
    }
  }
}
