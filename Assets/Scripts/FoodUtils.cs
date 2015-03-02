using System;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System.Collections;

public static class FoodUtils {
    public static int foodWork(String nameFood)
    {
        int numberFood = 11;
        switch (nameFood)
        {
            case "Food 0(Clone)":
                numberFood = 0;
                break;
            case "Food 1(Clone)":
                numberFood = 1;
                break;
            case "Food 2(Clone)":
                numberFood = 2;
                break;
            case "Food 3(Clone)":
                numberFood = 3;
                break;
            case "Food 4(Clone)":
                numberFood = 4;
                break;
            case "Food 5(Clone)":
                numberFood = 5;
                break;
            case "Food 6(Clone)":
                numberFood = 6;
                break;
            case "Food 7(Clone)":
                numberFood = 7;
                break;
            case "Food 8(Clone)":
                numberFood = 8;
                break;
            case "Food 9(Clone)":
                numberFood = 9;
                break;
        }
        return numberFood;
    }
}
