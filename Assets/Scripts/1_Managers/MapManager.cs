using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private int count = 0;
    [SerializeField] private GameObject nextDoor;

    public void AddCount()
    {
        count++;
    }

    public void SubtractCount()
    {
        count--;
        if (count == 0)
        {
            nextDoor.SetActive(false);
        }
    }
}
