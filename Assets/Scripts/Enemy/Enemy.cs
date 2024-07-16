using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public EnemyStatus status;
    public GameObject soul;

    public Transform target;

    protected virtual void Awake()
    {
        // 싱글톤 또는 Find로 플레이어 위치 검색
        target = GameObject.Find("Player").transform;
    }

    private void EnemyDie()
    {
        for (int i = 0; i < status.soul; i++)
        {
            GameObject souls = Managers.Pool.Pop(soul, transform.parent.parent).gameObject;
            souls.GetComponent<Soul>().GetTarget(target);
            souls.transform.position = transform.position;
        }
        transform.root.GetComponent<MapManager>().SubtractCount();
        Managers.Pool.Push(transform.parent.gameObject);
    }
}
