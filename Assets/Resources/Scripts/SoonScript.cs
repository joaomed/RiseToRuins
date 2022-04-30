using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoonScript : MonoBehaviour
{
  public string sceneMenu;
  SpriteRenderer rend;
  // Start is called before the first frame update
  void Start()
  {
    rend = GetComponent<SpriteRenderer>();
    Color c = rend.material.color;
    c.a = 0f;
    rend.material.color = c;

    startFading();
  }

  // Update is called once per frame
  void Update()
  {

  }

  IEnumerator FadeOut()
  {
    for (float f = 1f; f >= -0.05; f -= 0.05f)
    {
      Color c = rend.material.color;
      c.a = f;
      rend.material.color = c;
      yield return new WaitForSeconds(0.05f);
    }
  }

  public void startFading()
  {
    StartCoroutine("FadeOut");
  }
  public void BackToMenu()
  {
    SceneManager.LoadScene(sceneMenu);
  }
}
