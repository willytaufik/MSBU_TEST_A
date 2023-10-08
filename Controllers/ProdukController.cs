using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using MSBU_Soal_Test_A.Models;

namespace MSBU_Soal_Test_A.Controllers;

public class ProdukController : Controller
{
private readonly string _connectionString = "Server=DESKTOP-GB71T5U\\SQLEXPRESS;Database=produk_db;Trusted_Connection=True;User=sa;Password=admin123;";

    public IActionResult Index(string searchTerm)
    {
        List<ProdukModel> produkList = new List<ProdukModel>();
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                 SqlCommand cmd;

                if (string.IsNullOrEmpty(searchTerm))
                {
                    cmd = new SqlCommand("SELECT * FROM Produk", connection);
                }
                else{               
                    cmd = new SqlCommand("sp_SearchProduk", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@search_term", searchTerm);
                  }
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    ProdukModel produk = new ProdukModel
                    {
                        Id = Convert.ToInt32(dataReader["id"]),
                        NamaBarang = dataReader["nama_barang"].ToString(),
                        KodeBarang = dataReader["kode_barang"].ToString(),
                        JumlahBarang = Convert.ToInt32(dataReader["jumlah_barang"]),
                        Tanggal = Convert.ToDateTime(dataReader["tanggal"])
                    };

                    produkList.Add(produk);
                }

                connection.Close();
            }
        } catch (SqlException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }

        return View(produkList);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(ProdukModel produk)
    {
        if (ModelState.IsValid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_AddProduk", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nama_barang", produk.NamaBarang);
                cmd.Parameters.AddWithValue("@kode_barang", produk.KodeBarang);
                cmd.Parameters.AddWithValue("@jumlah_barang", produk.JumlahBarang);
                cmd.Parameters.AddWithValue("@tanggal", produk.Tanggal);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        return View(produk);
    }

    public IActionResult Edit(int id)
    {
        ProdukModel produk = new ProdukModel();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Produk WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                produk.Id = Convert.ToInt32(dataReader["id"]);
                produk.NamaBarang = dataReader["nama_barang"].ToString();
                produk.KodeBarang = dataReader["kode_barang"].ToString();
                produk.JumlahBarang = Convert.ToInt32(dataReader["jumlah_barang"]);
                produk.Tanggal = Convert.ToDateTime(dataReader["tanggal"]);
            }

            connection.Close();
        }
        return View(produk);
    }

    [HttpPost]
    public IActionResult Edit(ProdukModel produk)
    {
        if (ModelState.IsValid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateProduk", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", produk.Id);
                cmd.Parameters.AddWithValue("@nama_barang", produk.NamaBarang);
                cmd.Parameters.AddWithValue("@kode_barang", produk.KodeBarang);
                cmd.Parameters.AddWithValue("@jumlah_barang", produk.JumlahBarang);
                cmd.Parameters.AddWithValue("@tanggal", produk.Tanggal);

                cmd.ExecuteNonQuery();
                connection.Close();
            }

            return RedirectToAction("Index");
        }

        return View(produk);
    }

    // Action untuk menghapus produk
    public IActionResult Delete(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("sp_DeleteProduk", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Search(string searchTerm)
    {
        List<ProdukModel> produkList = new List<ProdukModel>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("sp_SearchProduk", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@search_term", searchTerm);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                ProdukModel produk = new ProdukModel
                {
                    Id = Convert.ToInt32(dataReader["id"]),
                    NamaBarang = dataReader["nama_barang"].ToString(),
                    KodeBarang = dataReader["kode_barang"].ToString(),
                    JumlahBarang = Convert.ToInt32(dataReader["jumlah_barang"]),
                    Tanggal = Convert.ToDateTime(dataReader["tanggal"])
                };

                produkList.Add(produk);
            }

            connection.Close();
        }

        return View("Index", produkList);
    }
}
