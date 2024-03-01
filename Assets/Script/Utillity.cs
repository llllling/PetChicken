
using System;

public static class Utility
{
    /// <summary>
    ///  특정 값이 주어진 최솟값(minValue)과 최댓값(maxValue) 범위에서 어디에 위치하는지 
    ///  상대적인 위치를 0과 1 사이로 정규화된 값으로 계산하는 함수
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minValue">범위 최솟값</param>
    /// <param name="maxValue">범위 최댓값</param>
    /// <returns> 0과 1사이에서 위치값</returns>
    public static float CalculateRelativePosition(float value, float minValue, float maxValue)
    {
        float normalizedValue = (value - minValue) / (maxValue - minValue);
        return Math.Max(0.0f, Math.Min(1.0f, normalizedValue));
    }
}
