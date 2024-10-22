using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] UIManager manager;

    [Header("Timer UI")]
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] public int TimeCount;

    [Header("Score UI")]
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] public int ScoreCount;

    [Header("Animator")]
    [SerializeField] public Animator animator;
    public int frontHash = Animator.StringToHash("front");
    public int backHash = Animator.StringToHash("back");



    private void Awake()
    {
        manager = GetComponent<UIManager>();
    }

    // 작동자체가 되지 않는 상황
    // 해당 기능을 함수로 만들어서 카운트 코루틴 진행 후 재생시켜보는건 어떨까?
    public void TimerUsing()
    {
        TimeCount = 90;
        ScoreCount = 0;
        animator.Play(backHash);
        // 스코어가 올라가는 코루틴 추가
        StartCoroutine(TimerUse());
    }

    IEnumerator TimerUse()
    {
        while (TimeCount > 0)
        {
            TimeText.text = TimeCount.ToString();

            yield return new WaitForSeconds(1f);

            TimeCount--;
        }
    }
}
