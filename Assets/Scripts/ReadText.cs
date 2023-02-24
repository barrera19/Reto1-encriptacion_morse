using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadText : MonoBehaviour
{
 public Input inputText;
 public TMP_Text textOutput;
 public string morseText, morseNum, textEncrypted; 
 public List<int> numToEncrypt = new List<int>();
 public List<string> splitedMorse = new List<string>();
 public string toEncrypt;

 public Dictionary<char, string> codeMorse = new Dictionary<char, string>() {
    {'A' ,".-"},{'B' ,"-..."},{'C' ,"-.-."},{'D' ,"-.."},{'E' ,"."},{'F' ,"..-."},{'G' ,"--."},
    {'H' ,"...."},{'I' ,".."},{'J' ,".---"},{'K' ,"-.-"},{'L' ,".-.."},{'M' ,"--"},{'N' ,"-."},
    {'O' ,"---"},{'P' ,".--"},{'Q' ,"--.-"},{'R' ,".-."},{'S' ,"..."},{'T' ,"-"},{'U' ,"..-"},
    {'V' ,"...-"},{'W' ,".--"},{'X' ,"-..-"},{'Y' ,"-.--"},{'Z' ,"--.."},{'_' ,"..--"},
    {'.' ,"---."},{',' ,".-.-"},{'?' ,"----"}};

 public void readText(string textToEncrypt)
 {
   toEncrypt = null;
   textToEncrypt = textToEncrypt.ToUpper();
   textOutput.text = textToEncrypt;  
   toEncrypt = textToEncrypt;
 }

 public void ToEncrypt()
   {
      morseNum = null;
      morseText = null;
      numToEncrypt = null; 

      print("Texto a Encriptar: " + toEncrypt);
          foreach(char c in toEncrypt) {
            if(codeMorse.ContainsKey(c))
            {
               morseText += codeMorse[c];
               morseNum += codeMorse[c].Length;
            }
         }
         print("Esto es Text en Morse: " + morseText); 
         print("Esto mide MorseText: " + morseNum);
       textOutput.text = morseText;

     reverse();
     createTextEncrypted();

   }

   void reverse()
   {
      char[] arrayNum = new char[morseNum.Length-1]; 
      arrayNum = morseNum.ToCharArray();
      Array.Reverse(arrayNum);
      for (int i = 0; i<= morseNum.Length-1 ; i++)
      {
            string temp = arrayNum[i].ToString();
            print("esto es I: " +i +" y esto es TEMP: " +temp);
            numToEncrypt.Add(Int16.Parse(temp));
      }     
   }

   void createTextEncrypted()
   {
      foreach(int i in numToEncrypt)
      {
         string newValue = morseText.Substring(i);
         splitedMorse.Add(newValue); 
      }
   }

}
