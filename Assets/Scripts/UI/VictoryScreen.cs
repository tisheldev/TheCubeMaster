using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void Show()
    {
        Debug.Log("Victory screen showing!");
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}