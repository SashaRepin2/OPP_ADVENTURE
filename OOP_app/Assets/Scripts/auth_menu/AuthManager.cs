using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml.Linq;
using UnityEngine.Networking;


public class AuthManager : MonoBehaviour
{
    public static string USER_NAME;
    public static string USER_GROUP;
    public const string url = "https://sdo.ksu.edu.ru/";

    /// <summary>
    /// Login Input Field
    /// </summary>
    public InputField loginField;

    /// <summary>
    /// Password Input Field
    /// </summary>
    public InputField passwordField;

    /// <summary>
    /// Click on enter button - auth user in the system SDO
    /// </summary>
    public void LoginIn()
    {
        StartCoroutine(SendRequestForAuth());
    }

    private class ResponseJSON
    {
        public string token;
    }

    private IEnumerator SendRequestForAuth()
    {
        // Getting data from Login Field
        string inputedLogin = loginField.text;

        // Getting data from Password Field
        string inputedPassword = passwordField.text;
        inputedPassword = inputedPassword.Replace("#", "%23");

        string userId = null;

        UnityWebRequest request = UnityWebRequest.Get(url + "login/token.php?service=moodle_mobile_app&password=" + inputedPassword + "&username=" + inputedLogin);

        yield return request.SendWebRequest();

        ResponseJSON responseJson = JsonUtility.FromJson<ResponseJSON>(request.downloadHandler.text);
        Debug.Log(inputedPassword);

        // Если пользователь ввёл неправильно логин или пароль, то вернётся null
        if (responseJson.token != null)
        {

            UnityWebRequest requestForId = UnityWebRequest.Get(url + "webservice/rest/server.php?wstoken=" + responseJson.token.ToString() + "&wsfunction=block_recentlyaccesseditems_get_recent_items");
            yield return requestForId.SendWebRequest();

            Debug.Log(requestForId.downloadHandler.text);
            XDocument doc = XDocument.Parse(requestForId.downloadHandler.text);

            foreach (XElement elem in doc.Element("RESPONSE").Element("MULTIPLE").Element("SINGLE").Elements("KEY"))
            {
                XAttribute nameAttribute = elem.Attribute("name");

                if (nameAttribute.Value == "userid")
                {
                    userId = elem.Element("VALUE").Value;

                    Debug.Log(userId);
                    break;
                }
            }

            UnityWebRequest requestForName = UnityWebRequest.Get(url + "webservice/rest/server.php?wstoken=" + responseJson.token.ToString() + "&wsfunction=core_user_get_users_by_field&field=id&values[0]=" + userId.ToString());
            yield return requestForName.SendWebRequest();

            Debug.Log(requestForName.downloadHandler.text);
            XDocument doc_2 = XDocument.Parse(requestForName.downloadHandler.text);

            foreach (XElement elem in doc_2.Element("RESPONSE").Element("MULTIPLE").Element("SINGLE").Elements("KEY"))
            {
                XAttribute nameAttribute = elem.Attribute("name");

                if (nameAttribute.Value == "fullname")
                {
                    USER_NAME = elem.Element("VALUE").Value;
                    USER_NAME = USER_NAME.ToUpper();

                    Debug.Log(USER_NAME);
                    break;
                }

                if (nameAttribute.Value == "username")
                {
                    USER_GROUP = elem.Element("VALUE").Value;

                    USER_GROUP = USER_GROUP.Remove(5).ToUpper();

                    Debug.Log(USER_GROUP);
                }
            }

            // Загружаем меню с уровнями
            SceneManager.LoadScene("menu_levels");
        }
        else
        {
            // Выводи сообщения об ошибке пользователю
            MessageController messageController = FindObjectOfType<MessageController>();
            messageController.ShowMessage("Ошибка!", "Неправильный логин или пароль.", MessageController.TypeMessage.Error, 15);

            Debug.Log("Error: " + (responseJson == null ? responseJson.token.ToString() : "null"));
        }
    }
}

