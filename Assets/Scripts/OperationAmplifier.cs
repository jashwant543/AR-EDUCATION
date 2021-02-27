using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class OperationAmplifier : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject GraphBackground, showGraphButton;
    private GameObject InputWave, OutputWave;
    private float inInitial, outInitial;

    private Vector3 OriginalPosInputWave, OriginalPosOutputWave;
    private bool wavecreate = false;
    private float speed = 2f, inputAmplitude, outputAmplitude ;
    // public float inputVoltage = 5f, outputVoltage, gain, fbkResistance=2f, inputResistance = 1f;
    private float frequency = 0.0001f;
    private float xInitialIn;
    private GameObject FeedBackImpedanceText, UserFeedBackImpedanceText, UserGainText, UserOutputVoltageAmplitudeText, UserOutputVoltageText;
     
    private static GameObject IC, InputImpedance, FeedBackImpedance, ShowConnections, Connections, ShowGraphButton, FeedBackSlider, InfoCanvas;

    void Start()
    {
        

        GraphBackground = GameObject.Find("opamp").transform.Find("Canvas").Find("GraphBackGround").gameObject;
        IC = GameObject.Find("opamp").transform.Find("non-inverting").Find("IC").gameObject;
        InputImpedance = GameObject.Find("opamp").transform.Find("non-inverting").Find("InputImpedance").gameObject;
        FeedBackImpedance = GameObject.Find("opamp").transform.Find("non-inverting").Find("FeedBackImpedance").gameObject;
        ShowConnections = GameObject.Find("opamp").transform.Find("Canvas").Find("ShowConnections").gameObject;
        // Gain = GameObject.Find("opamp").transform.Find("non-inverting").Find("Gain").gameObject;
        ShowGraphButton = GameObject.Find("opamp").transform.Find("Canvas").Find("ShowGraph").gameObject;
        Connections = GameObject.Find("opamp").transform.Find("non-inverting").Find("Connections").gameObject;
        FeedBackSlider = GameObject.Find("opamp").transform.Find("Canvas").Find("FeedBackSlider").gameObject;

        InfoCanvas = GameObject.Find("opamp").transform.Find("InfoCanvas").gameObject;
        FeedBackImpedanceText = GameObject.Find("opamp").transform.Find("non-inverting").Find("FeedBackImpedance").Find("FeedBackImpedanceText").gameObject;
        
        UserFeedBackImpedanceText = GameObject.Find("opamp").transform.Find("InfoCanvas").Find("MainInfoRowImage").Find("UserFeedBackImpedanceText").gameObject;
        // UserGainText = GameObject.Find("opamp").transform.Find("Canvas").Find("GraphBackGround").Find("UserGainText").gameObject;
        // UserOutputVoltageAmplitudeText = GameObject.Find("opamp").transform.Find("Canvas").Find("GraphBackGround").Find("UserOutputVoltageAmplitudeText").gameObject;
        // UserOutputVoltageText = GameObject.Find("opamp").transform.Find("Canvas").Find("GraphBackGround").Find("UserOutputVoltageText").gameObject;
        
        InputWave = GameObject.Find("opamp").transform.Find("Canvas").Find("GraphBackGround").Find("InputWave").gameObject;
        OutputWave = GameObject.Find("opamp").transform.Find("Canvas").Find("GraphBackGround").Find("OutputWave").gameObject;
        
        OriginalPosInputWave = new Vector3 (InputWave.transform.position.x ,InputWave.transform.position.y ,InputWave.transform.position.z);
        OriginalPosOutputWave = new Vector3 (OutputWave.transform.position.x ,OutputWave.transform.position.y ,OutputWave.transform.position.z);

        // inInitial = InputWave.transform.position.y;
        // Debug.Log(inInitial);
        // outInitial = OutputWave.transform.position.y;
        // Debug.Log(outInitial);
        // xInitialIn = InputWave.transform.position.x;
    }

    float gain;
    public void ToggleGraph ()
    {
        StartCoroutine(ToggleGraphCoroutine());
        // float bgPos = GraphBackground.transform.localPosition.y;
        // string buttonText = showGraphButton.transform.Find("Text(TMP)").GetComponent<TextMeshProUGUI>().text;      
    }

    IEnumerator ToggleGraphCoroutine()
    {
        string ButtonClickedName = EventSystem.current.currentSelectedGameObject.name;
        
        if(ButtonClickedName == "ShowGraph")
        {
            resetWaveObjects();
            yield return new WaitForSeconds(0.5f);
            // gain = 1 + (fbkResistance/inputResistance);
            // outputVoltage = gain * inputVoltage;
            // inputAmplitude = inputVoltage / 10f;
            // outputAmplitude = outputVoltage / 10f;

            gain = 1 + ((Mathf.Round(FeedBackSlider.GetComponent<Slider>().value * 5)) / 1f);

            inputAmplitude = 1f;
            outputAmplitude = inputAmplitude * gain;
            
            InputWave.GetComponent<TrailRenderer>().time = 1000;
            OutputWave.GetComponent<TrailRenderer>().time = 1000;
            GraphBackground.SetActive(true);//.transform.localPosition = new Vector3(0f, -2f,0f);

            yield return new WaitForSeconds(0.5f);
            wavecreate = true;
            
        }
    }

    public void resetWaveObjects()
    {
        InputWave.transform.position = OriginalPosInputWave;
        OutputWave.transform.position = OriginalPosOutputWave;

        // reset trail
        InputWave.GetComponent<TrailRenderer>().time =0;
        OutputWave.GetComponent<TrailRenderer>().time =0;
    }

   
     
    private float constant;
    public void inputWaveGenerate()
    {
        float x = InputWave.transform.position.x + Time.time * frequency;
        float y = Mathf.Sin(Time.time * speed) * inputAmplitude;
        float z = InputWave.transform.position.z;

        if (InputWave.transform.localPosition.x > 310f)
        {
            wavecreate = false;
        }
        InputWave.transform.position = new Vector3(x, OriginalPosInputWave.y+y, z);
    }

    public void outputWaveGenerate()
    {
        float x = OutputWave.transform.position.x + Time.time * frequency;
        float y = Mathf.Sin(Time.time * speed )* outputAmplitude;
        float z = OutputWave.transform.position.z;

        if (OutputWave.transform.localPosition.x > 310f)
        {
            wavecreate = false; 
        }

        OutputWave.transform.position = new Vector3(x, OriginalPosOutputWave.y+y, z);
    }

    public static void ShowModels ()
    {
        switch (quiz.CurrentQuestionIndex)
        {
         case 0 : 
                 IC.SetActive(true);
                   break;
         case 1 : 
                FeedBackImpedance.SetActive(true) ;
                   break;
         case 2 :  
                InputImpedance.SetActive(true);
                ShowConnections.SetActive(true);
                    break;       
         case 3 : 
                 InfoCanvas.SetActive(true);
                // Gain.SetActive(true);
                  break;
         default : break;             
            
        }
          
    }

    public void CompleteCircuit()
    {
        Connections.SetActive(true);
        ShowGraphButton.SetActive(true);
        FeedBackSlider.SetActive(true);
    }

    public void FeedBackvalue ()
    {

        FeedBackImpedanceText.GetComponent<TextMeshPro>().text = "R<sub>f</sub> = " + Mathf.Round((FeedBackSlider.GetComponent<Slider>().value) * 5).ToString() + "k";
        UserFeedBackImpedanceText.GetComponent<TextMeshProUGUI>().text = "FeedBackImpedance (R<sub>f</sub>) = " + Mathf.Round((FeedBackSlider.GetComponent<Slider>().value) * 5).ToString() + "k";
        // UserGainText.GetComponent<TextMeshProUGUI>().text = "Gain = " + (gain).ToString();
        // UserOutputVoltageAmplitudeText.GetComponent<TextMeshProUGUI>().text = "V<sub>o(out)</sub> = " + (outputAmplitude ).ToString();
        // UserOutputVoltageText.GetComponent<TextMeshProUGUI>().text = "V<sub>o(out)</sub> = " + (outputAmplitude).ToString() + "Sin(Wt)" ;
    }

    // Update is called once per frame
    void Update()
    {
        if (wavecreate == true)
        {
            inputWaveGenerate();
            outputWaveGenerate();
        }
        FeedBackvalue();
    }
}