using UnityEngine;

public class Activity : MonoBehaviour
{
    // Looping activity 

    int size = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        //CreateShape3(size);

        //CreateShape4(size);

        CreateShape5(size);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateShape(int size)
    {
        string shape = "";

        for (int i = 0; i < size; i++)
        {
            shape += "***\n";
            Debug.Log("i: " + i);
        }

        Debug.Log("Result: \n" + shape);
    }



    // Question 2



    void CreateShape2(int size)
    {
        string shape = "";

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j <= i; j++)
            {

                shape += "*";

            }

            shape += "\n";





        }

        Debug.Log("Result: \n" + shape);

    }




    void CreateShape3(int size)
    {


        string shape = "";
        int originalSize = size;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < originalSize; j++)  // or j < size - i
            {
                shape += "*";

            }
            originalSize--;
            shape += "\n";

        }

        Debug.Log("Result: \n" + shape);



    }


    void CreateShape4(int size)
    {
        string shape = "";
        for (int i = 0; i < size; i++)
        {

            for (int j = 0; j < size; j++)
            {

                shape += size - j;

            }

            shape += "\n";
        }

        Debug.Log("Result: \n" + shape);




    }


    void CreateShape5(int size)
    {
        string shape = "";


        for (int i = 0; i < size; i++)
        {

            for (int j = 0; j <= i; j++)
            {

                shape += size - i;


            }

            shape += "\n";

        }

        Debug.Log("Result: \n" + shape);


    }



    void CreateShape6(int size)
    {
        string shape = "";






        Debug.Log("Result: \n" + shape);







    }

}
