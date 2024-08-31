using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] Monster[] monsters;
    [SerializeField] float respawnTime = 3;
    [SerializeField] float randomPosition;

    public void Respawn(Monster monster)
    {
        StartCoroutine(RespawnRoutine(monster));
    }

    IEnumerator RespawnRoutine(Monster monster)
    {
        monster.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);

        monster.transform.position = RandPos();
        monster.gameObject.SetActive(true);
        monster.ResetHp();
    }

    private Vector3 RandPos()
    {
        Vector3 randPos = new Vector3(Random.Range(-randomPosition, randomPosition), 1f, Random.Range(-randomPosition, randomPosition));
        return randPos;
    }
}
