using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class JsonObjects : MonoBehaviour
{
    GameObject[] obs;
    public class Item
    {
        public string name { get; set; }
        public List<float> position { get; set; }
    }

    public class Root
    {
        public List<Item> items { get; set; }
    }

    private GameObject LoadPrefabFromFile(string filename)
    {
        Debug.Log("Trying to load Prefab from file (" + filename + ")...");
        GameObject loadedObject = Resources.Load<GameObject>(filename);
        if (loadedObject == null)
        {
            throw new FileNotFoundException("...no file found - please check the configuration");
        }
        return loadedObject;
    }



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("objects is called");
        //read from json template,merge by analze the speech/should be in hierachical structure /speech -- action
        string jsonFilePath = "C:/Users/lanru/Desktop/HoloLens/Assets/Json/template_objects.json";
        string jsonContent = File.ReadAllText(jsonFilePath);
        Debug.Log(jsonContent);

        Root root = JsonConvert.DeserializeObject<Root>(jsonContent);
        foreach(Item item in root.items)
        {
            Debug.Log(item.name);
            GameObject loadedPrefabResource = LoadPrefabFromFile(item.name);
            GameObject cloneprefab = Instantiate(loadedPrefabResource);
            GameObject MixedRealitySceneContent = GameObject.Find("MixedRealitySceneContent");
            cloneprefab.transform.SetParent(MixedRealitySceneContent.transform, true);
            cloneprefab.transform.localPosition = new Vector3(item.position[0], item.position[1], item.position[2]);
            Debug.Log("loaded successfully");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
