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
        // 총알이 닿으면 "Enermy" 태그를 가지고 있는 에너미가 삭제되도록 한다. (or 오브젝트 풀 패턴 사용)
        if (collision.collider.CompareTag("Enermy"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("Enermy") != false) return;
    }
}

