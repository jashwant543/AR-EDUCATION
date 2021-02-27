using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class QuizOpamp : MonoBehaviour
{
    [Serializable]
    
    public class question
    {
        public string Question;

        public string Option_1;
        public string Option_2;
        public string Option_3;
        public string Option_4;
        public int correctOption = -1;
    }

    public question[] Questions;
    public static int CurrentQuestionIndex = 0;
    public GameObject quizCanvas;
    private GameObject correctAnsAudio;


    void Start()
    {
        correctAnsAudio = quizCanvas.transform.Find("CorrectAnsAudio").gameObject;
        // AlertScreen.SetActive(false);
        quizCanvas.GetComponent<AudioSource>().enabled = false;


        quizCanvas.transform.Find("QuestionDisplay").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Question;

        //display options 
        quizCanvas.transform.Find("1").Find("OptionText1").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Option_1;
        quizCanvas.transform.Find("2").Find("OptionText2").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Option_2;
        quizCanvas.transform.Find("3").Find("OptionText3").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Option_3;
        quizCanvas.transform.Find("4").Find("OptionText4").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Option_4;
    }


    public void CheckAnswer()
    {
        string ButtonClickedName = EventSystem.current.currentSelectedGameObject.name;

        if(ButtonClickedName == Questions[CurrentQuestionIndex].correctOption.ToString()) 
        {
            OperationAmplifier.ShowModels();
            StartCoroutine(ShowNextQuestion());
        }
        else
        {
            StartCoroutine(ShowRedAlert());
        }
    }
    

    IEnumerator ShowNextQuestion()
    {
        Image ButtonColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        ButtonColor.color = new Color32(0, 128, 0, 255);        // green Color
        
        //AlertScreen.SetActive(true);
        correctAnsAudio.GetComponent<AudioSource>().enabled = true;
        correctAnsAudio.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(1.5f);
        ButtonColor.color = new Color32(255, 255, 255, 255);       // Revert color back to white

        CurrentQuestionIndex++;
        // Image optionButton;
        if(CurrentQuestionIndex < Questions.Length)
        {
            if(CurrentQuestionIndex == Questions.Length-1)
            {
                quizCanvas.transform.Find("CircuitImage").gameObject.SetActive(true);                
            }
            quizCanvas.transform.Find("QuestionDisplay").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Question;

            //display options
            quizCanvas.transform.Find("1").Find("OptionText1").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Option_1;
            quizCanvas.transform.Find("2").Find("OptionText2").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Option_2;
            quizCanvas.transform.Find("3").Find("OptionText3").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Option_3;
            quizCanvas.transform.Find("4").Find("OptionText4").GetComponent<TextMeshProUGUI>().text = Questions[CurrentQuestionIndex].Option_4;
           
        }
        else
        {
            StartCoroutine(proceedTextDisplay());
        }
    }

    IEnumerator proceedTextDisplay()
    {
        quizCanvas.transform.Find("proceedText").gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        quizCanvas.SetActive(false);
    }

    IEnumerator ShowRedAlert()
    {
        Image ButtonColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        ButtonColor.color = new Color32(255, 0, 0, 255);        // Red Color
        
        //AlertScreen.SetActive(true);
        quizCanvas.GetComponent<AudioSource>().enabled = true;
        quizCanvas.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.0f);
        //AlertScreen.gameObject.SetActive(false);
        ButtonColor.color = new Color32(255, 255, 255, 255);       // Revert color back to white
    }
}
