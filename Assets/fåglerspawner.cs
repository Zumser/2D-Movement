using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fåglerspawner : MonoBehaviour
{
    [Header("Prefaben som ska spawnas")]
    public GameObject fågel;

    [Header("Tiden mellan varje fågel")]
    public float RespawnTime;

    [Header("Minimala stunden mellan varje fågel")]
    [Range(0.01f, 0.2f)]
    public float MaxSpawnRate;

    [Header("Hur snabbt antalet fågel ökar med tiden")]
    [Range(0.1f, 0.02f)]
    public float RespawnRateIncrease = 0.01f;

    void Start()
    {
        RespawnTime = Random.Range(7f, 15.5f);
        StartCoroutine(Spawnbirds());
    }

    IEnumerator Spawnbirds()
    {
        GameObject stenObject = Instantiate(fågel, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90));
        stenObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-8.0f, 8.0f), 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(RespawnTime);
        if (RespawnTime >= MaxSpawnRate)
        {
            RespawnTime -= RespawnRateIncrease;
        }
        StartCoroutine(Spawnbirds());
    }
}
