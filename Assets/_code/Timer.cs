using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] UIManager manager;
    [SerializeField] int TimeCount;

    [SerializeField] TextMeshProUGUI TimeText;

    private void Awake()
    {
        manager = GetComponent<UIManager>();
    }

    private void Update()
    {
        if (manager.isRunning)
        {
            TimeCount = 90;
            StartCoroutine(TimerUse());
        }
        else if (manager.isRunning == false)
        {
            TimeCount = 0;
        }
        else return;
    }

    IEnumerator TimerUse()
    {
            while (TimeCount > 0)
            {
               TimeText.text = TimeCount.ToString();

                yield return new WaitForSeconds(Time.deltaTime);

                TimeCount--;
            }
    }
}
