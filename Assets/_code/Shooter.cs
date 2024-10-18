using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] ParticleSystem ShotParticle; // 발포 효과 재생
    [SerializeField] AudioSource fireSound;       // 발포음 재생

    [SerializeField] GameObject bulletPrefab;     // 총알 생성
    [SerializeField] Transform muzzlePoint;       // 생성 위치
    [SerializeField] float ShootSpeed;            // 총알 빠르기
    [SerializeField] float Wait;                  // 연사 주기

    private bool fireOnOff = false;

    public void FireOn()
    {
        if (fireOnOff == false)
        {
            fireOnOff = true;
        }
        StartCoroutine(Shooting());
    }
    public void FireOff()
    {
        if (fireOnOff) { fireOnOff = false; }
    }

    void Shot()
    {
        ShotParticle.Play();
        fireSound.Play();

        GameObject shot = Instantiate(bulletPrefab, muzzlePoint.transform.position, muzzlePoint.transform.rotation);
        Rigidbody rigidbody = shot.GetComponent<Rigidbody>();
        rigidbody.velocity = ShootSpeed * muzzlePoint.forward;
    }

    IEnumerator Shooting()
    {
        while (fireOnOff)
        {
            Shot();
            yield return new WaitForSeconds(Wait);
        }
    }
}
