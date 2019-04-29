using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _14._04._2019
{
  internal class Sellers
  {
    public static void Show(ListBox listBox)
    {
      ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SalesDb"];
      var connectionString = settings.ConnectionString;
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        try
        {
          connection.Open();
        }
        catch (System.Exception exeption)
        {
          MessageBox.Show("Ошибка подключения:{0}", exeption.Message);
          return;
        }

        SqlCommand command = new SqlCommand("select * from Sellers", connection);


        try
        {
          var reader = command.ExecuteReader();
          if (reader.HasRows)
          {
            listBox.Items.Add(reader.GetName(0) + "\t\t" + reader.GetName(1) + "\t\t" + reader.GetName(2));
            while (reader.Read())
            {
              object id = reader.GetValue(0);
              object name = reader.GetValue(1);
              object surname = reader.GetValue(2);

              listBox.Items.Add(id.ToString() + "\t\t" + name + "\t\t" + surname);
            }
          }
          reader.Close();
        }
        catch (Exception exeption)
        {
          MessageBox.Show(exeption.Message.ToString(), exeption.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      }
    }
  }
}