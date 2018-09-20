using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Restaurant.Models
{
  public class Entree
  {
    private string dish{get; set; }
    private string dessert{get; set; }
    private int Id{get; set; }

    public Entree(string menuDish, string menuDessert, int menuId = 0)
    {
      _dish = menuDish;
      _dessert = menudessert;
      _id = menuId;
    }

    public override bool Equals(System.Object otherEntree)
    {
      if (!(otherEntree is Entree))
      {
        return false;
      }
      else
      {
        Entree newEntree = (Entree) otherEntree;
        return this.GetId().Equals(newEntree.GetId());
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }


// Get Dish
    public static List<Entree> GetAll()
      {
        List<Entree> allEntree = new List<Entree> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM menu;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int itemId = rdr.GetInt32(0);
          string itemDescription = rdr.GetString(1);
          string itemDueDate = rdr.GetString(2);
          Item newItem = new Item(itemDescription, itemDueDate, itemCategoryId, itemId);
          allItems.Add(newItem);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allItems;
      }

// Save Method
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
cmd.CommandText = @"INSERT INTO items (dish, dessert, id) VALUES (@entreeDish, @entreeDessert, @entreeId);";
      MySqlParameter menuDish = new MySqlParameter();
      menuDish.ParameterName = "@entreeDish";
      menuDish.Value = this.dish;
      cmd.Parameters.Add(menuDish);

      MySqlParameter menuDessert = new MySqlParameter();
      menuDessert.ParameterName = "@entreeDessert";
      menuDessert.Value = this.dessert;
      cmd.Parameters.Add(menuDessert);

      MySqlParameter newCategoryId = new MySqlParameter();
      menuId.ParameterName = "@entreeId";
      menuId.Value = this.id;
      cmd.Parameters.Add(menuId);

      cmd.ExecuteNonQuery();
      id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
    }

// Delete Dish
    public void Delete(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM menu WHERE id = @thisId";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@thisId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


// DeleteAll Menu
    public static void DeleteAll()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();

    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"DELETE FROM menu;";

    cmd.ExecuteNonQuery();

    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
  }

  }
}
