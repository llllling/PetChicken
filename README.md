# �ֿϴ� Ű���

## ��ǥ
AR ȯ�濡�� �ֿϿ� ���� Ű��� ���� �̴� ���� �����ϱ�!

## �̼�
�ֿϴ߿��� ���� �ְ�, ������ְ� Ī���� ���ָ� �ֿϴ߰��� ������ ������ �����ϱ�

## ���
1. �ĸ� ī�޶�� ��ģ ȭ�鿡�� ���(�ٴ�, å�� ��)���� ���� ��Ÿ�� �ɾ�ٴѴ�.
    * ������ �ð����� ������ ���������� �̵��ǵ��� �����ν� ���ƴٴϴ� ����
2. �� �ֱ�(������ +50) : ���� �ѹ� Ŭ���ϸ� �� �ֱ� ��ư ��
    * ���ֱ� �� Ÿ�� 4�ð�
    * 12�ð� �Ѱ� ���� ���ָ� �������� ������(-1000)
3. ���㾲��(������ +10) : ���� ��ġ �� �巡�� 2ȸ �̻��ϸ� ���� ��� �ߵ�
    * ���㾲�� �� Ÿ�� 30��
    * 8�ð� �Ѱ� ���ٵ��� ������ �������� ������(-50)
4. Ī�� �ϱ�(������ +100) : ���� �ѹ� Ŭ���ϸ� Ī�� �ϱ� ��ư�� �߰� �ش� ��ư�� Ŭ���ϸ� Ī�� �޼��� �ۼ� â�� ��
    * Ī�� �� �� Ÿ�� 4�ð�
5. �������� ���� ���� ������ ������ ����ȴ�.
    * ��� > �����(1000 �̻�) > �ʷϻ�(3000) > �Ķ���(7000) > �����(16000) > ������(32000) > ������(64000) ������ ����
6. ���� �Կ�(�ɼ�) : �޴����� ���� �Կ��� Ŭ���ؼ� ȭ�� ĸó

## ��� ����
����Ƽ ���� 2022.3.18f1

## ��� ���� ����
1. �ֿϴ� 3D �� ���� �� ��������� �̵� ���
    * ���/�ȱ� �ִϸ��̼�
2. ���� �Ŵ��� �ۼ�
    * ���� ����
    * ��⳻�� ������ �����ϵ���
3. ������ UI
4. ������ ���� �� ���� ���
     * �������� ���� �ֿϴ� ���� ��ȭ(�������� > ���������� ��ȭ�� �� ������ ��ȭ�Ϸ��� ������ �ֱ����� �׷��̵��Ʈ��)
     * ���� ����Ʈ 
5. ��Ʈ�� �� �� ���� ���� ��ư
    * TextMesh Font ����
    * ��ư�� �̹��� ã��
    * ���� ��ư
    * �� ��ȯ ����
    * �޴� ��ư
        * ���� ���� ��ư
        * ���� on/off ��ư
        * ���� ���� ��ư(��Ʈ��)
        * ��Ʈ�� ������ ������ ��ư(����)
6. ������ UP��ư Ŭ�� �� UI(���ֱ�/Ī�� �ϱ� ��ư) ����
7. ���ֱ� ���
    * �� ���� ã�� 
    * �� ������Ʈ �����
    * �� ������� �ִϸ��̼�
    * �ֿϴ� �� �Դ� �ִϸ��̼�
    * ������ ����/ ������ ��� ����Ʈ ȿ��
    * ��Ÿ�� üũ
8. Ī�� �ϱ�
    * Ī�� �Է� UI ����
    * �ֿϴ� Ī���ް� ������Ƽ� �پ�ٴϴ� �ִϸ��̼�
    * ������ ����/ ������ ��� ����Ʈ ȿ��
    * ��Ÿ�� üũ
9. 12�ð� ��� �� �����
    * �ֿϴ� �Ӹ� �� ��ǳ������ ����� ǥ��
    * ���ָ� �������
10. �ֿϴ� ���㾲�� ���
    * Raycast ��ũ��Ʈ �ۼ�
    * ���㾲�� ���ϴ� �� �ִϸ��̼�
    * ������ ����/ ������ ��� ����Ʈ ȿ��
    * ��Ÿ�� üũ
11. �� ȭ�� �� ��� ������ �������� ���ƴٴ�
12. ȿ���� �߰�
    * ������ ���� �� ���� ȿ����
    * �� �Դ� ��
    * 12�ð� ��� �����(���� ���� �� ����� ���¸� �ѹ���)
    * ���㾲��
    * Ī������ �� ���
