# 반려닭 키우기

## 목표
AR 환경에서 닭을 키우는 힐링 미니 게임 제작하기!

## 미션
반려닭에게 밥을 주고, 쓰담아주고 칭찬을 해주며 반려닭과의 애정을 쌓으며 힐링하기

## 기능
1. 후면 카메라로 비친 화면에서 평면(바닥, 책상 위)위에 닭이 나타나 걸어다닌다.
    * 랜덤의 시간마다 랜덤의 포지션으로 이동되도록 함으로써 돌아다니는 느낌
2. 밥 주기(애정도 +50) : 애정도 점수 옆 [UP] 버튼 > [밥] 버튼
    * 밥주기 쿨 다운 4시간
    * 12시간 넘게 밥을 안주면 애정도가 떨어짐(-1000) => 12시간 마다 확인 후 감소
        * 배고프다는 말풍선 보임
3. 쓰담쓰담(애정도 +10) : 닭을 터치 후 드래그 2회 이상하면 쓰담 기능 발동
    * 8시간 넘게 쓰다듬지 않으면 애정도가 떨어짐(-50) => 8시간 마다 확인 후 감소
4. 칭찬 하기(애정도 +100) : 애정도 점수 옆 [UP] 버튼 > [칭찬] 버튼 > 칭찬 메세지 작성 창이 뜸
    * 칭찬하기 쿨 다운 4시간
5. 애정도에 따라 닭의 색상이 서서히 변경된다.
    * 흰색 > 노란색(1000 이상) > 초록색(3000) > 파란색(7000) > 보라색(16000) > 빨간색(32000) > 검은색(64000) 순으로 변함
6. UI
    * 사운드 on/off
    * 게임 종료
    * 게임 설명(인트로 화면만 해당)
    * 인트로 화면으로 돌아가기(게임 화면만 해당)
## 기술 스택
유니티 버전 2022.3.18f1

## 기능 개발 순서
1. 반려닭 3D 모델 생성 및 평면위에서 이동 기능
    * 대기/걷기 애니메이션
2. 게임 매니저 작성
    * 점수 관리
    * 기기내에 점수를 저장하도록
3. 애정도 UI
4. 애정도 변할 때 변신 기능
     * 애정도에 따른 반려닭 색상 변화(이전레벨 > 다음레벨로 변화할 때 서서히 변화하려는 느낌을 주기위해 그레이디언트로)
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
6. 애정도 UP버튼 클릭 시 UI(밥주기/칭찬 하기 버튼) 생성
7. 밥주기 기능
    * 밥 에셋 찾기 
    * 밥 오브젝트 만들기
    * 밥 사라지는 애니메이션
    * 반려닭 밥 먹는 애니메이션
    * 애정도 증가/ 애정도 상승 이펙트 효과
    * 쿨타임 체크
8. 칭찬 하기
    * 칭찬 입력 UI 생성
    * 반려닭 칭찬받고 기분좋아서 뛰어다니는 애니메이션
    * 애정도 증가/ 애정도 상승 이펙트 효과
    * 쿨타임 체크
9. 12시간 경과 후 배고픔
    * 반려닭 머리 위 말풍선으로 배고픔 표시
    * 애정도 감소(12시간 마다 감소)
    * 밥주면 사라지게
10. 반려닭 쓰담쓰담 기능
    * Raycast 스크립트 작성
    * 쓰담쓰담 당하는 닭 애니메이션
    * 애정도 증가/ 애정도 상승 이펙트 효과
    * 8시간동안 쓰다듬지 않았다면 애정도 감소(8시간 마다 감소)
11. 게임 설명 UI, 게임 종료 Alert UI
12. 닭 화면 내 평면 위에서 무작위로 돌아다님
13. 효과음 추가
    * 기본 울음소리 
    * 애정도 변할 때 변신 효과음
    * 밥 먹는 중
    * 쓰담쓰담
    * 칭찬들은 후 기쁨

