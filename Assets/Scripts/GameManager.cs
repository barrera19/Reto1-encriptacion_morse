using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
 public Input inputText;
 public TMP_Text textOutput, textEncrypt;
 public string morseText, morseNum, toEncrypt, textEncrypted;
 public List<int> numToEncrypt = new List<int>();
 public List<string> splitedMorse = new List<string>();

 public Dictionary<char, string> codeMorse = new Dictionary<char, string>() {
    {'A' ,".-"},{'B' ,"-..."},{'C' ,"-.-."},{'D' ,"-.."},{'E' ,"."},{'F' ,"..-."},{'G' ,"--."},
    {'H' ,"...."},{'I' ,".."},{'J' ,".---"},{'K' ,"-.-"},{'L' ,".-.."},{'M' ,"--"},{'N' ,"-."},
    {'O' ,"---"},{'P' ,".--"},{'Q' ,"--.-"},{'R' ,".-."},{'S' ,"..."},{'T' ,"-"},{'U' ,"..-"},
    {'V' ,"...-"},{'W' ,".--"},{'X' ,"-..-"},{'Y' ,"-.--"},{'Z' ,"--.."},{'_' ,"..--"},
    {'.' ,"---."},{',' ,".-.-"},{'?' ,"----"}};

 public void readText(string textToEncrypt)
 {  //Leo el texto tiempo real e inicializo variables de entradas
   toEncrypt = textEncrypted = null;
   textToEncrypt = textToEncrypt.ToUpper();
   textOutput.text = textToEncrypt;  
   toEncrypt = textToEncrypt;
 }

 public void ToEncrypt()
   {   
      morseNum = null;
      morseText = null;
      numToEncrypt = new List<int>();
      splitedMorse = new List<string>();
      textEncrypted = null;

      print("Texto a Encriptar: " + toEncrypt);
          foreach(char c in toEncrypt) {
            if(codeMorse.ContainsKey(c))
            {
               morseText += codeMorse[c];
               morseNum += codeMorse[c].Length;
            }
         }
         // print("Esto es Text en Morse: " + morseText); print("Esto mide MorseText: " + morseNum);
       textOutput.text = morseText;

      if(morseText!=null){
        reverse();
        createTextEncrypted();
      }
      else { textOutput.text = "Inserte un Texto Válido"; }

   }

   void reverse()
   {
      char[] arrayNum = new char[morseNum.Length -1]; 
      arrayNum = morseNum.ToCharArray();
      Array.Reverse(arrayNum);
      for(int i= 0; i<= morseNum.Length-1; i++)
      {
         numToEncrypt.Add(Int16.Parse(arrayNum[i].ToString()));
      }    
   }

   void createTextEncrypted()
   {
      int position = 0;
      for(int i= 0; i<= morseNum.Length-1; i++)
      {     //Divido mi codigo morse generado según los números para encriptar
            splitedMorse.Add(morseText.Substring(position,numToEncrypt[i]));
            position +=numToEncrypt[i];
  
            //print("Position: " +position + " Num-i: " + numToEncrypt[i]);
      }

      char keyT = new();
      string valueT = null;
      int count = 0;
  
         while(count < splitedMorse.Count)
         {
            if(codeMorse.ContainsValue(splitedMorse[count]))
            {
               foreach(KeyValuePair<char, string> keyValue in codeMorse)    
               {  
                  keyT = keyValue.Key;
                  valueT = keyValue.Value; 
                  if(valueT == splitedMorse[count])
                     textEncrypted += keyT; 
               }
            }
            count++;
         }   
   }

   public void saveFile()
   {
      string newFile = string.Format("{0}/{1].txt",Application.persistentDataPath,"EncryptedText");
      File.WriteAllText(newFile , textEncrypted);
   }

   public void TextEncrypted()
   { 
      textEncrypt.text = textEncrypted; 
   } 

}
