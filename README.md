# �ֿϴ� Ű���

## ��ǥ
AR ȯ�濡�� �ֿϿ� ���� Ű��� ���� �̴� ���� �����ϱ�!

## �̼�
�ֿϴ߿��� ���� �ְ�, ������ְ� Ī���� ���ָ� �ֿϴ߰��� ������ ������ �����ϱ�

## ���
1. �ĸ� ī�޶�� ��ģ ȭ�鿡�� ���(�ٴ�, å�� ��)���� ���� ��Ÿ�� �ɾ�ٴѴ�.
    * ������ �ð����� ������ ���������� �̵��ǵ��� �����ν� ���ƴٴϴ� ����
2. �� �ֱ�(������ +50) : ���� ��ġ �� �� �ֱ� ��ư Ŭ��
    * �� �� Ÿ�� 4�ð�
    * 12�ð� �Ѱ� ���� ���ָ� �������� ������(-1000)
3. ���㾲��(������ +10) : ���� ��ġ �� �巡�� 2ȸ �̻��ϸ� ���� ��� �ߵ�
    * 8�ð� �Ѱ� ���ٵ��� ������ �������� ������(-50)
4. Ī�� �ϱ�(������ +100) : ���� �ѹ� Ŭ���ϸ� Ī�� �ϱ� ��ư�� �߰� �ش� ��ư�� Ŭ���ϸ� Ī�� �޼��� �ۼ� â�� ��
5. �������� ���� ���� ������ ������ ����ȴ�.
    * ������(������ 1000 ����) > �����(2000) > �Ķ���(4000) > �ʷϻ�(8000) > �����(16000) > ������(32000) > ���(64000) ������ ����
6. ���� �Կ�(�ɼ�) : �޴����� ���� �Կ��� Ŭ���ؼ� ȭ�� ĸó

## ��� ����
����Ƽ ���� 2022.3.18f1

## ��� ���� ����
1. �ֿϴ� 3D �� ���� �� ��������� �̵� ���
    * ���/�ȱ� �ִϸ��̼�
    * ȭ�� �� ��� ������ �������� ���ƴٴ�
2. ���� �Ŵ��� �ۼ�
    * ���� ����
    * ��⳻�� ������ �����ϵ���
3. ������ UI
4. ������ ���� �� ���� ���
     * �������� ���� �ֿϴ� ���� ��ȭ(�������� > ���������� ��ȭ�� �� ������ ��ȭ�Ϸ��� ������ �ֱ����� �׷��̵��Ʈ��)
     * ���� ����Ʈ 
5. ��Ʈ�� �� �� ���� ���� ��ư
    * TextMesh Font ����
    * ���� ��ư
    * �� ��ȯ ����
    * ���� ������ ��Ʈ�� ������ ������ ��ư ����
    * ���� ���� ��ư
6. �ֿϴ� ��ġ �� UI(���ֱ�/Ī�� �ϱ� ��ư) ����
7. ���ֱ� ���
    * �� ���� ã�� 
    * �� ������� �ִϸ��̼�
    * �ֿϴ� �� �Դ� �ִϸ��̼�
    * �� �ٸ԰� �� �� ������ ��� ����Ʈ ȿ�� 
    * ������ ����
8. 12�ð� ��� �� �����
    * �ֿϴ� �Ӹ� �� ��ǳ������ ����� ǥ��
    * ���ָ� �������
9. �ֿϴ� ���㾲�� ���
    * Raycast ��ũ��Ʈ �ۼ�
    * ���㾲�� �� ����Ʈ ȿ��
    * ���㾲�� ���ϴ� �� �ִϸ��̼�
    * ������ ����
10. Ī�� �ϱ�
    * Ī�� �Է� UI ����
    * �ֿϴ��� �亯 ��ǳ�� UI ����
    * �亯 �� ����Ʈ ȿ��
    * �ֿϴ� Ī���ް� ������Ƽ� �پ�ٴϴ� �ִϸ��̼�
    * ������ ����
11. ȿ���� �߰�
    * ������ ���� �� ���� ȿ����
    * �� �Դ� ��
    * 12�ð� ��� �����(���� ���� �� ����� ���¸� �ѹ���)
    * ���㾲��
    * Ī������ �� ���
12. ���� ���� UI
13. ���� �Կ� ���
    * ȭ�� ĸó �� ����ø�� ����ǵ���

## ������Ʈ�ϸ鼭 ����� �� 
* �ֿϴ� �ִϸ��̼��� Idle, Walk, Run, Eat, Turn Head 4������ �ְ�,  Walk, Run, Eat, Turn Head 4���� bool Ÿ�� �Ķ���Ͱ� �ִ�. 4���� �Ķ���Ͱ� false�� ��� ���� Idle�� �ִϸ��̼��� ���̵ȴ�. 
    * ��������� Idle�� �����Ϸ��� => SetBool(����Ǵ� �ִϸ��̼��� �Ķ���͸�, false) 
    * ChickenAnimator.cs
    ```c#
    /*
    //ChickenController.cs ���Ͽ� ����� ���� ������ Ÿ��
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

            // IDLE�� ��� : (����Ǵ� �ִϸ��̼� �Ķ���͸�,  false)
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
                default: //IDLE�� ���°� ����Ǿ��� ��� ���� �Ķ���͸� �Ѱ��ش�. 
                    return currentParamter;
            }
        }

    }
    ```
* �������� ���� �����ϱ� ���� Contract Ŭ���� ����.
    * �ν����� â���� ������ �� �ִ� ������ static���� ����.
    * ������� ���ƾ��� ������ const�� ����.
    ```c#
    using UnityEngine;
    [CreateAssetMenu(fileName = "Constract", menuName = "Scriptable/Constract", order = 1)]
    public class Constract : ScriptableObject
    {
        public const string PATH = "Assets/Scriptable/Constract.asset";

        public static string defaultAffectionText = "������";
        public const string AFFECTION_SCORE_KEY = "Affection";

        public static int level_black = 1000;
        public static int level_purple = 2000;
        public static int level_blue = 4000;
        public static int level_green = 8000;
        public static int level_yellow = 16000;
        public static int level_red = 32000;
        public static int level_white = 64000;
        //.... ����

    }
    ```