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
    public static bool HasPassedCooldown(string key, int coolDownSeconds)
    {
        if (!PlayerPrefs.HasKey(key)) return true;
      
        DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
        return (DateTime.Now - savedTime).TotalSeconds >= coolDownSeconds;

    }


    /// <summary>
    /// 현재 시간과 저장된 시간 간의 경과 시간을 계산하여 쿨타임의 배수인지 여부를 반환하는 함수(쿨타임의 배수라면 true, 아니면 false 반환)
    /// </summary>
    /// <param name="key">저장된 시간 key</param>
    /// <param name="coolDownSeconds">비교할 쿨타임 시간 초</param>
    public static bool IsCooldown(string key, int coolDownSeconds)
    {
        if (!PlayerPrefs.HasKey(key)) return false;

        DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
        return (DateTime.Now - savedTime).TotalSeconds % coolDownSeconds == 0;

    }

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
