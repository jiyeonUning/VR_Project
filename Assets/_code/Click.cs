using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField] GameObject CreateUI;
    [SerializeField] GameObject Gun;

    private Transform GunPos;

    // ��ư Ŭ�� ��,
    public void SelctClick()
    {
        // ��ư ��Ȱ��ȭ
        CreateUI.SetActive(false);
        // ���� ������ ��ġ�� ���� (�ִϸ��̼� ���� �����ϸ� �غ���)
        Instantiate(Gun, GunPos);
    }
}
