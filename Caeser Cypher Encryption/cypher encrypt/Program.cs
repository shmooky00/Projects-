using ch12prob8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch12prob8
{
    interface ICrypto
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }

    class Program
    {
        static void Main()
        {

            ICrypto c1 = new Cipher1();
            
            ICrypto c2 = new Cipher2();

           
            Console.Write("Enter a message to encrypt: ");

            string message = Console.ReadLine();

            void TCipher(ICrypto cipher, string name) //user input for console word
            {
                string encrypted = cipher.Encrypt(message);

                string decrypted = cipher.Decrypt(encrypted);

                Console.WriteLine($"{name} Encryption: {encrypted}");

                Console.WriteLine($"{name} Decryption: {decrypted}");
            }

            TCipher(c1, "Cipher1");
            //display encyption and decryptions for both
            TCipher(c2, "Cipher2");

            Console.ReadKey();
        }
    }

    public class Cipher1 : ICrypto
    {
      
        public string Encrypt(string text)
        {
 
            return Cipher(text, 6); //shift forward 6
        }

        

        public string Decrypt(string text)
        {
         

            return Cipher(text, -6); //shift back 6
        }

        
        private string Cipher(string text, int shift) //handles encryption and decryption
        {
                        
            if (string.IsNullOrEmpty(text)) //no changes made if input is letter

                return text;

            List<char> result = new List<char>();

            
            foreach (char c in text)
            {
                                
                if (char.IsLetter(c)) 
                {
                    char move = (c >= 'A' && c <= 'Z') ? 'A' : 'a'; //checks if capital or lowercase

                    
                    char moved = (char)((c - move + shift + 26) % 26 + move); //caeser shift formula 

                    result.Add(moved);

                    
                }
                else
                {
                    
                    result.Add(c); //results dispplayed if unchanged 
                }
            }
                        
            return new string(result.ToArray());
        }
    }
}




public class Cipher2 : ICrypto
{
    

    public string Encrypt(string text)
    {

        return Cipher(text, 2); //forward shift 2
    }

    

    public string Decrypt(string text)
    {


        return Cipher(text, -2); //back shift 2
    }


    private string Cipher(string text, int shift) //handles encryption and decryption
    {

        if (string.IsNullOrEmpty(text)) //no changes made if input is letter

            return text;

        List<char> result = new List<char>();

        
        foreach (char c in text)
        {

            

            if (char.IsLetter(c)) //make sure its only letters 
            {
                char move = (c >= 'A' && c <= 'Z') ? 'A' : 'a'; //checks letters if capital 
                                
                char moved = (char)((c - move + shift + 26) % 26 + move); //caeser shift formula 


                result.Add(moved);


            }
            else
            {
                
                result.Add(c); //results dispplayed if unchanged 
            }
        }

       
        return new string(result.ToArray());
    }
}




