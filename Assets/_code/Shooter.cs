using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [SerializeField] ParticleSystem ShotParticle; // 발포 효과 재생
    [SerializeField] AudioSource fireSound;       // 발포음 재생료

    [Header("Bullet")]
    [SerializeField] GameObject bulletPrefab;     // 총알 생성
    [SerializeField] Transform muzzlePoint;       // 생성 위치
    [SerializeField] float ShootSpeed;            // 총알 빠르기
    [SerializeField] float Wait;                  // 연사 주기

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
                Debug.Log("게임 시작!");
                uiManager.isRunning = true;
            }
    }


    // 손에서 총이 떨어졌을 때, 게임은 중지되고 처음을 다시 돌아간다
    public void GrabEnd()
    {
            uiManager.isRunning = false;

            if (uiManager.isRunning == false)
            {
                Debug.Log("게임 종료!");
                uiManager.ScreenAni.Play("Up");
            }
            else return;
    }
}
