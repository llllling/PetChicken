using System;
using UnityEngine;

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
        return (DateTime.Now - savedTime).Seconds;
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
