using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class ReadSpreadSheet : MonoBehaviour
{
    public readonly string adress = "https://docs.google.com/spreadsheets/d/1XHLzWB_-tvx_nhrLlhWn76zmjmvC3jh6dYxUxJB2LtU";
    public readonly string range = "A2:J";
    public readonly int sheetID = 1488976208;

    public List<EnemyStatus> enemys;

    // key      > ����   ���� ��Ʈ ����
    // value    > ���������Ʈ ������ (ó���� ��ũ)
    private Dictionary<Type, string> sheetDatas = new Dictionary<Type, string>();

    public void Awake()
    {
        sheetDatas.Add(typeof(EnemyStatus), GetCSVAddress(adress, range, sheetID));
    }

    private void Start()
    {
        StartCoroutine(LoadData());
    }

    public IEnumerator LoadData()
    {
        List<Type> sheetTypes = new List<Type>(sheetDatas.Keys);

        foreach (Type type in sheetTypes)
        {
            UnityWebRequest www = UnityWebRequest.Get(sheetDatas[type]);
            yield return www.SendWebRequest();

            // ��ųʸ��� value �� ����
            sheetDatas[type] = www.downloadHandler.text;

            if (type == typeof(EnemyStatus))
            {
                enemys = GetDatasAsChildren<EnemyStatus>(sheetDatas[type]);

                foreach (EnemyStatus enemyStatus in enemys)
                {
                    // ����� enemy ������ ó��

                    // Resource�� ������Ʈ�� �ش� ���� ����
                    GameObject SpawnEnemy = Instantiate(Resources.Load<GameObject>($"Enemy/{enemyStatus.name}"));
                    SpawnEnemy.name = enemyStatus.name;
                    SpawnEnemy.GetComponent<Enemy>().status = enemyStatus;
                }
            }
        }
    }

    public static string GetCSVAddress(string address, string range, long sheetID)
    {
        return $"{address}/export?format=tsv&range={range}&gid={sheetID}";
    }

    List<T> GetDatasAsChildren<T>(string data)
    {
        List<T> dataList = new List<T>();

        // ���� ���� ���� �迭�� ���� (���, �ɲ� �� �� ������ �迭�� �����Ѵٴ� ��)
        string[] splitedData = data.Split('\n');

        // ������ �迭�� ���� ����
        foreach (string element in splitedData)
        {
            // �ش� ��ü�� ������ �迭�� ����(����� ü��, ���ݷ� �� ������ �迭�� ����)
            string[] datas = element.Split('\t');
            dataList.Add(GetData<T>(datas, datas[0]));
        }

        return dataList;
    }

    T GetData<T>(string[] datas, string typeName = "")
    {
        object data;

        // childType�� ����ְų� �׷� Type�� ���� ��
        if (string.IsNullOrEmpty(typeName) || Type.GetType(typeName) == null)
        {
            data = Activator.CreateInstance(typeof(T));
        }
        else
        {
            data = Activator.CreateInstance(Type.GetType(typeName));
        }

        // Ŭ������ �ִ� �������� ������� ������ �迭 (������� ������ �ǹǷ� ���������Ʈ�� Ŭ������ ������ ���ƾ���)
        FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        for (int i = 0; i < datas.Length; i++)
        {
            // �ʵ��� ������ �ν��Ͻ� data�� ����
            try
            {
                // string > parse
                // EnemyStatus�� ������ �������� ������� Ÿ���� Ȯ��
                Type type = fields[i].FieldType;

                if (string.IsNullOrEmpty(datas[i])) continue;

                if (type == typeof(int))
                    fields[i].SetValue(data, int.Parse(datas[i]));

                else if (type == typeof(float))
                    fields[i].SetValue(data, float.Parse(datas[i]));

                else if (type == typeof(bool))
                    fields[i].SetValue(data, bool.Parse(datas[i]));

                else if (type == typeof(string))
                    fields[i].SetValue(data, datas[i]);

                // enum
                else
                    fields[i].SetValue(data, Enum.Parse(type, datas[i]));
            }

            catch (Exception e)
            {
                Debug.LogError($"SpreadSheet Error : {e.Message}");
            }
        }

        return (T)data;
    }
}
