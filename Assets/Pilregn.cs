using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilregn : MonoBehaviour
{
    [Header("Prefaben som ska spawnas")]
    public GameObject Pil;

    [Header("Tiden mellan varje pil")]
    public float RespawnTime;

    [Header("Minimala stunden mellan varje pil")]
    [Range(0.01f, 0.2f)]
    public float MaxSpawnRate;

    [Header("Hur snabbt antalet pilar ökar med tiden")]
    [Range(0.0f, 1.2f)]
    public float RespawnRateIncrease = 0.02f;

    void Start()
    {
        RespawnTime = Random.Range(4f, 7.5f);
        StartCoroutine(SpawnArrows());
    }

    IEnumerator SpawnArrows()
    {
        Instantiate(Pil, new Vector3(Random.Range(-9.0f,9.0f), transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90));
        yield return new WaitForSeconds(RespawnTime);
        if (RespawnTime >= MaxSpawnRate)
        {
            RespawnTime -= RespawnRateIncrease;
        }
        StartCoroutine(SpawnArrows());
    }
}
