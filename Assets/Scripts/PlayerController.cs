using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] GameManager gameManager;

    public float attack = 1;
    public int score = 0;
    public bool isMoving;

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
                Fire();
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
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit))
        {
            GameObject instance = hit.collider.gameObject;
            Monster monster = instance.GetComponent<Monster>();

            if (monster != null)
            {
                monster.getAttack();
            }
        }
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
