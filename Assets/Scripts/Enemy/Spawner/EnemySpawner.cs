using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum EnemySub
{
    Farmer,
    Hunter,
    Count
}

public enum EnemyCenter
{
    AdventurerM,
    AdventurerR,
    Count
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    GameObject enemy;

    private void Start()
    {
        Invoke("SpawnStart", 1.0f);
    }


    private void SpawnStart()
    {
        enemy = Managers.Pool.Pop(Resources.Load<GameObject>($"Enemy/{(EnemyCenter)(Random.Range(0, (int)EnemyCenter.Count))}"), transform).gameObject;
        SpawnSetting(ref enemy, transform);

        for (int i = 0; i < spawnPoint.Length; i++)
        {
            enemy = Managers.Pool.Pop(Resources.Load<GameObject>($"Enemy/{(EnemySub)(Random.Range(0, (int)EnemySub.Count))}"), spawnPoint[i]).gameObject;
            SpawnSetting(ref enemy, spawnPoint[i]);
        }
    }

    private void SpawnSetting(ref GameObject enemy, Transform transform)
    {
        enemy.transform.position = transform.position;
        enemy.GetComponentInChildren<EnemyMovement>().startPos = transform.position;
        transform.root.GetComponent<MapManager>().AddCount();
    }
}
