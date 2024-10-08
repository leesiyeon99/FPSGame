using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] GameManager gameManager;

    public int score = 0;
    public bool isMoving;

    [SerializeField] int MaxBullet = 30;
    [SerializeField] int CurBullet = 30;
    [SerializeField] float repeatTime = 0.2f;
    [SerializeField] float reloadTime = 2f;
    [SerializeField] bool isReloading;
    [SerializeField] public int attack = 1;

    Coroutine fireRoutine;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update()
    {
        if (isMoving)
        {
            Look();
            Move();

            if (Input.GetMouseButtonDown(0))
            {
                fireRoutine = StartCoroutine(FireRoutine());
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopCoroutine(fireRoutine);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
    }

    public void Look()
    {
        float x = Input.GetAxis("Mouse X"); //마우스 좌우 움직임량
        float y = Input.GetAxis("Mouse Y"); //마우스 위아래 움직임량

        transform.Rotate(Vector3.up, rotateSpeed * x * Time.deltaTime);
        camTransform.Rotate(Vector3.right, rotateSpeed * -y * Time.deltaTime);
    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * x * moveSpeed * Time.deltaTime);
    }

    private void Fire()
    {
        if(CurBullet <= 0)
        {
            Debug.Log("탄알 부족, 재장전키는 R입니다.");
            return;
        }
        if (isReloading)
        {
            Debug.Log("재장전 중..");
            return;
        }

        CurBullet--;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit))
        {
            GameObject instance = hit.collider.gameObject;
            Monster monster = instance.GetComponent<Monster>();

            if (monster != null)
            {
                monster.getAttack(attack);
            }
        }
    }

    IEnumerator FireRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(repeatTime);

        while (true)
        {
            Fire();
            yield return delay;
        }
    }

    IEnumerator ReloadRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(reloadTime);
        Debug.Log("재장전 시작");
        isReloading = true;
        yield return delay;
        CurBullet = MaxBullet;
        isReloading = false;
        Debug.Log("재장전 완료");
    }


    private void Reload()
    {
        if (isReloading) return;
        StartCoroutine(ReloadRoutine());
    }
    public void PlayerMove()
    {
        isMoving = true;
    }

    public void PlayerStop()
    {
        isMoving = false;
    }

    public int GetScore()
    {
        this.score += 5;
        return this.score;
    }
}
