using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField] GameObject CreateUI;
    [SerializeField] GameObject Gun;

    private Transform GunPos;

    // 버튼 클릭 시,
    public void SelctClick()
    {
        // 버튼 비활성화
        CreateUI.SetActive(false);
        // 총을 지정된 위치에 생성 (애니메이션 구현 가능하면 해보자)
        Instantiate(Gun, GunPos);
    }
}
