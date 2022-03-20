using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;


namespace myfirstapp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    
    
        public partial class Window1 : Window
        {

            public Window1()
            {
                InitializeComponent();
            }



            Regex inputID = new Regex(@"[0-9]");

            private void Id_PreviewTextInput(object sender, TextCompositionEventArgs e)

            {

                Match match = inputID.Match(e.Text);

                if (!match.Success)

                {

                    e.Handled = true;

                }

            }

            Regex surn = new Regex(@"[а-я]");

            private void Surn_PreviewTextInput(object sender, TextCompositionEventArgs e)

            {

                Match surnS = surn.Match(e.Text);

                if (!surnS.Success)

                {

                    e.Handled = true;

                }

            }



            Regex Email = new Regex(@"[a-zA-Z]");

            private void Email_PreviewTextInput(object sender, TextCompositionEventArgs e)

            {

                Match EmailS = Email.Match(e.Text);

                if (!EmailS.Success)

                {

                    e.Handled = true;

                }

            }


            private void Button_Click(object sender, RoutedEventArgs e)

            {
                string temp = $"{Id.Text}";
                bool pro = true;
                List<string> personal = new List<string>();
                StringBuilder errors = new StringBuilder();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/info.txt";
                FileStream fs = new FileStream(path, FileMode.Append);
                fs.Close();
                bool abd = false;
                StreamReader idreader = new StreamReader(path);

                {
                    {
                        string[] sas = idreader.ReadToEnd().Split('\t');
                        if (!idreader.EndOfStream)
                        {
                            sas = idreader.ReadToEnd().Split('\t');
                        }
                        //  for (int i = 0; i < sas.Length; i++) { MessageBox.Show(sas[i]); }               
                        for (int i = 0; i < sas.Length; i++)
                        {

                            if (temp == sas[i])
                            {
                                errors.AppendLine("Идентификатор занят");
                                pro = false;
                            }
                        }
                        if (pro == true)
                        {
                            idreader.Close();
                        }

                    }




                    if (phone.Text.Length != 10)
                    {
                        errors.AppendLine("Некорректный номер телефона");
                        pro = false;
                    }
                    if (Series.Text.Length != 4)
                    {
                        errors.AppendLine("Некорректная серия паспорта");
                        pro = false;
                    }
                    if (Number.Text.Length != 6)
                    {
                        errors.AppendLine("Некоррентнаый номер паспорта");
                        pro = !false;
                    }
                    if (emaillogin.Text.StartsWith("_"))
                    {
                        errors.AppendLine("Почта не может начинаться с _");
                        pro = false;
                    }
                    if (Id.Text == "" || Surn.Text == "" || namee.Text == "" || patronymic.Text == "" || Series.Text == "" || Number.Text == "" || emaillogin.Text == "" || phone.Text == "")
                    {
                        errors.AppendLine("Есть пустые ячейки");
                        pro = false;

                    }


                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                    }
                    else
                    {


                        using (StreamWriter sw = new StreamWriter(@"C:\Users\slona\Desktop\info.txt", true))
                        {

                            string[] valueN = { namee.Text };
                            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                            foreach (var value in valueN)
                                namee.Text = ti.ToTitleCase(value);


                            string[] valueS = { Surn.Text };
                            TextInfo t = CultureInfo.CurrentCulture.TextInfo;
                            foreach (var value in valueS)
                                Surn.Text = ti.ToTitleCase(value);

                            string[] valueP = { patronymic.Text };
                            TextInfo i = CultureInfo.CurrentCulture.TextInfo;
                            foreach (var value in valueP)
                                patronymic.Text = ti.ToTitleCase(value);





                            sw.Write("ID: \t");
                            sw.Write($"{ Id.Text}\t");
                            sw.Write($"{Surn.Text}\t");
                            sw.Write($"{namee.Text}\t");
                            sw.Write($"{patronymic.Text}\t");
                            sw.Write($"{Series.Text + " " + Number.Text}\t");
                            sw.Write($"{phone.Text}\t");
                            sw.Write($"{emaillogin.Text + "@firma.ru"}\t");
                            sw.WriteLine();
                            abd = true;
                        }


                    }
                    if (abd == true)
                    {
                        MessageBox.Show("Сотрудник внесен в базу данных");
                    }
                    else MessageBox.Show("Сотрудник не внесен в базу данных");
                }


            }
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                this.Close();
            }


        }

    }






