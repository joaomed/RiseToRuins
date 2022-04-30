using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerScript : MonoBehaviour
{
  public GameObject prefabCoin;
  void Start()
  {
    InvokeRepeating("InstantiateCoin", 5, 10);
  }

  void InstantiateCoin()
  {
    var temp = Instantiate(prefabCoin, transform.position, Quaternion.identity) as GameObject;
    temp.GetComponent<CoinScript>().newInstance = true;
  }

}
