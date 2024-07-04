using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float activationDistance = 5f; // 버튼이 활성화되는 거리
    public GameObject targetObject; // 목표 오브젝트
    public CanvasGroup actionButtonCanvasGroup; // 버튼의 CanvasGroup

    void Start()
    {
        if (actionButtonCanvasGroup != null)
        {
            SetButtonState(false); // 시작할 때 버튼 비활성화
        }
    }

    void Update()
    {
        if (targetObject != null && actionButtonCanvasGroup != null)
        {
            float distance = Vector3.Distance(transform.position, targetObject.transform.position);

            if (distance <= activationDistance)
            {
                SetButtonState(true); // 일정 거리 안에 들어오면 버튼 활성화
            }
            else
            {
                SetButtonState(false); // 일정 거리 밖이면 버튼 비활성화
            }
        }
    }

    void SetButtonState(bool isActive)
    {
        if (isActive)
        {
            actionButtonCanvasGroup.alpha = 1f; // 버튼 완전 보이게
            actionButtonCanvasGroup.interactable = true; // 버튼 상호작용 가능하게
            actionButtonCanvasGroup.blocksRaycasts = true; // 버튼이 레이캐스트를 막게
        }
        else
        {
            actionButtonCanvasGroup.alpha = 0.2f; // 버튼 투명하게
            actionButtonCanvasGroup.interactable = false; // 버튼 상호작용 불가능하게
            actionButtonCanvasGroup.blocksRaycasts = false; // 버튼이 레이캐스트를 막지 않게
        }
    }
}
