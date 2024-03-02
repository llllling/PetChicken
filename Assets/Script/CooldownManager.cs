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
    public static bool HasPassedCooldown(string key, int coolDownSeconds)
    {
        if (!PlayerPrefs.HasKey(key)) return true;
      
        DateTime savedTime = StringToDateTime(PlayerPrefs.GetString(key));
        return (DateTime.Now - savedTime).TotalSeconds >= coolDownSeconds;

    }


    /// <summary>
    /// ���� �ð��� ����� �ð� ���� ��� �ð��� ����Ͽ� ��Ÿ���� ������� ���θ� ��ȯ�ϴ� �Լ�(��Ÿ���� ������ true, �ƴϸ� false ��ȯ)
    /// </summary>
    /// <param name="key">����� �ð� key</param>
    /// <param name="coolDownSeconds">���� ��Ÿ�� �ð� ��</param>
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
