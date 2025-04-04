using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace C_Shop.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sda;
        DataTable dt;
 

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;


        }

        protected SqlConnection GetCon()
        {
            return con;
        }

        protected void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            // Xử lý khi nút được nhấn

            string actionName = string.Empty, imagePath = string.Empty, fileextension = string.Empty;
            bool isVakiToExcute = false;
            int categoryId = Convert.ToInt32(hfCategoryId.Value);
            con = new SqlConnection(Utils.GetConnection());
            cmd = new SqlCommand("Category_Crud", con);
            cmd.Parameters.AddWithValue("@Action", categoryId == 0 ? "INSERT" : "UPDATE");
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text.Trim());
            cmd.Parameters.AddWithValue("@IsActive", cbIsActive.Checked);
            if (fuCategoryImage.HasFile)
            {
                if (Utils.IsValidExtension(fuCategoryImage.FileName))
                {
                    string newImageName = Utils.getUniqueId();
                    fileextension = Path.GetExtension(fuCategoryImage.FileName);
                    imagePath = "Images/Category/" + newImageName.ToString() + fileextension;
                    fuCategoryImage.PostedFile.SaveAs(Server.MapPath("~/Images/Category/") + newImageName.ToString() + fileextension);
                    cmd.Parameters.AddWithValue("@CategoryImageUrl", imagePath);
                    isVakiToExcute = true;
                }
                else
                {
                    lblMsg.Visible = false;
                    lblMsg.Text = "Please select .jpg, .jpeg or .png image";
                    lblMsg.CssClass = "alert alert-danger";
                    isVakiToExcute = false;
                }
            }
            else
            {
                isVakiToExcute = true;
            }

            if (isVakiToExcute)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    actionName = categoryId == 0 ? "inserted" : "updated";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Category " + actionName + " Successfully";
                    lblMsg.CssClass = "alert alert-success";
                }
                catch (Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error " + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
                finally
                {
                    con.Close();
                }

            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            txtCategoryName.Text = string.Empty;
            cbIsActive.Checked = false;
            hfCategoryId.Value = "0";
            btnAddOrUpdate.Text = "Add";
            ImagePreview.ImageUrl = string.Empty;
        }
    }
}
