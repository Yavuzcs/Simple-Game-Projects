using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public PlayerController Player;

    public GameObject Borular;
    public float height;

    public float Time;

    private void Start()
    {
        StartCoroutine(SpawnObject(Time));
    }

    public IEnumerator SpawnObject(float time)
    {
        while (!Player.isDead)
        {
            Instantiate(Borular, new Vector3(3, Random.Range(-height, height), 0), Quaternion.identity);

            yield return new WaitForSeconds(time);
        }
    }
}
