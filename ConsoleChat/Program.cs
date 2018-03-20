using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using ConsoleFramework;
using ConsoleFramework.Controls;
using ConsoleFramework.Events;
using ConsoleFramework.Native;
using ConsoleFramework.Core;
using ConsoleFramework.Xaml;
using System.Linq;
using Xaml;

namespace ConsoleChat
{
    class Program
    {
        static void Main(string[] args)
        {
            //var test = new TextBox();



            ConsoleApplication application = ConsoleApplication.Instance;
            WindowsHost windowsHost = new WindowsHost
            {
                Name = "WindowsHost"
            };
            Type type = typeof(Program);
            TypeInfo typeInfo = type.GetTypeInfo();

            var assembly = typeInfo.Assembly;
            var resourceName = "ConsoleChat.ChatWindow.xml";
            Window createdFromXaml;
            MyDataContext dataContext = new MyDataContext();
            dataContext.Str = "Madafaka";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
               
                createdFromXaml = XamlParser.CreateFromXaml<Window>(result, dataContext, new List<string>()
                {
                    "clr-namespace:Xaml;assembly=Xaml",
                    "clr-namespace:ConsoleFramework.Xaml;assembly=ConsoleFramework",
                    "clr-namespace:ConsoleFramework.Controls;assembly=ConsoleFramework",
                });
            } 
            var myDataContext = new MyDataContext();
            var myGrid = new Grid();
            var chatText = new TextBlock
            {
                Height = 26,
                Width = 118,
                Text = "I like mayonaise"
            };
            var chatText2 = new TextBox
            {
                Width = 118,
                Name = "chatInput",
                DataContext = myDataContext
            };

            //chatText2.Text = "I like mayonaise";
            //myGrid.
            //myPanel.XChildren.Add(chatText2);
            var myWindow = new Window()
            {
                X = 0,
                Y = 0,
                //MinHeight = 10,
                //MinWidth = 70,
                Height = 30,
                Width = 120,
                Name = "LongTitleWindow",
                //Title = "LOL WTF"
            };
            myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            myGrid.RowDefinitions.Add(new RowDefinition());
            myGrid.RowDefinitions.Add(new RowDefinition());
            myGrid.Controls.Add(chatText);

            myGrid.Controls.Add(chatText2);
            //myWindow.Content = chatText;
            var chatArea = createdFromXaml.FindChildByName<TextBlock>("chatArea");
            var chatInput = createdFromXaml.FindChildByName<TextBox>("chatInput");
            
            createdFromXaml.KeyDown += (sender, evargs) =>
            {
                //Console.WriteLine("---------->> {0}",(VirtualKeys)evargs.wVirtualKeyCode);
                
                if (evargs.wVirtualKeyCode == VirtualKeys.Return)
                {
                    chatArea.Text += chatInput.Text;
                    dataContext.Str = null;
                    chatInput.Invalidate();
                    
                    
                    //atText2 = new TextBox();
                    //myGrid.Invalidate();
                }

            };

                
            myWindow.Content = myGrid;



            windowsHost.Show(createdFromXaml);
            application.Run(windowsHost);
        }

        private static void Enter(object sender, KeyEventArgs e)
        {
            
        }
    }

    class MyDataContext : INotifyPropertyChanged
    {
        private string str;
        public String Str
        {
            get { return str; }
            set
            {
                if (str != value)
                {
                    str = value;
                    raisePropertyChanged("Str");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void raisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
/*
 *   WindowsHost windowsHost = new WindowsHost()
 *           {
                Name = "WindowsHost"
            };
            var myPanel = new Panel();
            var chatText = new TextBlock();
            chatText.Text = "I like mayonaise";
            var chatText2 = new TextBox();
            chatText.Text = "I like mayonaise";
            //myGrid.
            //myPanel.XChildren.Add(chatText2);
            var myWindow = new Window()
            {
                X = 0,
                Y = 0,
                //MinHeight = 10,
                //MinWidth = 70,
                Height = 30,
                Width = 120,
                Name = "LongTitleWindow",
                Title = "LOL WTF"
            };
            myWindow.Content = chatText;
            myWindow.Content = chatText2;
            windowsHost.Show(myWindow);
*/

//Console.WriteLine("Hello World!");
/*
Type type = typeof(Program);
TypeInfo typeInfo = type.GetTypeInfo();

var assembly = typeInfo.Assembly;
var resourceName = "ConsoleChat.ChatWindow.xml";
Window createdFromXaml;
using (Stream stream = assembly.GetManifestResourceStream(resourceName))
using (StreamReader reader = new StreamReader(stream))
{
    string result = reader.ReadToEnd();
    MyDataContext dataContext = new MyDataContext();
    dataContext.Str = "Madafaka";
    createdFromXaml = XamlParser.CreateFromXaml<Window>(result, dataContext, new List<string>()
        {
            "clr-namespace:Xaml;assembly=Xaml",
            "clr-namespace:ConsoleFramework.Xaml;assembly=ConsoleFramework",
            "clr-namespace:ConsoleFramework.Controls;assembly=ConsoleFramework",
        });
}

*/
/*
 *            var myGrid = new Grid();
            var chatText = new TextBlock
            {
                Text = "I like mayonaise"
            };
            var chatText2 = new TextBox();
            chatText2.DataContext = new MyDataContext();
            //chatText2.Text = "I like mayonaise";
            //myGrid.
            //myPanel.XChildren.Add(chatText2);
            var myWindow = new Window()
            {
                X = 0,
                Y = 0,
                //MinHeight = 10,
                //MinWidth = 70,
                Height = 30,
                Width = 120,
                Name = "LongTitleWindow"
                //Title = "LOL WTF"
            };
            myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            myGrid.RowDefinitions.Add(new RowDefinition());
            //myGrid.Controls.Add(chatText);
            myGrid.Controls.Add(chatText2);
            //myWindow.Content = chatText;
            myWindow.Content = myGrid;
*/