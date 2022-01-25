using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoMove : MonoBehaviour
{//플레이어 캐릭터의 전반적인 조작용 스크립트

    public Animator animator;//사용 애니메이션
    Rigidbody myRigid;//캐릭터의 rigidbody

    public AudioClip[] voiceSounds;//여러 사운드를 사용하기 위한 오디오 클립
    AudioSource voice;//캐릭터의 사운드 효과

    Vector3 movement;//3인칭 시점 상태에서의 캐릭터 이동 조작을 위한 vector3값
    Vector3 originPosition = new Vector3(0, 1.5f, 0);//캐릭터의 초기 위치값
    Quaternion originQuaternion = Quaternion.Euler(0, 0, 0);//캐릭터의 초기 rotation값
    float horizontalMove;//3인칭 시점에서 캐릭터 이동을 위한 horizontal 입력값
    float verticalMove;//3인칭 시점에서 캐릭터 이동을 위한 vertical 입력값

    bool isJumpFlag;//캐릭터의 다중점프 방지를 위한 플래그
    bool isGround;//캐릭터의 점프를 위한 ground 확인용 플래그
    bool isHeadCameraFlag;//1인칭 시점에서의 기능 on을 위한 플래그
    public static bool isViewFlag;//1인칭/3인칭 각 시점에서 이동 조작 전환을 위한 플래그

    private float mouseTurnSpeed = 4.0f;//1인칭 시점에서 rotation 변화 속도
    private float moveSpeed = 5.0f;//캐릭터의 이동 속도
    private float rotateSpeed = 5.0f;//3인칭 시점에서 rotation 변화 속도
    private float jumpPower = 5.0f;//캐릭터의 점프 높이
    private float xRotate = 0.0f;//1인칭 시점에서 캐릭터의 초기 x좌표 rotation 값

    public GameObject lunchMessage;//도시락 창조 마법 메세지 박스
    public GameObject talkMessage;//생물 & 무생물과의 대화 마법 메세지 박스

    public GameObject inven;//인벤토리
    bool isInvenFlag;//인벤토리 on/off 확인 플래그

    public GameObject fireBall;//파이어 볼 마법
    public GameObject ice;//아이스 마법
    public GameObject spear;//스피어 마법

    public GameObject aim;//1인칭 시점에서 조준점

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigid = GetComponent<Rigidbody>();
        voice = GetComponent<AudioSource>();

        isGround = true;
        isViewFlag = true;

        //테스트용 마법 flag on
        //InvenManager.isFireBallFlag = true;
        //InvenManager.isIceFlag = true;
        //InvenManager.isSpearFlag = true;
        //InvenManager.isLunchBoxFlag = true;
        //InvenManager.isTalkFlag = true;
    }

    void Update()
    {
        //1인칭 시점 카메라 on/off를 확인하기 위한 flag 설정
        isHeadCameraFlag = GameObject.FindWithTag("Head").GetComponent<Camera>().enabled;

        //인벤토리 on/off 토글 기능
        if (Input.GetKeyDown(KeyCode.E))
            if (isInvenFlag == false)
            {
                //인벤토리 화면에 들어갈땐 게임 배경음 일시정지
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Pause();
                inven.SetActive(true);
                Cursor.lockState = CursorLockMode.None;//인벤토리 화면에선 마우스 커서 나타내기
                isInvenFlag = true;
            }
            else if (isInvenFlag == true)
            {
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
                inven.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                isInvenFlag = false;
            }

        //1인칭/3인칭 시점 변환 기능
        if (Input.GetKeyDown(KeyCode.Q))
        {//초기 시점은 3인칭 시점
            if (GameObject.FindWithTag("Head").GetComponent<Camera>().enabled == false)
            {//태그 Head 오브젝트의 카메라가 off일때는 3인칭 시점이므로 1인칭 시점을 위해 on
                GameObject.FindWithTag("Head").GetComponent<Camera>().enabled = true;
                aim.SetActive(true);//1인칭 시점에서 조준점 활성화
                Cursor.lockState = CursorLockMode.Locked;//마우스 커서 중앙 고정 및 숨기기
                isViewFlag = false;//1인칭/3인칭 시점에서 캐릭터 이동 조작 변경
            }
            else if (GameObject.FindWithTag("Head").GetComponent<Camera>().enabled == true)
            {
                GameObject.FindWithTag("Head").GetComponent<Camera>().enabled = false;
                aim.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                isViewFlag = true;
            }
        }

        //파이어 볼 마법 사용 기능
        if (Input.GetKeyDown(KeyCode.Alpha1) && InvenManager.isFireBallFlag == true)
        {//마법을 배워야만 사용 가능하게 조건식에 && 사용
            voice.clip = voiceSounds[0];//파이어 볼 마법 전용 음성
            voice.Play();//오디오 소스 재생
            animator.SetBool("attack", true);//마법 공격 애니메이션 재생
            Instantiate(fireBall, GameObject.FindWithTag("Head").
                transform.position, transform.rotation);//마법의 발생 위치(Head 태그 오브젝트 앞)
            if (fireBall.activeSelf == false)//마법 오브젝트 활성화
                fireBall.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1) && InvenManager.isFireBallFlag == true)
            animator.SetBool("attack", false);//마법 공격 애니메이션이 1회만 재생되기 위한 부분

        //아이스 마법 사용 기능(파이어 볼 마법 기능 구현과 동일)
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

        //스피어 마법 사용 기능(파이어 볼 마법 기능 구현과 동일)
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

        //도시락 창조 마법 기능
        if (Input.GetKeyDown(KeyCode.Alpha4) && InvenManager.isLunchBoxFlag == true)
        {//도시락 창조 마법 텍스트 박스 출력
            Instantiate<GameObject>(lunchMessage, new Vector3(0,0,0), Quaternion.identity);
            lunchMessage.SetActive(true);
        }

        //생물 & 무생물과의 대화 마법 기능(도시락 창조 마법 기능 구현과 동일)
        if (Input.GetKeyDown(KeyCode.Alpha5) && InvenManager.isTalkFlag == true)
        {
            Instantiate<GameObject>(talkMessage, new Vector3(0, 0, 0), Quaternion.identity);
            talkMessage.SetActive(true);
        }

        //캐릭터 점프 기능
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("idle jump", true);//점프 애니메이션 재생
            isJumpFlag = true;//다중 점프 방지를 위한 플래그 on
        }
        else if (Input.GetKeyUp(KeyCode.Space))
            animator.SetBool("idle jump", false);

        //1인칭/3인칭 각 시점의 이동 조작 기능
        if (isViewFlag)
        {//3인칭 시점 이동 조작 기능
            if (Input.GetKey(KeyCode.D))
            {//횡스크롤이 기본 화면이므로 오른쪽 방향이 전진
                animator.SetBool("forward", true);//이동 애니메이션 재생
                horizontalMove = 0;//hotizontal 값 설정
                verticalMove = 1;//vertical 값 설정
                Run();//캐릭터 이동 기능
                Turn();//캐릭터 방향 전환 기능
                if (Input.GetKeyDown(KeyCode.Space))//이동중 점프 입력 받았을때
                {
                    animator.SetBool("run jump", true);//달리는 중 점프 애니메이션 재생
                    isJumpFlag = true;//다중 점프 방지를 위한 플래그 on
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                    animator.SetBool("run jump", false);
            }
            else if (Input.GetKeyUp(KeyCode.D))//이하 각 방향 이동 조작키 입력
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
        else//1인칭 시점 이동 조작 기능
        {
            MouseRotation();//마우스로 1인칭 시점 rotation 조작 기능
            KeyboardMove();//3인칭 시점일때와 다른 이동 조작 기능(앞으로 전진키가 D(오른쪽키)면 어색하므로)
        }

        //캐릭터 낙사 기능
        if (transform.position.y <= -21)
            FallDown();//캐릭터 낙사 기능
    }

    void FixedUpdate()
    {//이동과 방향전환은 주기적으로 확인해야하므로 FixedUpdate에서 관리
        Run();
        Turn();
        
        if (isGround)//중복 점프 방지를 위해 ground 위에 있을때만 점프 가능
            Jump();
    }

    void FallDown()
    {//낙사시 초기 위치로 이동
        transform.position = originPosition;//현재 위치를 초기위치로
        transform.rotation = originQuaternion;//현재 방향을 초기방향으로
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