13. ���� ���� UI, ���� ���� Alert UI
14. ���� �Կ� ���
    * ȭ�� ĸó �� ����ø�� ����ǵ���

## ������Ʈ�ϸ鼭 ����� �� 
* �ֿϴ� �ִϸ��̼��� Idle, Walk, Run, Eat, Turn Head 4������ �ְ�,  Walk, Run, Eat, Turn Head 4���� bool Ÿ�� �Ķ���Ͱ� �ִ�. 4���� �Ķ���Ͱ� false�� ��� ���� Idle�� �ִϸ��̼��� ���̵ȴ�. 
    * ��������� Idle�� �����Ϸ��� => SetBool(����Ǵ� �ִϸ��̼��� �Ķ���͸�, false) 
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

   
        public void OnAnimation(ChickenAnimation currentAnimation)
        {
            currentParamter = GetParamterNameByAnimation(currentAnimation);
            if (currentParamter == string.Empty) return;

            // IDLE�� ��� : (����Ǵ� �ִϸ��̼� �Ķ���͸�,  false)
            animator.SetBool(GetParamterNameByAnimation(currentAnimation), currentAnimation != ChickenAnimation.IDLE);
        }

        private string GetParamterNameByAnimation(ChickenAnimation currentAnimation)
        {
            return currentAnimation switch
            {
                ChickenAnimation.WALK => "Walk",
                ChickenAnimation.RUN => "Run",
                ChickenAnimation.EAT => "Eat",
                ChickenAnimation.TURN_HEAD => "Turn_Head",
                //IDLE�� ���°� ����Ǿ��� ��� ���� �Ķ���͸� �Ѱ��ش�. 
                _ => currentParamter,
            };
        }

    }
    ```
* �������� ���� �����ϱ� ���� Contract Ŭ���� ����.
    * ������� ���ƾ��� ������ const�� ����.
    ```c#
    using UnityEngine;
    [CreateAssetMenu(fileName = "Constract", menuName = "Scriptable/Constract", order = 1)]
    public class Constract : ScriptableObject
    {
        //...����
        public const string PATH = "Assets/Scriptable/Constract.asset";

        public const string AFFECTION_SCORE_KEY = "Affection";

        public int level_white = 1000;
        public int level_yellow = 2000;
        public int level_green = 4000;
        public int level_blue = 8000;
        public int level_purple = 16000;
        public int level_red = 32000;
        public int level_black = 64000;
        //.... ����

    }
    ```
* ������ �������� ǥ�����ֱ� ������ �������� ���õ� �Լ����� �� ������ �����ϰ�, �ٸ� Ŭ�������� Ŭ���������� ������ �����ϱ� ���� static class�� ����
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
        /// ���ڷ� �Ѿ�� ������ ������ �ش��ϴ� ChickenColors ������ Ÿ���� ���� ��ȯ�ϴ� �Լ�
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
        /// ���ڷ� �Ѿ�� ChickenColors ������ Ÿ���� ���� �ش��ϴ� ������ ������ ��ȯ�ϴ� �Լ�
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
        /// ���ڷ� �Ѿ�� ChickenColors ������ Ÿ���� ���� �ش��ϴ� Color ���� ��ȯ�ϴ� �Լ�
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
* Alertâ, InputFieldâ�� ���� X��ư�� �������� ���Ǿ� ���������� ����
    * XButton Ŭ�� �� UI�� �ݴ� ������ ��� ���������� ��ũ��Ʈ�� ���� �����տ� ����
    * XButton.cs
        * �Ʒ� �ڵ忡��  [SerializeField]�� �ֻ��� ���ӿ�����Ʈ ��� ������Ʈ �̸��� �޴� ���� 
            * ó���� GameObject ��ü�� ���� �޵��� �ҽ��� �ۼ����� => ���� ���� �� �� �۵�������, X��ư�� ���� ��Ȱ��ȭ �Ǿ��ٰ� �ٽ� Ȱ��ȭ �Ǵ� ��� inspectorâ���� �� ������ �Ҵ�Ǿ� null�� �Ѿ��.
            * �׷��� GameObject�� �̸��� �޾Ƽ� X��ư�� ������ UI�� Ȱ��ȭ �Ǵ� ��� �̸����� ã�Ƽ� ����ϵ��� ����
    ```C#
    public class XButton : MonoBehaviour
    {
        /// <summary>
        /// X ��ư�� Ŭ�� �� �� �������ϴ� ������Ʈ�� �� �ֻ��� ������Ʈ �̸�
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
            rootParent.SetActive(false);
        }
    }

    ```