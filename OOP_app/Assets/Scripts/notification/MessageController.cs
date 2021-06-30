using UnityEngine;
using UnityEngine.UI;
public class MessageController : MonoBehaviour
{
    public enum TypeMessage
    {
        Warning,
        Error,
        Info
    }

    public Animation anim;
    public Sprite[] sprites;

    public Canvas message;
    public Image imageMessage;
    public Text titleMessage;
    public Text textMessage;

    /// <summary>
    /// Текущее состояние сообщения
    /// </summary>
    public bool isShowing = false;

    /// <summary>
    /// Длительность показа сообщения в сек.
    /// </summary>
    public float duration = 15;

    /// <summary>
    /// Тип сообщения
    /// </summary>
    public TypeMessage type;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        message.enabled = isShowing;
        ChangeIcon();
    }

    // Update is called once per frame
    void Update()
    {
        // Показываем/скрываем сообщение
        message.enabled = isShowing;

        // Проверяем показано ли сообщение 
        if (isShowing)
        {
            // Уменьшаем оставшееся время показа
            duration -= Time.deltaTime;

            // Проигрываем анимацию закрытия сообщения, если время вышло
            if (duration <= 0)
            {
                anim.Play("close", PlayMode.StopAll);
            }

        }
    }


    public void ShowMessage(string title, string text, TypeMessage type, float duration)
    {
        // Options of message
        this.titleMessage.text = title;
        this.textMessage.text = text;
        this.type = type;
        this.duration = duration;
        this.isShowing = true;

        ChangeIcon();

        // Animation - showing message
        anim.Play("open", PlayMode.StopAll);
    }

    /// <summary>
    /// Closing the message when user clicks
    /// </summary>
    public void OnClickMessage()
    {
        duration = 0;
    }


    /// <summary>
    /// Hiding the message when anim ends
    /// </summary>
    public void OnTriggered()
    {
        isShowing = false;
    }

    /// <summary>
    /// Change icon of message
    /// </summary>
    private void ChangeIcon()
    {

        switch (type)
        {
            case TypeMessage.Error:
                {
                    imageMessage.sprite = sprites[0];
                    break;
                }
            case TypeMessage.Warning:
                {
                    imageMessage.sprite = sprites[1];
                    break;
                }
            case TypeMessage.Info:
                {
                    imageMessage.sprite = sprites[2];
                    break;
                }
            default:
                imageMessage.sprite = sprites[0];
                break;
        }
    }

}
