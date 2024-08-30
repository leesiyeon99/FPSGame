using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    float hp = 10;
    public void TakeHit()
    {
        playerController.GetScore();
        Debug.Log("���� �ı�");
        Destroy(gameObject);
    }

    public void MonsterAttack()
    {
        if (hp <= 0)
        {
            TakeHit();
        }

        hp -= 1;
        Debug.Log($"ü��: {hp}");
    }
}
