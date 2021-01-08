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

namespace Jobs_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public JobsModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = new JobsModel();
            showJobs();
        }

        public Border createJobBlock(Job job)
        {
            Border JobBlock = new Border();
            JobBlock.Background = new SolidColorBrush(Colors.GhostWhite);
            JobBlock.BorderThickness = new Thickness(2);
            JobBlock.Margin = new Thickness(10, 0, 9.6, 0);
            JobBlock.BorderBrush = new SolidColorBrush(Colors.Black);
            JobBlock.CornerRadius = new CornerRadius(8, 8, 3, 3);
            JobBlock.Height = 100;

            Button showDetail = new Button();
            showDetail.Height = 100;
            showDetail.Click += new RoutedEventHandler(ShowDetail);
            showDetail.Background = new SolidColorBrush(Colors.White);
            showDetail.Foreground = new SolidColorBrush(Colors.Black);
            showDetail.BorderThickness = new Thickness(0);
            showDetail.Tag = Convert.ToString(job.id);

            Grid container = new Grid();
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            rowDef1.Height = new GridLength(14.4);
            container.RowDefinitions.Add(rowDef1);
            container.RowDefinitions.Add(rowDef2);

            StackPanel row1 = new StackPanel();
            row1.Orientation = Orientation.Horizontal;
            row1.Height = 30;
            TextBlock id = new TextBlock();
            id.Text = "#" + Convert.ToString(job.id); 
            id.FontSize = 12;
            id.FontWeight = FontWeights.Bold;
            id.TextAlignment = TextAlignment.Center;
            id.Width = 40;
            id.Height = 30;
            TextBlock timeWork = new TextBlock();
            timeWork.Text = job.start_time.ToString("dd-MM-yyyy") + " - " + job.end_time.ToString("dd-MM-yyyy");
            timeWork.FontSize = 12;
            id.Height = 30;

            row1.Children.Add(id);
            row1.Children.Add(timeWork);
            
            Grid.SetRow(row1, 0);
            container.Children.Add(row1);

            TextBlock name = new TextBlock();
            name.Text = job.name;
            name.FontSize = 20;
            name.Margin = new Thickness(10, 9.6, 9.8, 0.4);
            name.TextWrapping = TextWrapping.WrapWithOverflow;

            Grid.SetRow(name, 1);
            container.Children.Add(name);

            showDetail.Content = container;
            JobBlock.Child = showDetail;
            return JobBlock;
        }

        public void showJobs()
        {
            
            List<Job> jobs = model.getJobs();
            foreach (Job item in jobs)
            {
                Border job_block = createJobBlock(item);
                if ( item.status == 1 )
                {
                    waitting.Children.Add(job_block);
                }
                else if ( item.status == 2 )
                {
                    to_do.Children.Add(job_block);
                }
                else if (item.status == 2)
                {
                    doing.Children.Add(job_block);
                }
                else if (item.status == 3)
                {
                    issue.Children.Add(job_block);
                }
                else if (item.status == 4)
                {
                    done.Children.Add(job_block);
                }
            }
        }

        private void ShowWorkingSpace(object sender, RoutedEventArgs e)
        {

        }

        private void ShowAddPage(object sender, RoutedEventArgs e)
        {

        }

        private void ShowDetail(object sender, RoutedEventArgs e)
        {
            Button job_block = (Button)sender;
            Job item;
            if (job_block.Tag != "")
            {
                var id = Convert.ToInt32(job_block.Tag);
                item = model.getJob(id);
            }
            else
            {
                item = new Job();
            }
            JobWindow jobDetail = new JobWindow();
            jobDetail.Show();
        }

        private void ShowTrash(object sender, RoutedEventArgs e)
        {

        }
    }
}
