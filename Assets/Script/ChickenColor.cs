﻿using UnityEngine;

/// <summary>
/// 애정도에 따라 순서대로 레벨 1~7  
/// 흰색,
/// 노란색, 
/// 초록색, 
/// 파란색, 
/// 보라색,
/// 빨간색,
/// 검은색
/// </summary>
public enum ChickenColors
{
    WHITE,
    YELLOW,
    GREEN,
    BLUE,
    PURPLE,
    RED,
    BLACK
}

public static class ChickenColor
{
    /// <summary>
    /// 인자로 넘어온 애정도 점수에 해당하는 ChickenColors 열거형 타입의 값을 반환하는 함수
    /// </summary>
    public static ChickenColors ChickenColorByAffection(int affection)
    {
        return affection switch
        {
            int n when (n <= Constract.level_white) => ChickenColors.WHITE,
            int n when (n <= Constract.level_yellow) => ChickenColors.YELLOW,
            int n when (n <= Constract.level_green) => ChickenColors.GREEN,
            int n when (n <= Constract.level_blue) => ChickenColors.BLUE,
            int n when (n <= Constract.level_purple) => ChickenColors.PURPLE,
            int n when (n <= Constract.level_red) => ChickenColors.RED,
            _ => ChickenColors.BLACK,
        };
    }

    /// <summary>
    /// 인자로 넘어온 ChickenColors 열거형 타입의 값에 해당하는 애정도 점수를 반환하는 함수
    /// </summary>
    public static int AffectionByChickenColor(ChickenColors chickenColor)
    {
        return chickenColor switch
        {
            ChickenColors.WHITE => Constract.level_white,
            ChickenColors.YELLOW => Constract.level_yellow,
            ChickenColors.GREEN => Constract.level_green,
            ChickenColors.BLUE => Constract.level_blue,
            ChickenColors.PURPLE => Constract.level_purple,
            ChickenColors.RED => Constract.level_red,
            _ => Constract.level_black,
        };
    }

    /// <summary>
    /// 인자로 넘어온 ChickenColors 열거형 타입의 값에 해당하는 Color 값을 반환하는 함수
    /// </summary>
    public static Color ColorByChickenColors(ChickenColors chickenColor)
    {
        return chickenColor switch
        {
            ChickenColors.WHITE => Color.white,
            ChickenColors.YELLOW => Color.yellow,
            ChickenColors.GREEN => Color.green,
            ChickenColors.BLUE => Color.blue,
            ChickenColors.PURPLE => Color.magenta,
            ChickenColors.RED => Color.red,
            _ => Color.black,
        };
    }
}
