using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
  private int randomNumber;
  private int randomEnemy;
  public static int enemiesComing;
  public static int enemiesValue;

  public int enemiesTotal;

  //public GameObject prefabEnemy3;

  public Transform pointCoin;
  public static int cash;
  public static bool shovelEnabled; //para ver se a pá esta sendo usada

  public GameObject prefabCoin;
  public GameObject prefabEnemy;
  public GameObject prefabEnemy2;
  public GameObject prefabEnemy3;


  public GameObject continuePapel;

  public static GameObject currentChampion, currentCard; //campeao selecionado e card selecionado


  // Sistema de Wave
  public string sceneNextWave;

  public int wave;
  public GUIStyle style;
  public float xPos, yPos;
  void Start()
  {
    Time.timeScale = 1f;
    enemiesComing = enemiesTotal;
    enemiesValue = enemiesTotal;
    // invocará a partir dos 10 seg, dps em 20 em 20 seg    
    InvokeRepeating("InstantiateCoin", 10, 20);


    if (wave == 1)
    {
      InvokeRepeating("InstantiateEnemy", 15, 21);
      InvokeRepeating("InstantiateEnemyMedium", 30, 17);
      InvokeRepeating("InstantiateEnemyHard", 45, 13);

    }
    else if (wave == 2)
    {
      InvokeRepeating("InstantiateEnemy", 13, 120);
      InvokeRepeating("InstantiateEnemyMedium", 28, 16);
      InvokeRepeating("InstantiateEnemyHard", 43, 12);
    }
    else if (wave == 3)
    {
      InvokeRepeating("InstantiateEnemy", 11, 19);
      InvokeRepeating("InstantiateEnemyMedium", 26, 15);
      InvokeRepeating("InstantiateEnemyHard", 41, 11);
    }


    cash = 100;
    shovelEnabled = false;
  }

  void Update()
  {
    if (cash >= 9999)
    {
      cash = 9999;
    }

    if (enemiesValue == 0)
    {
      WaveFinish();
    }

  }

  public void ContinueGame()
  {
    SceneManager.LoadScene(sceneNextWave);
  }

  void WaveFinish()
  {
    Time.timeScale = 0f;
    continuePapel.SetActive(true);
  }

  void OnGUI()
  {
    GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 1220.0f, Screen.width / 881.0f, 1.0f));
    GUI.Label(new Rect(xPos, yPos, 50, 100), wave.ToString(), style);
  }

  void InstantiateCoin()
  {
    Instantiate(prefabCoin, pointCoin.position, Quaternion.identity);


  }

  GameObject RandomEnemy()
  {
    randomEnemy = Random.Range(1, 3);
    switch (randomEnemy)
    {
      case 1:
        return prefabEnemy;
      default:
        return prefabEnemy2;
    }
  }
  GameObject RandomEnemyAll()
  {
    randomEnemy = Random.Range(1, 4);
    switch (randomEnemy)
    {
      case 1:
        return prefabEnemy;
      case 2:
        return prefabEnemy2;
      default:
        return prefabEnemy3;
    }
  }

  void InstantiateEnemy()
  {
    if (wave == 1)
    {
      randomNumber = Random.Range(1, 6);
      if (enemiesComing > 0)
      {
        switch (randomNumber)
        {
          case 1:
            Instantiate(prefabEnemy, new Vector3(7, 1.20f, 0), Quaternion.identity);
            break;
          case 2:
            Instantiate(prefabEnemy, new Vector3(7, 0, 0), Quaternion.identity);
            break;
          case 3:
            Instantiate(prefabEnemy, new Vector3(7, -1.20f, 0), Quaternion.identity);
            break;
          case 4:
            Instantiate(prefabEnemy, new Vector3(7, -2.40f, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(prefabEnemy, new Vector3(7, -3.60f, 0), Quaternion.identity);
            break;
        }
        enemiesComing -= 1;
      }

    }
    else if (wave == 2)
    {
      randomNumber = Random.Range(1, 6);
      if (enemiesComing > 0)
      {
        switch (randomNumber)
        {
          case 1:
            Instantiate(prefabEnemy, new Vector3(7, 1.20f, 0), Quaternion.identity);
            break;
          case 2:
            Instantiate(prefabEnemy, new Vector3(7, 0, 0), Quaternion.identity);
            break;
          case 3:
            Instantiate(prefabEnemy, new Vector3(7, -1.20f, 0), Quaternion.identity);
            break;
          case 4:
            Instantiate(prefabEnemy, new Vector3(7, -2.40f, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(prefabEnemy, new Vector3(7, -3.60f, 0), Quaternion.identity);
            break;
        }
        enemiesComing -= 1;
      }

    }
    else if (wave == 3)
    {
      randomNumber = Random.Range(1, 6);
      if (enemiesComing > 0)
      {
        switch (randomNumber)
        {
          case 1:
            Instantiate(RandomEnemy(), new Vector3(7, 1.20f, 0), Quaternion.identity);
            break;
          case 2:
            Instantiate(RandomEnemy(), new Vector3(7, 0, 0), Quaternion.identity);
            break;
          case 3:
            Instantiate(RandomEnemy(), new Vector3(7, -1.20f, 0), Quaternion.identity);
            break;
          case 4:
            Instantiate(RandomEnemy(), new Vector3(7, -2.40f, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(RandomEnemy(), new Vector3(7, -3.60f, 0), Quaternion.identity);
            break;
        }
        enemiesComing -= 1;
      }

    }
  }

  void InstantiateEnemyMedium()
  {
    if (wave == 1)
    {
      randomNumber = Random.Range(1, 6);
      if (enemiesComing > 0)
      {
        switch (randomNumber)
        {
          case 1:
            Instantiate(prefabEnemy, new Vector3(7, 1.20f, 0), Quaternion.identity);
            break;
          case 2:
            Instantiate(prefabEnemy, new Vector3(7, 0, 0), Quaternion.identity);
            break;
          case 3:
            Instantiate(prefabEnemy, new Vector3(7, -1.20f, 0), Quaternion.identity);
            break;
          case 4:
            Instantiate(prefabEnemy, new Vector3(7, -2.40f, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(prefabEnemy, new Vector3(7, -3.60f, 0), Quaternion.identity);
            break;
        }
        enemiesComing -= 1;
      }

    }
    else if (wave == 2)
    {
      randomNumber = Random.Range(1, 6);
      if (enemiesComing > 0)
      {
        switch (randomNumber)
        {
          case 1:
            Instantiate(RandomEnemy(), new Vector3(7, 1.20f, 0), Quaternion.identity);
            break;
          case 2:
            Instantiate(RandomEnemy(), new Vector3(7, 0, 0), Quaternion.identity);
            break;
          case 3:
            Instantiate(RandomEnemy(), new Vector3(7, -1.20f, 0), Quaternion.identity);
            break;
          case 4:
            Instantiate(RandomEnemy(), new Vector3(7, -2.40f, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(RandomEnemy(), new Vector3(7, -3.60f, 0), Quaternion.identity);
            break;
        }
        enemiesComing -= 1;
      }

    }
    else if (wave == 3)
    {
      randomNumber = Random.Range(1, 6);
      if (enemiesComing > 0)
      {
        switch (randomNumber)
        {
          case 1:
            Instantiate(RandomEnemyAll(), new Vector3(7, 1.20f, 0), Quaternion.identity);
            break;
          case 2:
            Instantiate(RandomEnemyAll(), new Vector3(7, 0, 0), Quaternion.identity);
            break;
          case 3:
            Instantiate(RandomEnemyAll(), new Vector3(7, -1.20f, 0), Quaternion.identity);
            break;
          case 4:
            Instantiate(RandomEnemyAll(), new Vector3(7, -2.40f, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(RandomEnemyAll(), new Vector3(7, -3.60f, 0), Quaternion.identity);
            break;
        }
        enemiesComing -= 1;
      }
    }
  }

  void InstantiateEnemyHard()
  {
    if (wave == 1)
    {
      randomNumber = Random.Range(1, 6);
      if (enemiesComing > 0)
      {
        switch (randomNumber)
        {
          case 1:
            Instantiate(prefabEnemy, new Vector3(7, 1.20f, 0), Quaternion.identity);
            break;
          case 2:
            Instantiate(prefabEnemy, new Vector3(7, 0, 0), Quaternion.identity);
            break;
          case 3:
            Instantiate(prefabEnemy, new Vector3(7, -1.20f, 0), Quaternion.identity);
            break;
          case 4:
            Instantiate(prefabEnemy, new Vector3(7, -2.40f, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(prefabEnemy, new Vector3(7, -3.60f, 0), Quaternion.identity);
            break;
        }
        enemiesComing -= 1;
      }

    }
    else if (wave == 2)
    {
      randomNumber = Random.Range(1, 6);
      if (enemiesComing > 0)
      {
        switch (randomNumber)
        {
          case 1:
            Instantiate(prefabEnemy2, new Vector3(7, 1.20f, 0), Quaternion.identity);
            break;
          case 2:
            Instantiate(prefabEnemy2, new Vector3(7, 0, 0), Quaternion.identity);
            break;
          case 3:
            Instantiate(prefabEnemy2, new Vector3(7, -1.20f, 0), Quaternion.identity);
            break;
          case 4:
            Instantiate(prefabEnemy2, new Vector3(7, -2.40f, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(prefabEnemy2, new Vector3(7, -3.60f, 0), Quaternion.identity);
            break;
        }
        enemiesComing -= 1;
      }

    }
    else if (wave == 3)
    {
      randomNumber = Random.Range(1, 6);
      if (enemiesComing > 0)
      {
        switch (randomNumber)
        {
          case 1:
            Instantiate(prefabEnemy3, new Vector3(7, 1.20f, 0), Quaternion.identity);
            break;
          case 2:
            Instantiate(prefabEnemy3, new Vector3(7, 0, 0), Quaternion.identity);
            break;
          case 3:
            Instantiate(prefabEnemy3, new Vector3(7, -1.20f, 0), Quaternion.identity);
            break;
          case 4:
            Instantiate(prefabEnemy3, new Vector3(7, -2.40f, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(prefabEnemy3, new Vector3(7, -3.60f, 0), Quaternion.identity);
            break;
        }
        enemiesComing -= 1;
      }

    }
  }
}

