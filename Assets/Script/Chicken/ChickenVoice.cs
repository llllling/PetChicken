using System.Collections;
using UnityEngine;

public enum ChickenVoiceType
{
    DEFAULT,
    EAT,
    STROKING,
    COMPLIMENT,
    TRANSFORM,
    FOOTSTEPS
}

public class ChickenVoice : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip defaultClip;
    public AudioClip eatClip;
    public AudioClip strokingClip;
    public AudioClip complimentClip;
    public AudioClip tranformClip;
    public AudioClip footStepsClip;

    private bool IsMuted => !GameManager.Instance.isTurnOnSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(DefualtVoiceRandomRepeat());
    }
    void Update()
    {
        if (IsMuted)
        {
            audioSource.mute = true;
        }
    }

    /// <summary>
    /// default ���� �����Ҹ� ����ϴ� �Լ�
    /// </summary>
    public void PlayRepeating()
    {
        if (IsInvoking())
        {
            CancelInvoke();
        }
        audioSource.clip = GetClipByChickenVoiceType(ChickenVoiceType.DEFAULT);
      
    }

    /// <summary>
    /// �Ű������� �Ѿ�� voice Ÿ���� repeat(��) ������ �Ҹ��� �����Ѵ�.
    /// </summary>
    public void PlayRepeating(ChickenVoiceType type, float repeat, float startDuration = 1)
    {
        if (IsInvoking())
        {
            CancelInvoke();
        }
        audioSource.clip = GetClipByChickenVoiceType(type);

        InvokeRepeating(nameof(PlayClip), startDuration, repeat);
    }
    private void PlayClip()
    {
        audioSource.Play();
    }

    private IEnumerator DefualtVoiceRandomRepeat()
    {
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        while (true)
        {
            if (audioSource.clip.name == defaultClip.name)
            {
                audioSource.Play();
            }

            yield return new WaitForSeconds(Random.Range(5f, 10f));
        }
    }

    private AudioClip GetClipByChickenVoiceType(ChickenVoiceType type)
    {
        return type switch
        {
            ChickenVoiceType.EAT => eatClip,
            ChickenVoiceType.STROKING => strokingClip,
            ChickenVoiceType.COMPLIMENT => complimentClip,
            ChickenVoiceType.TRANSFORM => tranformClip,
            ChickenVoiceType.FOOTSTEPS => footStepsClip,
            _ => defaultClip
        };
    }
}
