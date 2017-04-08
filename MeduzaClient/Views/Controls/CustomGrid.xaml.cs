using MeduzaClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MeduzaClient.Views.Controls
{
    public sealed partial class CustomGrid : UserControl
    {
        public CustomGrid()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Заголовок контролла
        /// </summary>
        public static DependencyProperty HeaderContentProperty = DependencyProperty.Register("HeaderContent", typeof(string), typeof(CustomGrid), new PropertyMetadata(string.Empty));
        public string HeaderContent
        {
            get
            {
                return (string)GetValue(HeaderContentProperty);
            }
            set
            {
                SetValue(HeaderContentProperty, value);
            }
        }

        /// <summary>
        /// Коллекция данных
        /// </summary>
        public static DependencyProperty ItemsContentProperty = DependencyProperty.Register("ItemsContent", typeof(IEnumerable<Document>), typeof(CustomGrid), new PropertyMetadata(default(IEnumerable<Document>)));
        public IEnumerable<Document> ItemsContent
        {
            get
            {
                return (IEnumerable<Document>)GetValue(HeaderContentProperty);
            }
            set
            {
                SetValue(HeaderContentProperty, value);
            }
        }

        /// <summary>
        /// Команда реагирующая на клик по айтему
        /// </summary>
        public static DependencyProperty ItemClickCommandProperty = DependencyProperty.Register("ItemClickCommand", typeof(ICommand), typeof(CustomGrid), new PropertyMetadata(default(ICommand)));
        public ICommand ItemClickCommand
        {
            get
            {
                return (ICommand)GetValue(ItemClickCommandProperty);
            }
            set
            {
                SetValue(ItemClickCommandProperty, value);
            }
        }

        private void gridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ItemClickCommand?.Execute(e.ClickedItem);
        }
    }
}
