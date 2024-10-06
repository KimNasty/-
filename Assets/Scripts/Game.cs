using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{
    public static Game Instance;
    private UIManager uiManager;

    [SerializeField] private TMP_Text _countMetalText;
    [SerializeField] private TMP_Text _countBiomasText;
    [SerializeField] private TMP_Text _countPlasticText;
    [SerializeField] private TMP_Text _countRubberText;
    public int CountMetal {  get; private set; }
    public int CountPlastic {  get; private set; }
    public int CountBiomas {  get; private set; }
    public int CountRubber {  get; private set; }

    private void Awake()
    {
        Instance = this;
        uiManager = FindObjectOfType<UIManager>(); 
    }

    private void Start()
    {
        ShowInfoMessage("Пятьдесят лет назад люди начали покидать Землю из-за того," +
            " что она перестала быть пригодной для жизни. Разлагающиеся отходы " +
            "сделали почву малопригодной для выращивания растений, а вскоре и атмосфера" +
            " стала опасной для человека. Сейчас люди живут на космической станции. Но это решение" +
            " не может быть долгосрочным. Вы должны помочь людям исправить их ошибки!");
    }

    public void ShowInfoRobotMessage(string message)
    {
        Debug.Log(message);
        uiManager.ShowInfoRobotMessage(message);
    }

    public void ShowInfoMessage(string message, float time=10f)
    {
        Character.Instance.IsActivated = true;
        uiManager.ShowInfoMessage(message, time);
        ReactivateCharacter(5f);
    }

    public void ShowMessage(string message)
    {
        if (uiManager != null)
        {
            uiManager.ShowMessage(message);
        }
    }

    public void ChangeMetal(int count)
    {
        CountMetal += count;
        _countMetalText.text = CountMetal.ToString();
    }

    public void ChangePlastic(int count)
    {
        CountPlastic += count;
        _countPlasticText.text = CountPlastic.ToString();
    }

    public void ChangeBiomass(int count)
    {
        CountBiomas += count;
        _countBiomasText.text = CountBiomas.ToString();
    }

    public void ChangeRubber(int count)
    {
        CountRubber += count;
        _countRubberText.text = CountRubber.ToString();
    }

    private IEnumerator ReactivateCharacter(float time)
    {
        // Ожидаем заданное время
        yield return new WaitForSeconds(time);

        // После истечения времени, активируем персонажа
        Character.Instance.IsActivated = true;
    }
}
