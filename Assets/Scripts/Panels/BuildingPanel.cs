using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class BuildingPanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private float targetAlpha = 0;
    private float smoothing = 5;

    private Button close;
    protected Text title;

    public virtual void Start()
    {
        close = transform.Find("Close").GetComponent<Button>();
        title = transform.Find("Title").GetComponent<Text>();

        close.onClick.AddListener(Hide);

        canvasGroup = transform.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
    }

    public virtual void Update()
    {
        if (canvasGroup != null && canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.02f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }
    }

    public virtual void Show()
    {
        canvasGroup.blocksRaycasts = true;
        targetAlpha = 1;
    }
    public virtual void Hide()
    {
        canvasGroup.blocksRaycasts = false;
        targetAlpha = 0;
    }
    public virtual void Toggle()
    {
        if (targetAlpha == 0)
        {
            Show();
        }
        else if (targetAlpha == 1)
        {
            Hide();
        }
    }
}