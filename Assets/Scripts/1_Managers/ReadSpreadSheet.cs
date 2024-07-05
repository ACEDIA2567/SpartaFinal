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

    // key      > 스프   레드 시트 주제
    // value    > 스프레드시트 데이터 (처음엔 링크)
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

            // 딕셔너리의 value 값 변경
            sheetDatas[type] = www.downloadHandler.text;

            if (type == typeof(EnemyStatus))
            {
                enemys = GetDatasAsChildren<EnemyStatus>(sheetDatas[type]);

                foreach (EnemyStatus enemyStatus in enemys)
                {
                    // 저장된 enemy 정보들 처리

                    // Resource의 오브젝트에 해당 정보 전달
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

        // 셀의 행의 값을 배열에 저장 (농부, 냥꾼 등 각 내용을 배열에 저장한다는 뜻)
        string[] splitedData = data.Split('\n');

        // 저장한 배열의 값에 접근
        foreach (string element in splitedData)
        {
            // 해당 객체의 정보를 배열에 저장(농부의 체력, 공격력 등 내용을 배열에 저장)
            string[] datas = element.Split('\t');
            dataList.Add(GetData<T>(datas, datas[0]));
        }

        return dataList;
    }

    T GetData<T>(string[] datas, string typeName = "")
    {
        object data;

        // childType이 비어있거나 그런 Type이 없을 때
        if (string.IsNullOrEmpty(typeName) || Type.GetType(typeName) == null)
        {
            data = Activator.CreateInstance(typeof(T));
        }
        else
        {
            data = Activator.CreateInstance(Type.GetType(typeName));
        }

        // 클래스에 있는 변수들을 순서대로 저장한 배열 (순서대로 진행이 되므로 스프레드시트와 클래스의 순서가 같아야함)
        FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        for (int i = 0; i < datas.Length; i++)
        {
            // 필드의 내용을 인스턴스 data에 저장
            try
            {
                // string > parse
                // EnemyStatus에 선언한 변수들의 순서대로 타입을 확인
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
