using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float returnTime;
    private          float remainTime;


    void OnEnable() { remainTime = returnTime; }

    void Update()
    {
        remainTime -= Time.deltaTime;
        if (remainTime < 0) { Destroy(bulletPrefab); }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �Ѿ��� ������ "Enermy" �±׸� ������ �ִ� ���ʹ̰� �����ǵ��� �Ѵ�. (or ������Ʈ Ǯ ���� ���)
        if (collision.collider.CompareTag("Enermy"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("Enermy") != false) return;
    }
}

