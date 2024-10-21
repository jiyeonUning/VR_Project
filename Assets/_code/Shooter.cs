using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [SerializeField] ParticleSystem ShotParticle; // ���� ȿ�� ���
    [SerializeField] AudioSource fireSound;       // ������ �����

    [Header("Bullet")]
    [SerializeField] GameObject bulletPrefab;     // �Ѿ� ����
    [SerializeField] Transform muzzlePoint;       // ���� ��ġ
    [SerializeField] float ShootSpeed;            // �Ѿ� ������
    [SerializeField] float Wait;                  // ���� �ֱ�

    private bool fireOnOff = false;

    [Header("UI")]
    [SerializeField] GameObject uiOBJ;
    [SerializeField] UIManager uiManager;

    private void Awake()
    {
        uiOBJ = GameObject.FindGameObjectWithTag("UIManager");
        uiManager = uiOBJ.GetComponent<UIManager>();
    }

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


    // ==== ==== ====


    public void GrabStart()
    {
            uiManager.ScreenAni.Play("Down");
            uiManager.CountdownTextMesh.SetActive(true);
            uiManager.CountDownUse();

            if (uiManager.countdownTime < 0)
            {
                Debug.Log("���� ����!");
                uiManager.isRunning = true;
            }
    }


    // �տ��� ���� �������� ��, ������ �����ǰ� ó���� �ٽ� ���ư���
    public void GrabEnd()
    {
            uiManager.isRunning = false;

            if (uiManager.isRunning == false)
            {
                Debug.Log("���� ����!");
                uiManager.ScreenAni.Play("Up");
            }
            else return;
    }
}
