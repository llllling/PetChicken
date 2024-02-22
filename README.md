# 애완닭 키우기

## 목표
AR 환경에서 애완용 닭을 키우는 힐링 미니 게임 제작하기!

## 미션
애완닭에게 밥을 주고, 쓰담아주고 칭찬을 해주며 애완닭과의 애정을 쌓으며 힐링하기

## 기능
1. 후면 카메라로 비친 화면에서 평면(바닥, 책상 위)위에 닭이 나타나 걸어다닌다.
    * 랜덤의 시간마다 랜덤의 포지션으로 이동되도록 함으로써 돌아다니는 느낌
2. 밥 주기(애정도 +50) : 닭을 한번 클릭하면 밥 주기 버튼 뜸
    * 밥주기 쿨 타임 4시간
    * 12시간 넘게 밥을 안주면 애정도가 떨어짐(-1000)
3. 쓰담쓰담(애정도 +10) : 닭을 터치 후 드래그 2회 이상하면 쓰담 기능 발동
    * 쓰담쓰담 쿨 타임 30분
    * 8시간 넘게 쓰다듬지 않으면 애정도가 떨어짐(-50)
4. 칭찬 하기(애정도 +100) : 닭을 한번 클릭하면 칭찬 하기 버튼이 뜨고 해당 버튼을 클릭하면 칭찬 메세지 작성 창이 뜸
    * 칭찬 후 쿨 타임 4시간
5. 애정도에 따라 닭의 색상이 서서히 변경된다.
    * 흰색(애정도 1000 이하) > 노란색(2000) > 초록색(4000) > 파란색(8000) > 보라색(16000) > 빨간색(32000) > 검은색(64000) 순으로 변함
6. 사진 촬영(옵션) : 메뉴에서 사진 촬영을 클릭해서 화면 캡처

## 기술 스택
유니티 버전 2022.3.18f1

## 기능 개발 순서
1. 애완닭 3D 모델 생성 및 평면위에서 이동 기능
    * 대기/걷기 애니메이션
2. 게임 매니저 작성
    * 점수 관리
    * 기기내에 점수를 저장하도록
3. 애정도 UI
4. 애정도 변할 때 변신 기능
     * 애정도에 따른 애완닭 색상 변화(이전레벨 > 다음레벨로 변화할 때 서서히 변화하려는 느낌을 주기위해 그레이디언트로)
     * 변신 이펙트 
5. 인트로 씬 및 게임 종료 버튼
    * TextMesh Font 제작
    * 버튼들 이미지 찾기
    * 시작 버튼
    * 씬 전환 설정
    * 메뉴 버튼
        * 게임 종료 버튼
        * 사운드 on/off 버튼
        * 게임 설명 버튼(인트로)
        * 인트로 씬으로 나가기 버튼(메인)
6. 애완닭 터치 시 UI(밥주기/칭찬 하기 버튼) 생성
7. 밥주기 기능
    * 밥 에셋 찾기 
    * 밥 오브젝트 만들기
    * 밥 사라지는 애니메이션
    * 애완닭 밥 먹는 애니메이션
    * 애정도 증가/ 애정도 상승 이펙트 효과
    * 쿨타임 체크
8. 칭찬 하기
    * 칭찬 입력 UI 생성
    * 이펙트 효과
    * 애완닭 칭찬받고 기분좋아서 뛰어다니는 애니메이션
    * 애정도 증가/ 애정도 상승 이펙트 효과
    * 쿨타임 체크
9. 12시간 경과 후 배고픔
    * 애완닭 머리 위 말풍선으로 배고픔 표시
    * 밥주면 사라지게
10. 애완닭 쓰담쓰담 기능
    * Raycast 스크립트 작성
    * 쓰담쓰담 당하는 닭 애니메이션
    * 애정도 증가/ 애정도 상승 이펙트 효과
    * 쿨타임 체크
11. 닭 화면 내 평면 위에서 무작위로 돌아다님
12. 효과음 추가
    * 애정도 변할 때 변신 효과음
    * 밥 먹는 중
    * 12시간 경과 배고픔(게임 입장 시 배고픔 상태면 한번만)
    * 쓰담쓰담
    * 칭찬들은 후 기쁨
13. 게임 설명 UI
14. 사진 촬영 기능
    * 화면 캡처 후 사진첩에 저장되도록

