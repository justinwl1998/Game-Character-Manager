using System;
using System.Data;
using System.Data.SqlClient;

namespace GameModelLibrary
{
    /// <summary>
    /// GameModel fulfills the business logic of interacting with the database.
    /// </summary>
    public class GameModel
    {
        #region public method
        /// <summary>
        /// Adds a character to the database.
        /// </summary>
        /// <param name="character"></param>
        /// <returns>True if successful</returns>
        public bool addCharacter(Character character)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server=(local);Database=TestDatabase2;Trusted_Connection=Yes;");
                con.Open();

                using (SqlCommand cmd = new SqlCommand("AddCharacter", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter("@charName", SqlDbType.NVarChar);
                    param1.Value = character.Name;

                    SqlParameter param2 = new SqlParameter("@charGameId", SqlDbType.Int);
                    param2.Value = character.Id;

                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a game to the database.
        /// </summary>
        /// <param name="game"></param>
        /// <returns>True if successful</returns>
        public bool addGame(Game game)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server=(local);Database=TestDatabase2;Trusted_Connection=Yes;");
                con.Open();

                using (SqlCommand cmd = new SqlCommand("AddGame", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter("@gameName", SqlDbType.NVarChar);
                    param1.Value = game.Name;

                    SqlParameter param2 = new SqlParameter("@gamePlatform", SqlDbType.NVarChar);
                    param2.Value = game.Platform;

                    SqlParameter param3 = new SqlParameter("@gameRelease", SqlDbType.Date);
                    param3.Value = game.ReleaseDate;

                    SqlParameter param4 = new SqlParameter("@gamePrice", SqlDbType.SmallMoney);
                    param4.Value = game.Price;

                    SqlParameter param5 = new SqlParameter("@gameMaxPlayers", SqlDbType.Int);
                    param5.Value = game.MaxPlayers;

                    SqlParameter param6 = new SqlParameter("@gameIsOnPC", SqlDbType.Bit);
                    param6.Value = game.IsOnPC;

                    SqlParameter param7 = new SqlParameter("@gameExpired", SqlDbType.Bit);
                    param7.Value = game.IsExpired;

                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);
                    cmd.Parameters.Add(param3);
                    cmd.Parameters.Add(param4);
                    cmd.Parameters.Add(param5);
                    cmd.Parameters.Add(param6);
                    cmd.Parameters.Add(param7);

                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Game successfully added to database!");
                    con.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable getGameList()
        {
            // query database to populate the list with any ids from the games table
            SqlConnection con = new SqlConnection(@"Server=(local);Database=TestDatabase2;Trusted_Connection=Yes;");
            SqlCommand cmd = new SqlCommand("SELECT id, name FROM dbo.games", con);
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cmd.Dispose();
            con.Close();

            return dt;
        }
        #endregion public method
    }
}
