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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Json_Wirter
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        TextBox textBox = new TextBox();

        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string name;
            switch (DataTypeDrop.Text)
            {
                case "String":
                    {
                        string Data = textBox.Text;
                        name = NameBox.Text;
                        Json.Json_Load_Make.Instance.ADDSerliizeData<string>(ref Data, name);
                    }
                    break;
                case "Int":
                    {
                        //TODO implment check to filter out string and other errors
                        int Data = Int32.Parse(textBox.Text);
                        name = NameBox.Text;
                       Json.Json_Load_Make.Instance.ADDSerliizeData<int>(ref Data, name);
                    }
                    break;
                case "Float":
                    {
                        //TODO implment check to filter out string and other errors
                        float Data = float.Parse(textBox.Text);
                        name = NameBox.Text;
                        Json.Json_Load_Make.Instance.ADDSerliizeData<float>(ref Data, name);
                    }
                    break;
                case "bool":
                    {
                       //TODO Identify bool answers
                    }
                    break;
                case "Array":
                    {
                        //TODO implment check to filter out array errors
                    }
                    break;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name;
            switch (DataTypeDrop.Text)
            {
                case "String":
                    {
                        string Data = textBox.Text;
                        name = NameBox.Text;
                        Json.Json_Load_Make.Instance.ADDTOObjectSerliizeData<string>(ref Data, name);
                    }
                    break;
                case "Int":
                    {                      
                        int Data;
                        if (Int32.TryParse(textBox.Text,out Data))
                        {
                            name = NameBox.Text;
                            Json.Json_Load_Make.Instance.ADDTOObjectSerliizeData<int>(ref Data, name);
                        }
                        else
                        {
                            //error
                        }
                    }
                    break;
                case "Float":
                    {
                       
                        float Data;
                        if (float.TryParse(textBox.Text, out Data))
                        {
                            name = NameBox.Text;
                            Json.Json_Load_Make.Instance.ADDTOObjectSerliizeData<float>(ref Data, name);
                        }
                        else
                        {
                            //error
                        }
                    }
                    break;
                case "bool":
                    {
                        name = NameBox.Text;
                        
                        int Data;
                        string Text= string.Empty;
                        if (Int32.TryParse(textBox.Text, out Data))
                        {

                        }
                        else { 
                             Text = textBox.Text.ToLower();
                        }


                        bool outData;
                        if (Text == "true" || Data==1)
                        {
                            outData = true;
                            
                            Json.Json_Load_Make.Instance.ADDTOObjectSerliizeData<bool>(ref outData, name);
                        }
                        else if(Text == "false" || Data == 0)
                        {

                            outData = false;
                            Json.Json_Load_Make.Instance.ADDTOObjectSerliizeData<bool>(ref outData, name);
                        }
                        else
                        {
                            //error
                        }

                    }
                    break;
                case "Array":
                    {
                        //TODO implment check to filter out array errors
                    }
                    break;
                case "Object":
                    {
                        //TODO implment check to filter out array errors
                    }
                    break;
            }

            





        }

        private void DataTypeDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ScrollViewer scrollViewer = new ScrollViewer();
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            scrollViewer.Name = "scv3";
 
            switch (DataTypeDrop.Text)
            {
               
                case "Array":
                    {
                        
                    }
                    break;
                case "Object":
                    {
                        
                    }
                    break;
                default:
                    {
                        
                        textBox = new TextBox();
                        textBox.Name = "TextBox2";

                        Grid.SetColumnSpan(textBox, 4);
                        Grid.SetRowSpan(textBox, 2);
                        Grid.SetRow(textBox, 4);
                        Grid.SetColumn(textBox, 3);





                        MainGrid.Children.Add(textBox);
                    }
                    break;
            }

        }
    }
}
