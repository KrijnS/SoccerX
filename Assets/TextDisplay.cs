using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public Text text;
    System.Random random;

    int lastNamesCount;
    int frontNamesCount;

    string[] lastNames;
    string[] frontNames;

    // Start is called before the first frame update
    void Start()
    {
        lastNames = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\Football App\last name.txt", Encoding.UTF8);
        frontNames = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\Football App\front name.txt", Encoding.UTF8);

        lastNamesCount = lastNames.Length;
        frontNamesCount = frontNames.Length;

        text = GameObject.Find("Text").GetComponent<Text>(); ;

        text.enabled = false;

        random = new System.Random();
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            text.enabled = true;

            int pickLastName = random.Next(lastNamesCount);
            int pickFrontName = random.Next(frontNamesCount);

            text.text = frontNames[pickFrontName] + " " + lastNames[pickLastName];
        }

    }

}
