using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
public class TestDictation : MonoBehaviour
{
    public string[] keywords = new string[] {"close", "open", "switch"};
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    private PhraseRecognizer recognizer;
    protected string word = "right";
    public CamSwitcher cs;
    public PlayerSecurity ps;
    private void Start()
    {
        recognizer = new KeywordRecognizer(keywords, confidence);
        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        recognizer.Start();
    }
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        if (args.text == "close") ps.CommandDoor(false);
        else if (args.text == "open") ps.CommandDoor(true);
        else if (args.text == "restart") SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}