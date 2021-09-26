
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using My_Health.Charts;
using My_Health.Models;
using My_Health.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
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

namespace My_Health
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string PATH = $"{Environment.CurrentDirectory}\\data\\day1.json";
        private BindingList<user> user_data;
        private FaleIOServes _fileIOService;
        public Func<double, string> Formatter { get; set; }

        public MainWindow()
        {
            InitializeComponent();
          
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataFale();  
            dgList.ItemsSource = user_data;// Binding DgList
            Grafic(user_data[1]);
            //   MessageBox.Show(  user_data[0].Day_Step[3].ToString());

        }


        void Grafic (user user)
        {
            user user_t = new user();
            user_t = user;
            if(user_t == null)
            {
                user_t = user_data[1];
            }
    
         var dayConfig = Mappers.Xy<DateModel>()
        .X(dateModel => dateModel.day)
        .Y(dateModel => dateModel.Value);

            SeriesCollection Series = new SeriesCollection(dayConfig)
        {
            new LineSeries
            {
                Title = "Точки",
                                      
                Values = new ChartValues<DateModel>
                {                           
                  new DateModel
                    {
                        day   = 1,
                        Value = user_t.Day_Step[1]
                    },
                   new DateModel
                    {
                        day   = 2,
                        Value = user_t.Day_Step[2]
                    },
                    new DateModel
                    {
                        day   = 3,
                        Value = user_t.Day_Step[3]
                    },
                     new DateModel
                    {
                        day   = 4,
                        Value = user_t.Day_Step[4]
                    },
                      new DateModel
                    {
                        day   = 5,
                        Value = user_t.Day_Step[5]
                    },
                       new DateModel
                    {
                        day   = 6,
                        Value = user_t.Day_Step[6]
                    },
                        new DateModel
                    {
                        day   = 7,
                        Value = user_t.Day_Step[7]
                    },
                         new DateModel
                    {
                        day   = 8,
                        Value = user_t.Day_Step[8]
                    },
                          new DateModel
                    {
                        day   = 9,
                        Value = user_t.Day_Step[9]
                    },
                           new DateModel
                    {
                        day   = 10,
                        Value = user_t.Day_Step[10]
                    },
                            new DateModel
                    {
                        day   = 11,
                        Value = user_t.Day_Step[11]
                    },
                             new DateModel
                    {
                        day   = 12,
                        Value = user_t.Day_Step[12]
                    },
                              new DateModel
                    {
                        day   = 13,
                        Value = user_t.Day_Step[13]
                    },
                               new DateModel
                    {
                        day   = 14,
                        Value = user_t.Day_Step[14]
                    },
                                new DateModel
                    {
                        day   = 15,
                        Value = user_t.Day_Step[15]
                    },
                                 new DateModel
                    {
                        day   = 16,
                        Value = user_t.Day_Step[16]
                    },
                                  new DateModel
                    {
                        day   = 17,
                        Value = user_t.Day_Step[17]
                    },
                                   new DateModel
                    {
                        day   = 18,
                        Value = user_t.Day_Step[18]
                    },
                                    new DateModel
                    {
                        day   = 19,
                        Value = user_t.Day_Step[19]
                    },
                                     new DateModel
                    {
                        day   = 20,
                        Value = user_t.Day_Step[20]
                    },
                                      new DateModel
                    {
                        day   = 21,
                        Value = user_t.Day_Step[21]
                    },
                                       new DateModel
                    {
                        day   = 22,
                        Value = user_t.Day_Step[22]
                    },
                                        new DateModel
                    {
                        day   = 23,
                        Value = user_t.Day_Step[23]
                    },
                                         new DateModel
                    {
                        day   = 24,
                        Value = user_t.Day_Step[24]
                    },
                                          new DateModel
                    {
                        day   = 25,
                        Value = user_t.Day_Step[25]
                    },
                                           new DateModel
                    {
                        day   = 26,
                        Value = user_t.Day_Step[26]
                    },
                                            new DateModel
                    {
                        day   = 27,
                        Value = user_t.Day_Step[27]
                    },
                                             new DateModel
                    {
                        day   = 28,
                        Value = user_t.Day_Step[28]
                    },
                                              new DateModel
                    {
                        day   = 29,
                        Value = user_t.Day_Step[29]
                    },
                                               new DateModel
                    {
                        day   = 30,
                        Value = user_t.Day_Step[30]
                    },

                },

                Fill = Brushes.Transparent,

            },
        };

           // Formatter = value => new System.DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("t");

            RankGraph.Series = Series;

        }


        void LoadDataFale()             
        {

            _fileIOService = new FaleIOServes(PATH);
             BindingList<user> temp_user_data;
             user_data = _fileIOService.LoadDate();


            foreach(user tt_user in user_data)
            {
                tt_user.Day_Step[1] = tt_user.Steps;
            }

            try
            {
                for (int i = 2; i <= 30; i++)
                {
                    string PATH_temp = $"{Environment.CurrentDirectory}\\data\\day{i}.json";

                    _fileIOService.Path(PATH_temp);
                    temp_user_data = _fileIOService.LoadDate();

                    foreach (user t_user in temp_user_data)
                    {
                        foreach (user tt_user in user_data)
                        {
                            if (t_user.User == tt_user.User)
                            {
                                tt_user.Day_Step[i] = t_user.Steps;
                            }
                        }

                    }
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            foreach (user tt_user in user_data)  // поиск минимальных максимальных значений 
            {
                tt_user.Sred_value();
                tt_user.Max_Value();
                tt_user.Min_Value();
            }

        }

        private void dgList_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            try
            {
                user user_t = (user)dgList.SelectedItem;
                Grafic(user_t);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы выброли пустую строчку");                     
            }
              
         
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                user user_t = (user)dgList.SelectedItem;
                string PATH_temp = $"{Environment.CurrentDirectory}\\save\\{user_t.User.ToString()}.json";
                _fileIOService.Path(PATH_temp);
                _fileIOService.SaveDate(user_t);
                MessageBox.Show($"Данные сохранены по пути {PATH_temp}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




            
        }

        private void dgList_LoadingRow(object sender, DataGridRowEventArgs e)
        {

            DataGridRow rowContext = e.Row;
            if(rowContext!= null)
            {
                try
                {
                    user tt = (user)rowContext.Item;

                    if (tt.Max_Step > (tt.Sred_Steps + ( tt.Sred_Steps*0.2)) )
                    {
                        SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(200, 255, 232, 100));
                        rowContext.Background = brush;
                    }

                    if (tt.Min_Step < (tt.Sred_Steps - (tt.Sred_Steps * 0.2)))
                    {
                        SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(100, 104, 194, 15));
                        rowContext.Background = brush;
                    }

                }
                catch (Exception)
                {
                
                }

              
            }

        }



    }

}
