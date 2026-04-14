using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//유니티에서 함수의 이름의 첫 번째 글자는 대문자
public class Player : MonoBehaviour
{
    public Vector2 inputVec;//변수 타입 + 변수 이름(의미 부여를 해서 식별 가능하도록 이름 정하기), public을 이용해 inputvec값 변화 확인
    public float speed;

    Rigidbody2D rigid;//Rigidbody 2D를 저장할 변수 선언

    void Awake()//시작할 때 한번만 실행되는 생명주기 Awake
    {
        rigid = GetComponent<Rigidbody2D>();//변수 선언 후 초기화, 플레이어 안에 있는 Rigidbody2D가 rigid 변수에 들어감
    }

    void Update() //하나의 프레임마다 한번씩 호출되는 생명주기 함수(60프레임 기준으로 1초에 60번 실행된다)
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");//수평
        inputVec.y = Input.GetAxisRaw("Vertical");//수직
    }

    void FixedUpdate() //물리 연산 프레임마다 호출되는 생명주기 함수
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; //normalized - 벡터 값의 크기가 1이 되도록 좌표가 수정된 값
                                                                             //대각선으로 이동하면 실제 이동거리는 1보다 길기 때문에 더 빠르게 이동하게 된다
                                                                             //즉, 대각선으로 이동하는 속도도 수평, 수직으로 이동하는 속도와 같게 하기 위해서 사용한다
                                                                             //fixedDeltaTime - 물리 프레임 하나가 소비한 시간 FixedUpdate에서 사용, DeltaTime - Update에서 사용
                                                                             //위치 이동 - MovePosition(이동), MoveRotation(회전)
        rigid.MovePosition(rigid.position + nextVec);//MovePosition은 위치 이동이라 현재 위치도 더해주어야 한다(rigid.position)
    }
}
