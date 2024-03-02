using System;
using UnityEngine;

public class CoolTimeController : MonoBehaviour
{
    private const string DATE_FORMAT = "yyyyMMdd HH:mm:ss";

    public static void SaveCoolTime(string key)
    {
        PlayerPrefs.SetString(key, DateTime.Now.ToString(DATE_FORMAT));
    }

    /// <summary>
    /// 현재 시간과 저장된 시간을 비교하여 쿨타임 시간이 지났는지 여부를 판단하는 함수(쿨타임 지났다면 true, 아니면 false 반환)
    /// </summary>
    /// <param name="key">저장된 시간 key</param>
    /// <param name="coolTimeSeconds">비교할 쿨타임 시간 초</param>
    /// <param name="defaultValue">저장된 시간 key가 없는 경우 반환할 값</param>
    public static bool HasPassedCoolTime(string key, int coolTimeSeconds, bool defaultValue = true)
    {
        if (!PlayerPrefs.HasKey(key)) return defaultValue;
      
        DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
        return (DateTime.Now - savedTime).TotalSeconds >= coolTimeSeconds;

    }

    public static string GetRemainedCoolTime(string key, int coolTimeSeconds)
    {
        if (!PlayerPrefs.HasKey(key)) return "";

        DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
        return GetFormattedDifference((TimeSpan.FromSeconds(coolTimeSeconds) - (DateTime.Now - savedTime)));
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