## 프로젝트하면서 고민한 점 
* 반려닭 애니메이션이 Idle, Walk, Run, Eat, Turn Head 4가지가 있고,  Walk, Run, Eat, Turn Head 4가지 bool 타입 파라미터가 있다. 4가지 파라미터가 false일 경우 전부 Idle로 애니메이션이 전이된다. 
    * 현재 실행중인 애니메이션과 매칭되는 파라미터를 관리하기 위해 클래스를 만들어서 애니메이션 관리
    * ChickenAnimator.cs
    ```c#
    /*
   
    public enum ChickenAnimation
    {
        IDLE,
        WALK,
        RUN,
        EAT,
        TURN_HEAD
    }
    public class ChickenAnimatorController : MonoBehaviour
    {
        private string currentParamter = string.Empty;
        private Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

       //..코드 생략
        public void ChangeAnimation(ChickenAnimation animation)
        {
            //기존 실행되던 애니메이션이 있다면 false처리
            if (currentParamter != string.Empty)
            {
                animator.SetBool(currentParamter, false);
            }

            CurrentAnimation = animation;

            //idle은 모든 애니메이션 false일때의 상태
            if (animation == ChickenAnimation.IDLE) return;

            currentParamter = GetParamterNameByAnimation(animation);
            animator.SetBool(currentParamter, true);
        }
         //..코드 생략
        private string GetParamterNameByAnimation(ChickenAnimation currentAnimation)
        {
            return currentAnimation switch
            {
                ChickenAnimation.WALK => "Walk",
                ChickenAnimation.RUN => "Run",
                ChickenAnimation.EAT => "Eat",
                ChickenAnimation.TURN_HEAD => "Turn_Head",
                //IDLE로 상태가 변경되었을 경우 직전 파라미터명 넘겨준다. 
                _ => currentParamter,
            };
        }

    }
    ```
* 공통적인 값을 관리하기 위해 Contract 클래스 생성.
    * 변경되지 말아야할 값들은 const로 설정.
    ```c#
    using UnityEngine;
    [CreateAssetMenu(fileName = "Constract", menuName = "Scriptable/Constract", order = 1)]
    public class Constract : ScriptableObject
    {
        //...생략
        public const string PATH = "Assets/Scriptable/Constract.asset";

        public const string AFFECTION_SCORE_KEY = "Affection";

        public int level_white = 1000;
        public int level_yellow = 2000;
        public int level_green = 4000;
        public int level_blue = 8000;
        public int level_purple = 16000;
        public int level_red = 32000;
        public int level_black = 64000;
        //.... 생략

    }
    ```
