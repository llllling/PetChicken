using UnityEngine;

public class Test : MonoBehaviour
{
    public void ClearScore()
    {
        GameManager.Instance.ResetAffectionScore();
        ChickenController controller = FindAnyObjectByType<ChickenController>();
        if (controller != null )
        {
            controller.ChangeChickenBodyColor(ChickenColors.WHITE);
        }
        FindAnyObjectByType<AffectionUI>().ChangeText();
    }

    public void ClearFeedTime()
    {
        PlayerPrefs.DeleteKey(Constract.FEED_COOLTIME_KEY);
    }
    public void ClearComplimentTime()
    {
        PlayerPrefs.DeleteKey(Constract.COMPLIMENT_COOLTIME_KEY);
    }

    public void ClearStrokingTime()
    {
        PlayerPrefs.DeleteKey(Constract.STROKING_COOLTIME_KEY);
    }
}
