using System.Collections;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine.UIElements;

public class TextControl : MonoBehaviour
{
    public TextMeshProUGUI TextData;
    public string Message;
    public float Speed = 0.02f;
    public GameObject Textbox;
    public GameObject HB;

    private Coroutine write;
    private bool writing = false;
    private bool finish = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!writing && !finish)
            {
                HB.SetActive(false);
                Textbox.SetActive(true);
                StartWriting(Message);
            }
            else if (writing)
            {
                Skip();
            }
            else
            {
                HB.SetActive(true);
                Textbox.SetActive(false);
                finish = false;
            }
        }
        
    }

    public void StartWriting(string newmessage)
    {
        Message = newmessage;

        if (write != null)
        {
            StopCoroutine(write);
        }
        write = StartCoroutine(AnimatedText());
    }
    IEnumerator AnimatedText()
    {
        writing = true;
        TextData.text = "";

        foreach (char L in Message.ToCharArray())
        {
            TextData.text += L;
            yield return new WaitForSeconds(Speed);
        }
        writing = false;
        finish = true;
    }
    public void Skip()
    {
        if (writing)
        {
            StopCoroutine(write);
            TextData.text = Message;
            writing = false;
            finish = true;
        }
    }
}
