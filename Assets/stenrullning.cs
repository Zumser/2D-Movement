using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stenrullning : MonoBehaviour
{
    [Header("Prefaben som ska spawnas")]
    public GameObject sten;

    [Header("Tiden mellan varje sten")]
    public float RespawnTime;

    [Header("Minimala stunden mellan varje sten")]
    [Range(0.01f, 0.2f)]
    public float MaxSpawnRate;

    [Header("Hur snabbt antalet stenar ökar med tiden")]
    [Range(0.0f, 1f)]
    public float RespawnRateIncrease = 0.015f;

    void Start()
    {
        RespawnTime = Random.Range(7f, 15.5f);
        StartCoroutine(SpawnStones());
    }

    IEnumerator SpawnStones()
    {
        GameObject stenObject = Instantiate(sten, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90));
        stenObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-14.0f, 14.0f),0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(RespawnTime);
        if (RespawnTime >= MaxSpawnRate)
        {
            RespawnTime -= RespawnRateIncrease;
        }
        StartCoroutine(SpawnStones());
    }
}
