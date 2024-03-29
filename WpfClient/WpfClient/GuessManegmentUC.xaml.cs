﻿using System;
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
using WpfClient.APLService;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for GuessManegmentUC.xaml
    /// </summary>
    public partial class GuessManegmentUC : UserControl
    {
        GameList gameLst;
        public GuessManegmentUC(GameList games, User user)
        {
            InitializeComponent();
            ServiceBaseClient client = new ServiceBaseClient();
            gameLst = games;
            foreach (Game game in games)
                GamesSP.Children.Add(new UpcomingGameUC(game, user));
        }
    }
}
