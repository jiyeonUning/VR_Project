using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] ParticleSystem ShotParticle; // ���� ȿ�� ���
    [SerializeField] AudioSource fireSound;       // ������ ���

    [SerializeField] GameObject bulletPrefab;     // �Ѿ� ����
    [SerializeField] Transform muzzlePoint;       // ���� ��ġ
    [SerializeField] float ShootSpeed;            // �Ѿ� ������
    [SerializeField] float Wait;                  // ���� �ֱ�

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
