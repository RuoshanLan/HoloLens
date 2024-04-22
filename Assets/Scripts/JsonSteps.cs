using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class JsonSteps : MonoBehaviour
{
    public class Step
    {
        public string name { get; set; }
        public string interaction_way { get; set; }
        public string start_status { get; set; }
        public string end_status { get; set; }
        public string speed { get; set; }
        public string tools { get; set; }
        public string items { get; set; }
    }

    public class Root
    {
        public List<Step> steps { get; set; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("step is called");
        //read from json template,merge by analze the speech/should be in hierachical structure /speech -- action
        string jsonFilePath = "C:/Users/lanru/Desktop/HoloLens/Assets/Json/template_steps.json";
        string jsonContent = File.ReadAllText(jsonFilePath);
        Root data = JsonConvert.DeserializeObject<Root>(jsonContent);
        Debug.Log(data);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
