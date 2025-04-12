using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLv : MonoBehaviour
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPages;

    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPages.localPosition;
        Time.timeScale = 1.0f;
    }

    public void Next()
    {
        if(currentPage<maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        levelPages.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
    }
}