* 레벨을 색상으로 표현해주기 때문에 레벨 색상에 관련된 함수들을 한 곳에서 관리하고, 다른 클래스에서 클래스명으로 간단히 접근하기 위해 static class로 생성
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
                int n when (n >= Constract.Instance.level_black) => ChickenColors.BLACK,
                int n when (n >= Constract.Instance.level_red) => ChickenColors.RED,
                int n when (n >= Constract.Instance.level_purple) => ChickenColors.PURPLE,
                int n when (n >= Constract.Instance.level_blue) => ChickenColors.BLUE,
                int n when (n >= Constract.Instance.level_green) => ChickenColors.GREEN,
                int n when (n >= Constract.Instance.level_yellow) => ChickenColors.YELLOW,
                _ => ChickenColors.WHITE,
            };
        }

        /// <summary>
        /// 인자로 넘어온 ChickenColors 열거형 타입의 값에 해당하는 애정도 점수를 반환하는 함수
        /// </summary>
        public static int AffectionByChickenColor(ChickenColors chickenColor)
        {
            return chickenColor switch
            {
                ChickenColors.WHITE => Constract.Instance.level_white,
                ChickenColors.YELLOW => Constract.Instance.level_yellow,
                ChickenColors.GREEN => Constract.Instance.level_green,
                ChickenColors.BLUE => Constract.Instance.level_blue,
                ChickenColors.PURPLE => Constract.Instance.level_purple,
                ChickenColors.RED => Constract.Instance.level_red,
                _ => Constract.Instance.level_black,
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
* Alert창, InputField창과 같이 X버튼이 여러군데 사용되어 프리팹으로 생성
    * XButton 클릭 시 UI를 닫는 동작이 모두 동일함으로 스크립트를 만들어서 프리팹에 포함
    * XButton.cs
        * 아래 코드에서  [SerializeField]로 최상위 게임오브젝트 대신 오브젝트 이름을 받는 이유 
            * 처음에 GameObject 자체를 전달 받도록 소스를 작성했음 => 최초 실행 시 잘 작동하지만, X버튼을 눌러 비활성화 되었다가 다시 활성화 되는 경우 inspector창에서 빈 값으로 할당되어 null값 넘어옴.
            * 그래서 GameObject의 이름을 받아서 X버튼을 포함한 UI가 활성화 되는 경우 이름으로 찾아서 사용하도록 수정
    ```C#
    public class XButton : MonoBehaviour
    {
        /// <summary>
        /// X 버튼이 클릭 될 때 닫혀야하는 오브젝트들 중 최상위 오브젝트 이름
        /// </summary>
        [SerializeField]
        private string rootParentName;

        private GameObject rootParent;

        void Start()
        {
            rootParent = GameObject.Find(rootParentName);
        }
        public void OnClick()
        {
            GameManager.Instance.PlayButtonSound();

            rootParent.SetActive(false);
        }
    }

    ```
* 스킬 사용 후 재사용까지의 쿨다운 체크 및 밥주기/쓰다듬기를 지정된 쿨다운 시간만큼 사용하지 않을 시 애정도 감소 체크를 여러 곳에서 쿨다운 기능이 참조되므로 쿨다운관련 함수들 관리하기 위한 클래스 생성
    *  간단하게 여러곳에서 사용할 수 있도록 static 메소드로 작성 
    * CooldownManater.cs
        ```C#
        public class CooldownManager : MonoBehaviour
        {
            private const string DATE_FORMAT = "yyyyMMdd HH:mm:ss";

            public static void SaveCooldown(string key)
            {
                PlayerPrefs.SetString(key, DateTime.Now.ToString(DATE_FORMAT));
            }

            /// <summary>
            /// 현재 시간과 저장된 시간 간의 경과 시간을 계산하여 쿨타임 이상 여부를 반환하는 함수(쿨타임 지났다면 true, 아니면 false)
            /// </summary>
            /// <param name="key">저장된 시간 key</param>
            /// <param name="coolDownSeconds">비교할 쿨타임 시간 초</param>
            /// <param name="defaultValue">저장된 key값이 없을 때(저장된 시간이 없을 때) 반환할 기본 값</param>
            public static bool IsCooldownElapsed(string key, int coolDownSeconds, bool defaultValue = true)
            {
                if (!PlayerPrefs.HasKey(key)) return defaultValue;
      
                DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
                return (DateTime.Now - savedTime).TotalSeconds >= coolDownSeconds;

            }
            /// <summary>
            /// 현재 시간과 저장된 쿨다운 시간차를 초 단위로 반환하는 함수
            /// </summary>
            public static int GetDiffSecondsFromCurrentTime(string key)
            {
                if (!PlayerPrefs.HasKey(key)) return 0;

                DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
                return Mathf.RoundToInt(((float)(DateTime.Now - savedTime).TotalSeconds));
            }
            /// <summary>
            /// 스킬 발동 후 쿨다운 시간이 얼마나 남았는 지 반환하는 함수
            /// </summary>
            /// <param name="key">발동한 스킬의 키</param>
            /// <param name="coolDownSeconds">비교할 쿨다운 값</param>
            /// <returns></returns>
            public static string GetRemainedCooldown(string key, int coolDownSeconds)
            {
                if (!PlayerPrefs.HasKey(key)) return "";

                DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
                return GetFormattedDifference((TimeSpan.FromSeconds(coolDownSeconds) - (DateTime.Now - savedTime)));
            }

            private static DateTime StringToDateTime(string str)
            {
                return DateTime.ParseExact(str, DATE_FORMAT, null);

            }
            private static string GetFormattedDifference(TimeSpan difference)
            {
                if (difference.TotalHours >= 1)
                {
                    return $"{difference.Hours:00}:{difference.Minutes:00}:{difference.Seconds:00}";
                }
                return $"{difference.Minutes:00}:{difference.Seconds:00}";
            }
        }

        ```
    * 사용하는 예시
       ```c#
           public void CreateFeed()
           {
                GameManager.Instance.PlayButtonSound();
                //밥주기 스킬 재사용 쿨다운 체크
                if (!CooldownManager.IsCooldownElapsed(Constract.FEED_COOLTIME_KEY, Constract.Instance.feed_cooldown_seconds))
                {
                    //만약 재사용 쿨다운 시간이 지나지 않았다면 남은 시간을 GetRemainedCooldown()로 가져와서 alert창에 표시
                    OpenCooldownAlert(CooldownManager.GetRemainedCooldown(Constract.FEED_COOLTIME_KEY, Constract.Instance.feed_cooldown_seconds) + DEFAULT_COOLTIME_MESSAGE);
                    return;
                }

                Instantiate(feedPrefab, chickenControll.transform.position, Quaternion.identity, chickenControll.transform);

                gameObject.SetActive(false);
           }
       ```
* 밥주기/쓰다듬기 스킬 사용 중 또 스킬을 사용하려고 할 때, 재사용 쿨다운이 지나지 않았을 때와 같이 사용자에게 스킬을 사용못한다는 안내 메세지를 위한 Alert창이 필요 => 코드에서 간단하게 메세지만 넘겨주면 보여주도록 하고 싶었음.
    * Alert창 보이기 : Show() static 메소드로 활성화
    * Alert창 닫기 : 공용X버튼 사용함(Xbutton.cs). 클릭 시 비활성화됨.
    * Alert.cs
    ```c#
        public class Alert : MonoBehaviour
        {
            [SerializeField]
            private TMP_Text tmpText;
            private static Alert instance;


            void Awake()
            {
                if (instance == null)
                {
                    instance = this;
                }
                else
                {
                    Destroy(gameObject);
                }
            }

            void OnDisable()
            {
                instance.tmpText.text = "";

            }

            public static void Show(string message)
            {
                FindAnyObjectByType<Canvas>().transform.Find("Alert").gameObject.SetActive(true);
                instance.tmpText.text = message;
            }
        }

    ```
    * 사용하는 예시
    ```c#
    
    private void OpenCooldownAlert(string message)
    {
        Alert.Show(message);

        gameObject.SetActive(false);
    }
    ```
* 닭이 주기적으로 랜덤의 위치로 이동되는 기능을 구현하기 위해 트래킹된 Plane정보들을 어떤 자료구조로 저장할 지 고민
    * 조건
    ```
        1. plane의 삽입, 삭제가 빈번하게 일어남 => 리스트
        2. plane 정보가 몇개 들어올 지 알 수 없음 => 동적 배열
            * ArrayList => 값 형식을 포함한 모든 요소를 object 형식으로 박싱하고 언박싱한다. 이는 성능에 영향을 줄 수 있다.
            * List<T> 
        3. 타입 안정성과 가독성 고려해서 List<T>로 결정
    ```
* 닭이 랜덤으로 트래킹된 Plane들 중의 한 위치로 이동해야하는 데 이때 어떤 이동 방법을 사용할지 고민
    1. 물리적 충돌이 필요 없음 => transform 사용
    2. trnasform를 사용한 오브젝트 이동 방법
        ```
            - 현재 위치를 기준으로 상대적으로 이동, 실시간 이동이 필요한 경우: `transform.Translate`가 간편하게 사용.
            - 특정 위치로 정확하게 이동하거나, 절대적인 이동이 필요한 경우: `transform.position`에 값을 더하면서 이동하는 방법이 적합.
            - 부드러운 이동이 필요한 경우: `Vector3.Lerp`를 사용하여 부드러운 이동 효과를 얻을 수 있음.
        ```
    3. 랜덤으로 트래킹된 Plane들 중의 한 위치로 이동로 이동해야 하므로 정확한 위치로 이동하는 게 좋다고 판단해서 2번 **transform.position를 사용해서 구현하기로 결정**
## 나중에 고민해보고 코드 개선할 부분
* 애니메이션 관리하는 스크립트에 skill 애니메이션 관련 메소드들 로직이 비슷한 부분이 많음(스킬 발동 시 애니메이션 start/ 스킬 종료 시 애니메이션 end 메소드) 부모클래스 만들어서 상속받아서 스킬애니메이션 자식클래스로 관리하는 쪽으로..?
* 현재는 Alert창(스킬 쿨다운 안내창)이랑 Confirm(게임 종료확인창)이 한두개만 사용되어서 GameEndDialog.cs같은 스크립트(확장X)를 컴포넌트로 할당해서 사용하고 있는 데, 나중에 확장성을 고려하면 여러개의 confirm에서 사용하고 싶은 경우 공통의 confirm 스크립트 작성하는 것이 좋을 듯 
* 모든 UI 버튼이 동일한 소리를 내는 데, 버튼 컨트롤러 스크립트를 생성해서 모든 UI버튼의 onclick함수, sound를 관리하는 것이 좋은 건지? 지금처럼 용도별로 사용되는 각각 스크립트(Alert, Menu 등등)에서 onclick 메소드 작성하고 sound를 출력하는 함수를 호출하는 것이 좋은 건지.. 