## 프로젝트하면서 고민한 점 
* 애완닭 애니메이션이 Idle, Walk, Run, Eat, Turn Head 4가지가 있고,  Walk, Run, Eat, Turn Head 4가지 bool 타입 파라미터가 있다. 4가지 파라미터가 false일 경우 전부 Idle로 애니메이션이 전이된다. 
    * 결론적으로 Idle로 전이하려면 => SetBool(실행되던 애니메이션의 파라미터명, false) 
    * ChickenAnimator.cs
    ```c#
    /*
    //ChickenController.cs 파일에 선언된 상태 열거형 타입
    public enum ChickenStatus
    {
        IDLE,
        WALK,
        RUN,
        EAT,
        TURN_HEAD
    }

    */

    public class ChickenAnimator : MonoBehaviour
    {
        private string currentParamter = string.Empty;
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

   
        public void ChangeAnimationByStatus(ChickenStatus status)
        {
            currentParamter = GetParamterNameByStatus(status);
            if (currentParamter == string.Empty) return;

            // IDLE일 경우 : (실행되던 애니메이션 파라미터명,  false)
            animator.SetBool(GetParamterNameByStatus(status), status != ChickenStatus.IDLE);
        }

        private string GetParamterNameByStatus(ChickenStatus status)
        {
            switch (status)
            {
                case ChickenStatus.WALK:
                    return "Walk";
                case ChickenStatus.RUN:
                    return "Run";
                case ChickenStatus.EAT:
                    return "Eat";
                case ChickenStatus.TURN_HEAD:
                    return "Turn_Head";
                default: //IDLE로 상태가 변경되었을 경우 직전 파라미터명 넘겨준다. 
                    return currentParamter;
            }
        }

    }
    ```
* 공통적인 값을 관리하기 위해 Contract 클래스 만듬.
    * 인스펙터 창에서 변경할 수 있는 값들은 static으로 설정.
    * 변경되지 말아야할 값들은 const로 설정.
    ```c#
    using UnityEngine;
    [CreateAssetMenu(fileName = "Constract", menuName = "Scriptable/Constract", order = 1)]
    public class Constract : ScriptableObject
    {
        public const string PATH = "Assets/Scriptable/Constract.asset";

        public static string defaultAffectionText = "애정도";
        public const string AFFECTION_SCORE_KEY = "Affection";

        public static int level_white = 1000;
        public static int level_yellow = 2000;
        public static int level_green = 4000;
        public static int level_blue = 8000;
        public static int level_purple = 16000;
        public static int level_red = 32000;
        public static int level_black = 64000;
        //.... 생략

    }
    ```
* 레벨을 색상으로 표현해주기 때문에 레벨색상에 관련된 함수들을 한 곳에서 관리하고, 다른 클래스에서 클래스명으로 간단히 접근하기 위해 static class로 생성
    * ChickenColor.cs
    ```c#
    public enum ChickenColors
    {
        WHITE,
        YELLOW,
        GREEN,
        BLUE,
        PURPLE,
        RED,
        BLACK
    }   
    public static class ChickenColor
    {
        /// <summary>
        /// 인자로 넘어온 애정도 점수에 해당하는 ChickenColors 열거형 타입의 값을 반환하는 함수
        /// </summary>
        public static ChickenColors ChickenColorByAffection(int affection)
        {
            return affection switch
            {
                int n when (n <= Constract.level_white) => ChickenColors.WHITE,
                int n when (n <= Constract.level_yellow) => ChickenColors.YELLOW,
                int n when (n <= Constract.level_green) => ChickenColors.GREEN,
                int n when (n <= Constract.level_blue) => ChickenColors.BLUE,
                int n when (n <= Constract.level_purple) => ChickenColors.PURPLE,
                int n when (n <= Constract.level_red) => ChickenColors.RED,
                _ => ChickenColors.BLACK,
            };
        }

        /// <summary>
        /// 인자로 넘어온 ChickenColors 열거형 타입의 값에 해당하는 애정도 점수를 반환하는 함수
        /// </summary>
        public static int AffectionByChickenColor(ChickenColors chickenColor)
        {
            return chickenColor switch
            {
                ChickenColors.WHITE => Constract.level_white,
                ChickenColors.YELLOW => Constract.level_yellow,
                ChickenColors.GREEN => Constract.level_green,
                ChickenColors.BLUE => Constract.level_blue,
                ChickenColors.PURPLE => Constract.level_purple,
                ChickenColors.RED => Constract.level_red,
                _ => Constract.level_black,
            };
        }

        /// <summary>
        /// 인자로 넘어온 ChickenColors 열거형 타입의 값에 해당하는 Color 값을 반환하는 함수
        /// </summary>
        public static Color ColorByChickenColors(ChickenColors chickenColor)
        {
            return chickenColor switch
            {
                ChickenColors.WHITE => Color.white,
                ChickenColors.YELLOW => Color.yellow,
                ChickenColors.GREEN => Color.green,
                ChickenColors.BLUE => Color.blue,
                ChickenColors.PURPLE => Color.magenta,
                ChickenColors.RED => Color.red,
                _ => Color.black,
            };
        }
    }

    ```