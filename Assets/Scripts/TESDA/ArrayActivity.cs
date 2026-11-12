using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using UnityEngine;
public class ArrayActivity : MonoBehaviour
{



    [SerializeField]
    List<int> numbers = new List<int>();
    [SerializeField]
    List<string> names = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SortArray(numbers);

        RemoveVowels(names);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SortArray(List<int> numbersList)
    {
     
        List<int> evenNumbers = new List<int>();
        List<int> oddNumbers = new List<int>();

        foreach (int number in numbersList)
        {
            Debug.Log(number);

            if (number % 2 == 0)
            {
                evenNumbers.Add(number);

            }

            else
            {
                oddNumbers.Add(number);

            }
        }

        foreach (int evenNumber in evenNumbers)
        {
            Debug.Log("Even Number: " + evenNumber);
        }

        foreach (int oddNumber in oddNumbers)
        { 

            Debug.Log("Odd Number: " + oddNumber);

        }



    }


    void RemoveVowels(List<string> nameList)
    {

        List<string> withoutVowelsList = new List<string>();
        string vowels = "aeiouAEIOU";
        string noVowelNames = "";

        foreach (string name in nameList)
        { 
            Debug.Log("Name: " + name);
            noVowelNames = "";

            foreach(char letter in name)
            {
                if (!vowels.Contains(letter))
                {
                    noVowelNames += letter;

                }

                
            }
            withoutVowelsList.Add(noVowelNames);


        }

        foreach (string nameWithoutVowels in withoutVowelsList)
        {
            Debug.Log("Name without vowels: " + nameWithoutVowels);
        }

    }






}



