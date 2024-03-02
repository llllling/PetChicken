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
    /// ���� �ð��� ����� �ð��� ���Ͽ� ��Ÿ�� �ð��� �������� ���θ� �Ǵ��ϴ� �Լ�(��Ÿ�� �����ٸ� true, �ƴϸ� false ��ȯ)
    /// </summary>
    /// <param name="key">����� �ð� key</param>
    /// <param name="coolTimeSeconds">���� ��Ÿ�� �ð� ��</param>
    /// <param name="defaultValue">����� �ð� key�� ���� ��� ��ȯ�� ��</param>
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
