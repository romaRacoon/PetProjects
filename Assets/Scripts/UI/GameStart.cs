using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Image _tapToStartImage;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _tapToStartImage.gameObject.SetActive(false);
            Time.timeScale = 1;
            enabled = false;
        }
    }
}
