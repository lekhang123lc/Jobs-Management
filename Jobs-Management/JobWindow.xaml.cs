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

namespace Jobs_Management
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class JobWindow : Window
    {
        public Job item;

        public JobsModel model;

        public JobWindow()
        {
            InitializeComponent();
            item = new Job();
            model = JobsModel.getInstance();
        }

        public JobWindow(Job _item)
        {
            InitializeComponent();
            item = _item;
            model = JobsModel.getInstance();
            bindData();
        }

        public void bindData()
        {
            DataContext = item;
        }

        public void save()
        {

        }

        public void delete()
        {

        }

        public void permanentlyDelete()
        {

        }
    }
}
