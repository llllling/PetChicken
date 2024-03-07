using System;
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
    [SerializeField]
    private float repeatRateForDefault = 5f;
    private bool IsMuted => !GameManager.Instance.isTurnOnSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
     //   PlayRepeating();

    }
    void Update()
    {
        if (IsMuted)
        {
            audioSource.mute = true;
        }
    }
    
    /// <summary>
    /// �Ű������� �Ѿ�� voice Ÿ���� repeat(��) ������ �Ҹ��� �����Ѵ�. �⺻ voice Ÿ�԰� repeat�� ���� default ���� �Ҹ�
    /// </summary>
    /// <param name="type"></param>
    /// <param name="repeat"></param>
    public void PlayRepeating(ChickenVoiceType type = ChickenVoiceType.DEFAULT ,float repeat = 0, float startDuration = 1)
    {
        if (IsInvoking())
        {
            CancelInvoke();
        }

        audioSource.clip = GetClipByChickenVoiceType(type);

        InvokeRepeating(nameof(PlayClip), startDuration, repeat != 0 ? repeat :  repeatRateForDefault);
    }
    private void PlayClip()
    {
        audioSource.Play();
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
