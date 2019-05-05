using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 1.0f;
    [SerializeField]
    private GameObject letter;
    [SerializeField]
    private Sprite[] characters;

    private float timer;
    private GameObject myChar;
    private int whatChar;
    private int charCounter;
    private static string message = "hello     hello world    ";
    private readonly char[] messageChars = message.ToCharArray();

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime && charCounter < message.Length)
        {
            whatChar = SelectChar(messageChars[charCounter]);
            if (whatChar >= 0 && whatChar <= 26)    // Only accept a to z
            {
                myChar = Instantiate(letter, new Vector3(9f, -0.25f, 0f), Quaternion.identity);
                myChar.GetComponent<SpriteRenderer>().sprite = characters[whatChar];
            }
            charCounter++;
            timer = 0f;
        } else if (charCounter >= message.Length)   // If end of string restart
        {
            charCounter = 0;
        }
    }

    int SelectChar(char selChar)    // convert from char to "ascii code"
    {
        return selChar - 97;    // a has ascii code 97
    }
}
