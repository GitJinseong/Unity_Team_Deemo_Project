//using System.Collections;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using UnityEngine;

//public class Choi_CSVWriter : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        Park_CSVReader.instance.dataDictionary["Easy"][0] = "33";
//        Park_CSVReader.instance.WriteCSVFile("MusicList");
//        Debug.Log(Park_CSVReader.instance.dataDictionary["Easy"][0]);
//        Park_CSVReader.instance.SaveCSVDataToPlayerPrefs("MusicList");
//        // Ư�� Ű�� �ε����� PlayerPrefs�� ����� ���� ��������
//        string value = Park_CSVReader.instance.GetValueAtIndexFromPlayerPrefs("Easy", 0);
//        if (value != null)
//        {
//            Debug.Log(value);
//        }
//        StartCoroutine(delay());
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public IEnumerator delay()
//    {
//        yield return new WaitForSeconds(1f);
//        Park_CSVReader.instance.WriteCSVFile("MusicList");
//        Park_CSVReader.instance.SaveCSVDataToPlayerPrefs("MusicList");
//        string value = Park_CSVReader.instance.GetValueAtIndexFromPlayerPrefs("Easy", 0);
//        if (value != null)
//        {
//            Debug.Log(value);
//        }
//    }
//}
