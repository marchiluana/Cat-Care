using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public GameObject[] poops;

    public void SpawnPoop()
    {
        int n = Random.Range(0, poops.Length - 1);
        poops[n].SetActive(true);
    }
   
}
