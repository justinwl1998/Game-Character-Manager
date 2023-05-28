using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

using GameModelLibrary;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region private members
        private GameModel _gameModel;
        #endregion private members

        public MainWindow()
        {
            InitializeComponent();
            _gameModel = new GameModel();
        }

        #region private methods
        private void NumericOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }

        private void SubmitCharButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameEntryBox.Text.Length == 0)
            {
                MessageBox.Show("Input a Name.");
                return;
            }

            if (GameIDEntryList.SelectedValue == null)
            {
                MessageBox.Show("Input a Game ID.");
                return;
            }

            Character newCharacter = new Character(NameEntryBox.Text, Convert.ToInt32(GameIDEntryList.SelectedValue));

            // Run stored procedure
            if (_gameModel.addCharacter(newCharacter))
            {
                MessageBox.Show("Character successfully added to database!");
            }
            else
            {
                MessageBox.Show("Database Error. Something went wrong.");
            }
        }

        private void MaxPlayerEntryBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void GameIDEntryList_DropDownOpened(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = _gameModel.getGameList();

                GameIDEntryList.ItemsSource = dt.DefaultView;
                GameIDEntryList.DisplayMemberPath = "name";
                GameIDEntryList.SelectedValuePath = "id";
            }
            catch
            {
                MessageBox.Show("Database Error. Something went wrong.");
            }
        }

        private void SubmitGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(GameNameEntryBox.Text))
            {
                MessageBox.Show("Input a game name.");
                return;
            }
            if (String.IsNullOrWhiteSpace(PlatformEntryBox.Text))
            {
                MessageBox.Show("Input a platform the game runs on.");
                return;
            }
            if (String.IsNullOrWhiteSpace(ReleaseDateEntry.Text))
            {
                MessageBox.Show("Input a release date for the game.");
                return;
            }
            if (String.IsNullOrWhiteSpace(GamePriceEntryBox.Text))
            {
                MessageBox.Show("Input a price for the game.");
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxPlayerEntryBox.Text))
            {
                MessageBox.Show("Input the maximum players for the game.");
                return;
            }

            Game newGame = new Game(GameNameEntryBox.Text,
                                    PlatformEntryBox.Text,
                                    ReleaseDateEntry.Text,
                                    99.95,
                                    0,
                                    IsOnPCCheckBox.IsChecked.Value,
                                    IsExpiredCheckBox.IsChecked.Value);
            double holdPrice;
            Double.TryParse(GamePriceEntryBox.Text, out holdPrice);
            int holdPlayer;
            Int32.TryParse(MaxPlayerEntryBox.Text, out holdPlayer);

            newGame.Price = holdPrice;
            newGame.MaxPlayers = holdPlayer;

            if (_gameModel.addGame(newGame))
            {
                MessageBox.Show("Game successfully added to database");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }
        }
        #endregion private methods

        // todo: add method for show all characters in a specific game
    }
}
