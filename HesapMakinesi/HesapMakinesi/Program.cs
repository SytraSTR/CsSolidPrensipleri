using System.Collections.Generic;
using System;

namespace CalculatorApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program _program = new Program();
            _program.MainScreen();
        }

        public void MainScreen()
        {
            while (true)
            {
                Input _input = new Input();
                _input.ConsoleIn();//SOLID prensiblerine uygun olabilmesi için metotlar halinde parça parça ayırdım ve Input metotundan başlamasını istedim.

                Console.Write("Lütfen tekrar başlatmak istiyorsanız herhangi tuşa basın, Çıkmak için 'H' basın. ");
                string answer = Console.ReadLine();
                if (answer.ToUpper() == "H")//Girilen harf Büyük olsa da Küçük olsa da kabul etmesi için "ToUpper()" kullandım.
                {
                    break;
                }
            }
        }
    }
    class Input()
    {     
        public int number1, number2;
        public double result = 0;
        public Operations op;

        public void ConsoleIn()
        {
            OperationInput();
            NumberInput();
        }

        public void OperationInput()
        {
            while (true)
            {
                Console.Write("İşlem seçiniz (+, -, *, /): ");
                string input = Console.ReadLine();

                if (Enum.TryParse(input switch
                {
                    "+"  => "Addtion",
                    "-" => "Subtraction",
                    "*" => "Multiply",
                    "/" => "Division",
                    _ => null
                }, out Operations parsedOp))
                {
                    op = parsedOp;
                    break;
                }
                else
                {
                    Console.WriteLine("Yanlış İşlem.");
                }
            }
        }

        public void NumberInput()
        {
            int GetNumber(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        return number;
                    }
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı giriniz.");
                }
            }
            number1 = GetNumber("1. Sayıyı giriniz: ");
            number2 = GetNumber("2. Sayıyı giriniz: ");

            Control _control = new Control();
            _control.OperatorKontrol(op,number1,number2,result);
        }
    }

    enum Operations
    {
        Addtion, Subtraction, Multiply, Division
    }
    class Control
    {
        public void OperatorKontrol(Operations op, int number1, int number2, double result)
        {
            Operation _operation = new Operation();
            switch (op)
            {
                case Operations.Addtion:
                    result = _operation.Addtion(number1, number2);
                    break;
                case Operations.Subtraction:
                    result = _operation.Subtraction(number1, number2);
                    break;
                case Operations.Multiply:
                    result = _operation.Multiply(number1, number2);
                    break;
                case Operations.Division:
                    result = _operation.Division(number1, number2);
                    break;
            }
            Output _output = new Output();
            _output.ConsoleOut(result);//Sınıf nesnelerini tanımlarken Ayırt edebilmek için başa "_" kullanıyorum.
        }
    }
    class Operation()
    {
        public int Addtion(int number1, int number2)
        {
            return number1 + number2;
        }

        public int Subtraction(int number1, int number2)
        {
            return number1 - number2;
        }

        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        public double Division(int number1, int number2)
        {
            return (double)number1 / number2;//Değeri double olarak çıkartmak için "(double)" kullanıldım.
        }
    }
    class Output()
    {
        public void ConsoleOut(double result)
        {
            Console.WriteLine("Sonuç; " + result);
        }
    }
}