using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14._04._2019
{
  class Sales
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

        SqlCommand command = new SqlCommand(@"select s.Id, c.Surname as 'Фамилия покупателя', sel.Surname as 'Фамилия продавца', s.TransactionAmount, s.TransactionDate from Sales s join Customer c on s.CustomerId=c.Id join Sellers sel on sel.Id=s.SellersId", connection);


        try
        {
          var reader = command.ExecuteReader();
          if (reader.HasRows)
          {
            listBox.Items.Add(reader.GetName(0) + " | " + reader.GetName(1) + " | " + reader.GetName(2) + " | " + reader.GetName(3) + " | " + reader.GetName(4));
            while (reader.Read())
            {
              object id = reader.GetValue(0);
              object customerSurname = reader.GetValue(1);
              object sellersSurname = reader.GetValue(2);
              object transactionAmount = reader.GetValue(3);
              object transactionDate = reader.GetValue(4);


              listBox.Items.Add(id.ToString() + "  |             " +
                  " " + customerSurname + "                          " +
                  "" + sellersSurname + "\t        " + transactionAmount + "\t     " +
                  "  " + transactionDate);
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
