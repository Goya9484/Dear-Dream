using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoMove : MonoBehaviour
{//�÷��̾� ĳ������ �������� ���ۿ� ��ũ��Ʈ

    public Animator animator;//��� �ִϸ��̼�
    Rigidbody myRigid;//ĳ������ rigidbody

    public AudioClip[] voiceSounds;//���� ���带 ����ϱ� ���� ����� Ŭ��
    AudioSource voice;//ĳ������ ���� ȿ��

    Vector3 movement;//3��Ī ���� ���¿����� ĳ���� �̵� ������ ���� vector3��
    Vector3 originPosition = new Vector3(0, 1.5f, 0);//ĳ������ �ʱ� ��ġ��
    Quaternion originQuaternion = Quaternion.Euler(0, 0, 0);//ĳ������ �ʱ� rotation��
    float horizontalMove;//3��Ī �������� ĳ���� �̵��� ���� horizontal �Է°�
    float verticalMove;//3��Ī �������� ĳ���� �̵��� ���� vertical �Է°�

    bool isJumpFlag;//ĳ������ �������� ������ ���� �÷���
    bool isGround;//ĳ������ ������ ���� ground Ȯ�ο� �÷���
    bool isHeadCameraFlag;//1��Ī ���������� ��� on�� ���� �÷���
    public static bool isViewFlag;//1��Ī/3��Ī �� �������� �̵� ���� ��ȯ�� ���� �÷���

    private float mouseTurnSpeed = 4.0f;//1��Ī �������� rotation ��ȭ �ӵ�
    private float moveSpeed = 5.0f;//ĳ������ �̵� �ӵ�
    private float rotateSpeed = 5.0f;//3��Ī �������� rotation ��ȭ �ӵ�
    private float jumpPower = 5.0f;//ĳ������ ���� ����
    private float xRotate = 0.0f;//1��Ī �������� ĳ������ �ʱ� x��ǥ rotation ��

    public GameObject lunchMessage;//���ö� â�� ���� �޼��� �ڽ�
    public GameObject talkMessage;//���� & ���������� ��ȭ ���� �޼��� �ڽ�

    public GameObject inven;//�κ��丮
    bool isInvenFlag;//�κ��丮 on/off Ȯ�� �÷���

    public GameObject fireBall;//���̾� �� ����
    public GameObject ice;//���̽� ����
    public GameObject spear;//���Ǿ� ����

    public GameObject aim;//1��Ī �������� ������

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigid = GetComponent<Rigidbody>();
        voice = GetComponent<AudioSource>();

        isGround = true;
        isViewFlag = true;

        //�׽�Ʈ�� ���� flag on
        //InvenManager.isFireBallFlag = true;
        //InvenManager.isIceFlag = true;
        //InvenManager.isSpearFlag = true;
        //InvenManager.isLunchBoxFlag = true;
        //InvenManager.isTalkFlag = true;
    }

    void Update()
    {
        //1��Ī ���� ī�޶� on/off�� Ȯ���ϱ� ���� flag ����
        isHeadCameraFlag = GameObject.FindWithTag("Head").GetComponent<Camera>().enabled;

        //�κ��丮 on/off ��� ���
        if (Input.GetKeyDown(KeyCode.E))
            if (isInvenFlag == false)
            {
                //�κ��丮 ȭ�鿡 ���� ���� ����� �Ͻ�����
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Pause();
                inven.SetActive(true);
                Cursor.lockState = CursorLockMode.None;//�κ��丮 ȭ�鿡�� ���콺 Ŀ�� ��Ÿ����
                isInvenFlag = true;
            }
            else if (isInvenFlag == true)
            {
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
                inven.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                isInvenFlag = false;
            }

        //1��Ī/3��Ī ���� ��ȯ ���
        if (Input.GetKeyDown(KeyCode.Q))
        {//�ʱ� ������ 3��Ī ����
            if (GameObject.FindWithTag("Head").GetComponent<Camera>().enabled == false)
            {//�±� Head ������Ʈ�� ī�޶� off�϶��� 3��Ī �����̹Ƿ� 1��Ī ������ ���� on
                GameObject.FindWithTag("Head").GetComponent<Camera>().enabled = true;
                aim.SetActive(true);//1��Ī �������� ������ Ȱ��ȭ
                Cursor.lockState = CursorLockMode.Locked;//���콺 Ŀ�� �߾� ���� �� �����
                isViewFlag = false;//1��Ī/3��Ī �������� ĳ���� �̵� ���� ����
            }
            else if (GameObject.FindWithTag("Head").GetComponent<Camera>().enabled == true)
            {
                GameObject.FindWithTag("Head").GetComponent<Camera>().enabled = false;
                aim.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                isViewFlag = true;
            }
        }

        //���̾� �� ���� ��� ���
        if (Input.GetKeyDown(KeyCode.Alpha1) && InvenManager.isFireBallFlag == true)
        {//������ ����߸� ��� �����ϰ� ���ǽĿ� && ���
            voice.clip = voiceSounds[0];//���̾� �� ���� ���� ����
            voice.Play();//����� �ҽ� ���
            animator.SetBool("attack", true);//���� ���� �ִϸ��̼� ���
            Instantiate(fireBall, GameObject.FindWithTag("Head").
                transform.position, transform.rotation);//������ �߻� ��ġ(Head �±� ������Ʈ ��)
            if (fireBall.activeSelf == false)//���� ������Ʈ Ȱ��ȭ
                fireBall.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1) && InvenManager.isFireBallFlag == true)
            animator.SetBool("attack", false);//���� ���� �ִϸ��̼��� 1ȸ�� ����Ǳ� ���� �κ�

        //���̽� ���� ��� ���(���̾� �� ���� ��� ������ ����)
        if (Input.GetKeyDown(KeyCode.Alpha2) && InvenManager.isIceFlag == true)
        {
            voice.clip = voiceSounds[1];
            voice.Play();
            animator.SetBool("attack", true);
            Instantiate(ice, GameObject.FindWithTag("Head").
                transform.position, transform.rotation);
            if (ice.activeSelf == false)
                ice.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2) && InvenManager.isIceFlag == true)
            animator.SetBool("attack", false);

        //���Ǿ� ���� ��� ���(���̾� �� ���� ��� ������ ����)
        if (Input.GetKeyDown(KeyCode.Alpha3) && InvenManager.isSpearFlag == true)
        {
            voice.clip = voiceSounds[2];
            voice.Play();
            animator.SetBool("attack", true);
            Instantiate(spear, GameObject.FindWithTag("Head").
                transform.position, transform.rotation);
            if (spear.activeSelf == false)
                spear.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3) && InvenManager.isSpearFlag == true)
            animator.SetBool("attack", false);

        //���ö� â�� ���� ���
        if (Input.GetKeyDown(KeyCode.Alpha4) && InvenManager.isLunchBoxFlag == true)
        {//���ö� â�� ���� �ؽ�Ʈ �ڽ� ���
            Instantiate<GameObject>(lunchMessage, new Vector3(0,0,0), Quaternion.identity);
            lunchMessage.SetActive(true);
        }

        //���� & ���������� ��ȭ ���� ���(���ö� â�� ���� ��� ������ ����)
        if (Input.GetKeyDown(KeyCode.Alpha5) && InvenManager.isTalkFlag == true)
        {
            Instantiate<GameObject>(talkMessage, new Vector3(0, 0, 0), Quaternion.identity);
            talkMessage.SetActive(true);
        }

        //ĳ���� ���� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("idle jump", true);//���� �ִϸ��̼� ���
            isJumpFlag = true;//���� ���� ������ ���� �÷��� on
        }
        else if (Input.GetKeyUp(KeyCode.Space))
            animator.SetBool("idle jump", false);

        //1��Ī/3��Ī �� ������ �̵� ���� ���
        if (isViewFlag)
        {//3��Ī ���� �̵� ���� ���
            if (Input.GetKey(KeyCode.D))
            {//Ⱦ��ũ���� �⺻ ȭ���̹Ƿ� ������ ������ ����
                animator.SetBool("forward", true);//�̵� �ִϸ��̼� ���
                horizontalMove = 0;//hotizontal �� ����
                verticalMove = 1;//vertical �� ����
                Run();//ĳ���� �̵� ���
                Turn();//ĳ���� ���� ��ȯ ���
                if (Input.GetKeyDown(KeyCode.Space))//�̵��� ���� �Է� �޾�����
                {
                    animator.SetBool("run jump", true);//�޸��� �� ���� �ִϸ��̼� ���
                    isJumpFlag = true;//���� ���� ������ ���� �÷��� on
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                    animator.SetBool("run jump", false);
            }
            else if (Input.GetKeyUp(KeyCode.D))//���� �� ���� �̵� ����Ű �Է�
            {
                animator.SetBool("forward", false);
                horizontalMove = 0;
                verticalMove = 0;
            }

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("left", true);
                horizontalMove = -1;
                verticalMove = 0;
                Run();
                Turn();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("run jump", true);
                    isJumpFlag = true;
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                    animator.SetBool("run jump", false);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("left", false);
                horizontalMove = 0;
                verticalMove = 0;
            }

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("back", true);
                horizontalMove = 0;
                verticalMove = -1;
                Run();
                Turn();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("run jump", true);
                    isJumpFlag = true;
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                    animator.SetBool("run jump", false);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("back", false);
                horizontalMove = 0;
                verticalMove = 0;
            }

            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("right", true);
                horizontalMove = 1;
                verticalMove = 0;
                Run();
                Turn();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("run jump", true);
                    isJumpFlag = true;
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                    animator.SetBool("run jump", false);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("right", false);
                horizontalMove = 0;
                verticalMove = 0;
            }
        }
        else//1��Ī ���� �̵� ���� ���
        {
            MouseRotation();//���콺�� 1��Ī ���� rotation ���� ���
            KeyboardMove();//3��Ī �����϶��� �ٸ� �̵� ���� ���(������ ����Ű�� D(������Ű)�� ����ϹǷ�)
        }

        //ĳ���� ���� ���
        if (transform.position.y <= -21)
            FallDown();//ĳ���� ���� ���
    }

    void FixedUpdate()
    {//�̵��� ������ȯ�� �ֱ������� Ȯ���ؾ��ϹǷ� FixedUpdate���� ����
        Run();
        Turn();
        
        if (isGround)//�ߺ� ���� ������ ���� ground ���� �������� ���� ����
            Jump();
    }

    void FallDown()
    {//����� �ʱ� ��ġ�� �̵�
        transform.position = originPosition;//���� ��ġ�� �ʱ���ġ��
        transform.rotation = originQuaternion;//���� ������ �ʱ��������
    }

    void Run()
    {
        movement.Set(horizontalMove, 0, verticalMove);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        myRigid.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        if (horizontalMove == 0 && verticalMove == 0)
            return;

        Quaternion playerRotate = Quaternion.LookRotation(movement);

        myRigid.rotation = Quaternion.Slerp(myRigid.rotation, playerRotate,
            rotateSpeed * Time.deltaTime);
    }

    void Lava()
    {
        originPosition = new Vector3(4, -5.5f, 74.5f);
        originQuaternion = Quaternion.Euler(0, -90, 0);

        transform.position = originPosition;
        transform.rotation = originQuaternion;
    }

    void Jump()
    {
        if (!isJumpFlag)
            return;

        voice.clip = voiceSounds[3];
        voice.Play();
        myRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        isGround = false;
        isJumpFlag = false;
    }

    void MouseRotation()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * mouseTurnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;
        float xRotateSize = -Input.GetAxis("Mouse Y") * mouseTurnSpeed;
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }

    void KeyboardMove()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
            isGround = true;

        if (col.gameObject.tag == "Lava")
            Lava();
    }
}