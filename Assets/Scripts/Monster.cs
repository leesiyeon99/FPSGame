using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField] MonsterSpawner monsterSpawner;
    [SerializeField] PlayerController playerController;
    float maxHp = 10;
    float curHp = 10;

    public UnityEvent<Monster> onDied;
    public void Die()
    {
        monsterSpawner.Respawn(this);
        gameObject.SetActive(false);
        playerController.GetScore();
    }

    public void getAttack(int damage)
    {
        if (curHp <= 0)
        {
            onDied?.Invoke(this);
            Die();
        }

        curHp -= damage;
        Debug.Log($"Ã¼·Â: {curHp}");
    }

    public void ResetHp()
    {
        curHp = maxHp;
    }
}
