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
    /// ���� �ð��� ����� �ð� ���� ��� �ð��� ����Ͽ� ��Ÿ�� �̻� ���θ� ��ȯ�ϴ� �Լ�(��Ÿ�� �����ٸ� true, �ƴϸ� false)
    /// </summary>
    /// <param name="key">����� �ð� key</param>
    /// <param name="coolDownSeconds">���� ��Ÿ�� �ð� ��</param>
    /// <param name="defaultValue">����� key���� ���� ��(����� �ð��� ���� ��) ��ȯ�� �⺻ ��</param>
    public static bool IsCooldownElapsed(string key, int coolDownSeconds, bool defaultValue = true)
    {
        if (!PlayerPrefs.HasKey(key)) return defaultValue;
      
        DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
        return (DateTime.Now - savedTime).TotalSeconds >= coolDownSeconds;

    }
    /// <summary>
    /// ���� �ð��� ����� ��ٿ� �ð����� �� ������ ��ȯ�ϴ� �Լ�
    /// </summary>
    public static int GetDiffSecondsFromCurrentTime(string key)
    {
        if (!PlayerPrefs.HasKey(key)) return 0;

        DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
        return (DateTime.Now - savedTime).Seconds;
    }
    /// <summary>
    /// ��ų �ߵ� �� ��ٿ� �ð��� �󸶳� ���Ҵ� �� ��ȯ�ϴ� �Լ�
    /// </summary>
    /// <param name="key">�ߵ��� ��ų�� Ű</param>
    /// <param name="coolDownSeconds">���� ��ٿ� ��</param>
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
