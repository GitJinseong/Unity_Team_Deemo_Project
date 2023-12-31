using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Park_OnClickEffectBackground : MonoBehaviour
{
    public Park_MoveContent moveContent;

    public GameObject difficulty;
    public GameObject backBtn;

    // 세팅 창이 활성화 되게 하기 위한 변수
    public GameObject settingUi;

    // 노래 제목이 호출되는 위치
    public GameObject titleSave;

    // 노래 제목 프리팹
    public GameObject title;

    // 노래를 제목을 저장할 리스트
    List<GameObject> titleList = new List<GameObject>();

    // 원의 중심 좌표
    public Vector2 centerPos = Vector2.zero;

    // 처음 클릭한 마우스 위치
    private Vector2 StartMousePosition;

    // 현재 마우스 위치
    private Vector2 MoveMousePosition;

    // 현재 드래그 속도
    public float currentVelocity;

    // 원의 반지름
    private float radius = 5f;

    // 이전 프레임의 시간
    private float lastFrameTime;

    private float duration = 0.5f;

    // 버튼이 눌리고 있는지 확인
    private bool isPressed = false;

    // 버튼 클릭을 확인
    private bool isPoint = false;

    // 처음 SettingUi 호출 체크
    private bool isCheck = false;

    private bool isCoroutine = false;

    // Start is called before the first frame update
    void Start()
    {
        settingUi.SetActive(false);

        //Instantiate(titleList[0], centerPos + new Vector2(radius* 1.5f * Mathf.Cos(0.0f * Mathf.Deg2Rad), radius * Mathf.Sin(0.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
        //Instantiate(titleList[1], centerPos + new Vector2(radius * 1.5f * Mathf.Cos(-12.0f * Mathf.Deg2Rad), radius * Mathf.Sin(-12.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
        //Instantiate(titleList[2], centerPos + new Vector2(radius * 1.5f * Mathf.Cos(-24.0f * Mathf.Deg2Rad), radius * Mathf.Sin(-24.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
        //Instantiate(titleList[3], centerPos + new Vector2(radius * 1.5f * Mathf.Cos(-36.0f * Mathf.Deg2Rad), radius * Mathf.Sin(-36.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
        //Instantiate(titleList[4], centerPos + new Vector2(radius * 1.5f * Mathf.Cos(-48.0f * Mathf.Deg2Rad), radius * Mathf.Sin(-48.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == true)
        {
            MoveMousePosition = Input.mousePosition;

            currentVelocity = StartMousePosition.y - MoveMousePosition.y;
        }

        if (StartMousePosition != (Vector2)Input.mousePosition)
        {
            isPoint = false;
        }

        //Vector2 currentMousePosition = Input.mousePosition;
        //float currentTime = Time.time;

        //// 프레임 간의 시간 간격을 계산
        //float deltaTime = currentTime - lastFrameTime;

        //// 프레임 간의 위치 변화를 계산
        //Vector2 deltaPosition = currentMousePosition - lastMousePosition;

        //// 위아래 드래그 속도 계산
        //currentVelocity = deltaPosition.y / deltaTime;

        //// 계산된 속도를 활용하여 원하는 동작 수행
        //// 예: 오브젝트 이동, 파라미터 변경 등

        //// 이번 프레임의 값들을 다음 프레임에 사용하기 위해 저장
        //lastMousePosition = currentMousePosition;
        //lastFrameTime = currentTime;

        //// 위아래 드래그 속도를 디버그 로그로 출력
        //Debug.Log("Vertical Drag Speed: " + verticalVelocity);
    }

    private void OnMouseDown()
    {
        moveContent.GetComponent<Park_MoveContent>().scrollRect.inertia = true;
        moveContent.GetComponent<Park_MoveContent>().isStop = true;
        StartMousePosition = Input.mousePosition;

        isPoint = true;

        isPressed = true;
    }

    private void OnMouseUp()
    {
        moveContent.GetComponent<Park_MoveContent>().isScrolling = true;

        if (isCoroutine == false && settingUi.GetComponent<Park_OnClickSettingUi>().isCoroutine == false)
        {
            if (isPoint == true)
            {
                if (isCheck == false)
                {
                    if (settingUi.activeSelf == false)
                    {
                        difficulty.GetComponent<CircleCollider2D>().radius = 0;
                        backBtn.GetComponent<CircleCollider2D>().radius = 0;

                        settingUi.SetActive(true);
                        settingUi.SetActive(false);
                        settingUi.SetActive(true);
                    }
                    else
                    {
                        difficulty.GetComponent<CircleCollider2D>().radius = 80;
                        backBtn.GetComponent<CircleCollider2D>().radius = 30;

                        StartCoroutine(AlphaDown());
                    }

                }
                else
                {
                    if (settingUi.activeSelf == false)
                    {
                        difficulty.GetComponent<CircleCollider2D>().radius = 0;
                        backBtn.GetComponent<CircleCollider2D>().radius = 0;

                        settingUi.SetActive(true);
                    }
                    else
                    {
                        difficulty.GetComponent<CircleCollider2D>().radius = 80;
                        backBtn.GetComponent<CircleCollider2D>().radius = 30;

                        StartCoroutine(AlphaDown());
                    }
                }

                isCheck = true;
            }
        }

        isPressed = false;
    }

    private IEnumerator AlphaDown()
    {
        isCoroutine = true;

        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            float time = Mathf.Clamp01(timeElapsed / duration);

            settingUi.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1.0f, 0.0f, time);

            yield return null;
        }

        settingUi.SetActive(false);

        isCoroutine = false;
    }

    //private IEnumerator Frame()
    //{
    //    settingUi.SetActive(true);

    //    yield return null;

    //    settingUi.SetActive(false);
    //    settingUi.SetActive(true);
    //}
}
