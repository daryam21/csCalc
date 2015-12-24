﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string input = "";
        //private static double numinput = 0.0;

            //handler
        private void button_clicked(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "button1":
                    this.textBox1.Text += "1";
                    break;
                case "button2":
                    this.textBox1.Text += "2";
                    break;
                case "button3":
                    this.textBox1.Text += "3";
                    break;
                case "button4":
                    this.textBox1.Text += "4";
                    break;
                case "button5":
                    this.textBox1.Text += "5";
                    break;
                case "button6":
                    this.textBox1.Text += "6";
                    break;
                case "button7":
                    this.textBox1.Text += "7";
                    break;
                case "button8":
                    this.textBox1.Text += "8";
                    break;
                case "button9":
                    this.textBox1.Text += "9";
                    break;
                case "button0":
                    this.textBox1.Text += "0";
                    break;
                case "enterButton":
                    input = this.textBox1.Text;
                    this.textBox1.Text = "";
                  string res = findResult(input);
                    this.textBox1.Text = res;
                    break;
                case "plusButton":
                    this.textBox1.Text += "+";
                    break;
                case "minusButton":
                    this.textBox1.Text += "-";
                    break;
                case "multiplyButton":
                    this.textBox1.Text += "*";
                    break;
                case "divideButton":
                    this.textBox1.Text += "/";
                    break;



            }
        }

      private static string findResult (string input)
        {
            if (input.Contains("+") || input.Contains("-") || input.Contains("/") || input.Contains("*") || input.Contains("sqrt"))
            {
                
                int i = 0;
                int a = 0;
                double output = 0.0;
                char[] toSplit = { '+', '-', '/', '*' };
                string[] numstr = new string[input.Length];
                double[] numbers = new double[input.Length];
                char[] operators = new char[input.Length];
                numstr = input.Split(toSplit, StringSplitOptions.RemoveEmptyEntries);
                foreach (char c in input)
                {
                    if (!(char.IsDigit(c)))
                    {
                        operators[i] = c;
                        i++;
                    }
                    
                }
                i = 0;
                foreach (string s in numstr)
                {
                    double.TryParse(s, out numbers[i]);
                    i++;
                }

                int inc = 0;
                var indexes = new List<int>();
                var finalnumbers = new List<double>(numbers);
                for (int c = 0; c < operators.Length; c++)
                {
                    if (operators[c].Equals('*') || operators[c].Equals('/'))
                    {
                        indexes.Add(c);
                    }
                }
                if ((indexes.Any<int>()))
                {

                    foreach (int index in indexes)
                    {
                        switch (operators[index])
                        {

                            case '/':
                                output += finalnumbers[index] / numbers[index + 1];
                                finalnumbers.RemoveAt(index);
                                finalnumbers.RemoveAt(index + 1);
                                break;
                            case '*':
                                output += finalnumbers[index] * numbers[index + 1];
                                finalnumbers.RemoveAt(index);
                                finalnumbers.RemoveAt(index + 1);
                                break;

                        }
                    }
                    foreach (double n in finalnumbers)
                    {
                        
                            switch (operators[inc])
                            {
                                case '+':
                                    output += n;
                                    break;
                                case '-':
                                    output -= n;
                                    break;
                            }
                        

                        inc++;
                    }
                    return output.ToString();
                 
                }

                else
                {
                    foreach (double n in finalnumbers)
                    {
                        if (inc == 0)
                        {
                            output += n;
                        }
                        else
                        {
                            switch (operators[inc - 1])
                            {
                                case '+':
                                    output += n;
                                    break;
                                case '-':
                                    output -= n;
                                    break;
                            }
                        }

                        inc++;
                    }
                    return output.ToString();
                }
               
            }
            else
            {

                return input;
            }

        }
      }   
    }